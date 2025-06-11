using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.AIModels;
using Domain.Entities;

namespace Application.Services;

public class PromptService(IThreadService threadService, IPromptRepository promptRepository): IPromptService
{
    public async Task<IEnumerable<Prompt>> GetAllAsyncByThread(int threadId)
    {
        return await promptRepository.GetAllAsyncByThread(threadId);
    }

    public async Task<Prompt?> AddPromptAsync(int threadId, string promptText)
    {
        var thread = await threadService.GetByIdAsyncWithJoins(threadId);

        if (thread == null)
        {
            return null;
        }

        var provider = thread.Model.Provider.Name;

        IModelAI? modelAI = null;

        switch (provider)
        {
            case "gemini": modelAI = new GeminiFactory().CreateModelAI(thread); break;
            case "deepseek":modelAI = new DeepSeekFactory().CreateModelAI(thread); break;
            case "mistral":modelAI = new MistralFactory().CreateModelAI(thread); break;
        }

        if (modelAI != null)
        {
            var response = await modelAI.SendPrompt(promptText);

            if (response == null)
            {
                return null;
            }
            
            var newPrompt = new Prompt
            {
                PromptText = promptText,
                Response = response,
                ThreadId = threadId
            };
            
            var promptCreated = await promptRepository.CreateAsync(newPrompt);

            if (promptCreated == false)
            {
                return null;
            }
            
            return newPrompt;
        }

        return null;

    }
}