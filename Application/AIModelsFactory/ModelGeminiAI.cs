using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;
using Application.Helpers;
using Thread = Domain.Entities.Thread;
using DotNetEnv;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharedKernel;

namespace Application.AIModelsFactory;

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

        try
        {
            var response = await httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
            
                var responseBody = await response.Content.ReadAsStringAsync();

                JObject responseJson = JObject.Parse(responseBody);

                if (responseJson != null)
                {
                    var text = (string)(responseJson["candidates"][0]["content"]["parts"][0]["text"]);

                    return text;    
                }
                
                return null;
                
            
        }
        catch (Exception ex)
        {
            throw new Exception($"{ErrorMessages.ErrorRequestLLM}: {ex.Message}");
        }
        
    }
}