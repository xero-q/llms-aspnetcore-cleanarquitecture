namespace Application.Services;

public interface IAuthenticationService
{
    Task<bool> Authenticate(string username, string password);

    string GenerateToken(string username);
}