namespace Application.Contracts.Responses;

public sealed class UserResponse
{
    public required int Id { get; set; }
    
    public required string Username { get; init; }
   
}