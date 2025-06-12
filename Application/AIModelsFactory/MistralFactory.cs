using Thread = Domain.Entities.Thread;
namespace Application.AIModelsFactory;

public class MistralFactory:IModelAIFactory
{
    public IModelAI CreateModelAI(Thread thread)
    {
        return new ModelMistralAI(thread);
    }
}