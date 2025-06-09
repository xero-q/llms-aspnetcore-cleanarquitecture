using Application.Contracts.Requests;

namespace Application.Services;

public interface IAuthenticationService
{
    Task<bool> VerifyUser(LoginRequest request);

    string GenerateToken(string username);
}