namespace Application.Contracts.Requests;

public sealed class CreatePromptRequest
{
    public required string Prompt { get; init; }
}