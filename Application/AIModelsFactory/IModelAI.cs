namespace Application.AIModelsFactory;

public interface IModelAI
{
    Task<string?> SendPrompt(string prompt);
}