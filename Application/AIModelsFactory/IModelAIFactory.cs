using Thread = Domain.Entities.Thread;
namespace Application.AIModelsFactory;

public interface IModelAIFactory
{
    public IModelAI CreateModelAI(Thread thread);
}