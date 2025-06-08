namespace Application.Contracts.Requests;

public sealed class CreateUserRequest
{
    public required string Username { get; init; }
    
    public required string Password { get; init; }
}