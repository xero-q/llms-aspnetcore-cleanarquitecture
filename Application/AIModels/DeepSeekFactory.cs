using Thread = Domain.Entities.Thread;

namespace Application.AIModels;

public class DeepSeekFactory:IModelAIFactory
{
    public IModelAI CreateModelAI(Thread thread)
    {
        return new ModelDeepSeekAI(thread);
    }
}