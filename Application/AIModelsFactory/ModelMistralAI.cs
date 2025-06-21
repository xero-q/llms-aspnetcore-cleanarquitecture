using System.Text;
using Application.Abstractions.Services;
using Application.Helpers;
using DotNetEnv;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharedKernel;
using Thread = Domain.Entities.Thread;

namespace Application.AIModelsFactory;

public class ModelMistralAI(Thread thread, IPromptService promptService) : ModelAI(thread)
{
    public override async Task<string?> SendPrompt(string prompt)
    {
        Env.Load();

        string apiKeyName = thread.Model.EnvironmentVariable;

        string? apiKey = Environment.GetEnvironmentVariable(apiKeyName);

        if (apiKey == null)
        {
            return null;
        }

        string url = "https://api.mistral.ai/v1/chat/completions";

        string modelIdentifier = thread.Model.Identifier;
        
        var prompts = await promptService.GetAllAsyncByThread(thread.Id);

        var messages = new List<object>();

        foreach (var promptRecord in prompts)
        {
            messages.Add(new
            {
                role = "user",
                content = promptRecord.PromptText
            });
            
            messages.Add(new
            {
                role = "system",
                content = promptRecord.Response
            });
        }
        
        messages.Add(new
        {
            role = "user",
            content = prompt
        });
        
        var payload = new
        {
            model = modelIdentifier,
            messages = messages.ToArray(),
            temperature = thread.Model.Temperature,
            stream = false
        };


        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

        try
        {
            var response = await httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            JObject responseJson = JObject.Parse(responseBody);


            var text = (string)(responseJson["choices"][0]["message"]["content"]);

            return text;
        }
        catch (Exception ex)
        {
            throw new Exception($"{ErrorMessages.ErrorRequestLLM}: {ex.Message}");
        }
    }
}