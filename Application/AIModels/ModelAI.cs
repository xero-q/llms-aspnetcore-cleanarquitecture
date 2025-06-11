using Thread = Domain.Entities.Thread;
namespace Application.AIModels;

public abstract class ModelAI(Thread thread):IModelAI
{
    public abstract Task<string> SendPrompt(string prompt);
  
}