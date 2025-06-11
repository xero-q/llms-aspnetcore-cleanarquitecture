using Thread = Domain.Entities.Thread;
namespace Application.AIModels;

public interface IModelAIFactory
{
    public IModelAI CreateModelAI(Thread thread);
}