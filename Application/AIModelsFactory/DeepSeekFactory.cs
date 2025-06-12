using Thread = Domain.Entities.Thread;

namespace Application.AIModelsFactory;

public class DeepSeekFactory:IModelAIFactory
{
    public IModelAI CreateModelAI(Thread thread)
    {
        return new ModelDeepSeekAI(thread);
    }
}