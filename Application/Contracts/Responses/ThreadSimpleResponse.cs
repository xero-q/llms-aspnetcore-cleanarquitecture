namespace Application.Contracts.Responses;

public sealed class ThreadSimpleResponse
{
    public required string Title { get; init; }
    
    public required DateTime CreatedAt { get; set; }
    
    public required int ModelId { get; init; }
}