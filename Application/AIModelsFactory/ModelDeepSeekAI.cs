using System.Text;
using Application.Helpers;
using Newtonsoft.Json.Linq;
using SharedKernel;
using Thread = Domain.Entities.Thread;

namespace Application.AIModelsFactory;

public class ModelDeepSeekAI(Thread thread) : ModelAI(thread)
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

        string modelIdentifier = thread.Model.Identifier;

        var requestJson = $@"
        {{
            ""model"": ""{JsonHelper.EscapeJsonString(modelIdentifier)}"",
            ""messages"": [
                {{ ""role"": ""system"", ""content"": ""You are a helpful assistant."" }},
                {{ ""role"": ""user"", ""content"": ""{JsonHelper.EscapeJsonString(prompt)}"" }}
            ],
            ""stream"": false
        }}";

        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
        var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

        try
        {
            var response = await httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                JObject responseJson = JObject.Parse(responseBody);


                var text = (string)(responseJson["choices"][0]["message"]["content"]);

                return text;
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"{ErrorMessages.ErrorRequestLLM}: {ex.Message}");
        }
    }
}