using Application.Contracts.Requests;

namespace Application.Abstractions.Services;

public interface IAuthenticationService
{
    Task<bool> VerifyUser(LoginRequest request);

    Task<string?> GenerateToken(string username);
}