using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.AIModelsFactory;
using Domain.Entities;

namespace Application.Services;

public class PromptService(IThreadService threadService, IPromptRepository promptRepository) : IPromptService
{
    public async Task<IEnumerable<Prompt>> GetAllAsyncByThread(int threadId, CancellationToken cancellationToken = default)
    {
        return await promptRepository.GetAllAsyncByThread(threadId, cancellationToken);
    }

    public async Task<Prompt?> AddPromptAsync(int threadId, string promptText, CancellationToken cancellationToken = default)
    {
        var thread = await threadService.GetByIdAsyncWithJoins(threadId, cancellationToken);

        if (thread == null)
        {
            return null;
        }

        var provider = thread.Model.Provider.Name;

        IModelAIFactory? modelAIFactory = null;

        switch (provider)
        {
            case "gemini": modelAIFactory = new GeminiFactory(); break;
            case "deepseek": modelAIFactory = new DeepSeekFactory(); break;
            case "mistral": modelAIFactory = new MistralFactory(); break;
        }

        if (modelAIFactory == null)
        {
            return null;
        }

        IModelAI modelAI = modelAIFactory.CreateModelAI(thread, this);


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

        var promptCreated = await promptRepository.CreateAsync(newPrompt, cancellationToken);

        if (promptCreated == false)
        {
            return null;
        }

        return newPrompt;
    }
}