using System.Text;
using System.Text.Json;
using Application.Helpers;
using Thread = Domain.Entities.Thread;
using DotNetEnv;
namespace Application.AIModels;
public class ModelGeminiAI(Thread thread) :ModelAI(thread)
{
    public override async Task<string?> SendPrompt(string prompt)
    {
        Env.Load();

        var apiKeyName = thread.Model.EnvironmentVariable;
        
        string? apiKey = Environment.GetEnvironmentVariable(apiKeyName);

        if (apiKey == null)
        {
            return null;
        }

        string modelIdentifier = thread.Model.Identifier;
        
        string url =
            $"https://generativelanguage.googleapis.com/v1beta/models/{modelIdentifier}:generateContent?key={apiKey}";
        
        var httpClient = new HttpClient();

        var requestJson = $@"
        {{
            ""contents"": [
                {{
                    ""parts"": [
                        {{ ""text"": ""{JsonHelper.EscapeJsonString(prompt)}"" }}
                    ]
                }}
            ]
        }}";

        var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
        
            using var document = JsonDocument.Parse(responseBody);
            var root = document.RootElement;

            var text = root
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            return text;    
        }
        
        return null;
    }
}