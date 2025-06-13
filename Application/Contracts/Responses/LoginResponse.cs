namespace Application.Contracts.Responses;

public sealed class LoginResponse
{
    public required string Access { get; set; }
    
    public required bool IsAdmin { get; set; }
}