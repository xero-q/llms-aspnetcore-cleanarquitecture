using Thread = Domain.Entities.Thread;
namespace Application.AIModelsFactory;

public abstract class ModelAI(Thread thread):IModelAI
{
    public abstract Task<string?> SendPrompt(string prompt);
  
}