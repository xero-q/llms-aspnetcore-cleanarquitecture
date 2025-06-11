using System.Text;
using System.Text.Json;
using Application.Helpers;
using Thread = Domain.Entities.Thread;

namespace Application.AIModels;

public class ModelDeepSeekAI(Thread thread) :ModelAI(thread)
{
    public override async Task<string?> SendPrompt(string prompt)
    {
        string apiKeyName = thread.Model.EnvironmentVariable;
        
        var apiKey = Environment.GetEnvironmentVariable(apiKeyName);

        if (apiKey == null)
        {
            return null;
        }
        
        var url = "https://api.deepseek.com/chat/completions";

        var requestJson = $@"
        {{
            ""model"": ""deepseek-chat"",
            ""messages"": [
                {{ ""role"": ""system"", ""content"": ""You are a helpful assistant."" }},
                {{ ""role"": ""user"", ""content"": ""{JsonHelper.EscapeJsonString(prompt)}"" }}
            ],
            ""stream"": false
        }}";

        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
        var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
        
        var response = await httpClient.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
        var responseBody = await response.Content.ReadAsStringAsync();

        using var document = JsonDocument.Parse(responseBody);
        var root = document.RootElement;

        var text = root
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return text;
        }

        return null;
        
    }
}