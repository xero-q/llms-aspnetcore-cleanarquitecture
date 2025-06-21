using Application.Abstractions.Services;
using Thread = Domain.Entities.Thread;
namespace Application.AIModelsFactory;

public class GeminiFactory:IModelAIFactory
{
    public IModelAI CreateModelAI(Thread thread, IPromptService promptService)
    {
        return new ModelGeminiAI(thread, promptService);
    }
}