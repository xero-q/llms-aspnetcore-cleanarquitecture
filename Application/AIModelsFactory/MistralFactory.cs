using Application.Abstractions.Services;
using Thread = Domain.Entities.Thread;
namespace Application.AIModelsFactory;

public class MistralFactory:IModelAIFactory
{
    public IModelAI CreateModelAI(Thread thread, IPromptService promptService)
    {
        return new ModelMistralAI(thread, promptService);
    }
}