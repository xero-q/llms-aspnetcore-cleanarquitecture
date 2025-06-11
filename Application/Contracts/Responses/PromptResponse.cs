namespace Application.Contracts.Responses;

public class PromptResponse
{
    public required int Id { get; init; }

    public required string Prompt { get; init; }

    public required string Response { get; init; }
    
    public required int ThreadId { get; init; }
    
    public required DateTime CreateAt { get; init; } 
}
    
    
