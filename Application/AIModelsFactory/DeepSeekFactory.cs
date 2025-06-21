using Application.Abstractions.Services;
using Thread = Domain.Entities.Thread;

namespace Application.AIModelsFactory;

public class DeepSeekFactory:IModelAIFactory
{
    public IModelAI CreateModelAI(Thread thread, IPromptService promptService)
    {
        return new ModelDeepSeekAI(thread);
    }
}