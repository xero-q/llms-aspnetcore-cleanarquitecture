namespace Application.Contracts.Responses;

public sealed class ThreadResponse
{
    public required string Title { get; init; }
    
    public required DateTime CreatedAt { get; set; }
    
    public required string CreatedAtDate { get; set; }
    
    public required int ModelId { get; init; }
    
    public required string ModelName { get; init; }
    
    public required string ModelType { get; init; }
    
    public required string ModelIdentifier { get; init; }
}