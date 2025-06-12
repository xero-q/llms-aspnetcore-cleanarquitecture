using Thread = Domain.Entities.Thread;
namespace Application.AIModelsFactory;

public class GeminiFactory:IModelAIFactory
{
    public IModelAI CreateModelAI(Thread thread)
    {
        return new ModelGeminiAI(thread);
    }
}