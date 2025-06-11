namespace Application.AIModels;

public interface IModelAI
{
    Task<string?> SendPrompt(string prompt);
}