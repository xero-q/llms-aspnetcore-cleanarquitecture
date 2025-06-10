namespace Application.Contracts.Requests;

public sealed class ThreadResponse
{
    public required string Title { get; init; }
    
    public required DateTime CreatedAt { get; set; }
    
    public required int ModelId { get; init; }
    
    public required int UserId { get; init; }
}