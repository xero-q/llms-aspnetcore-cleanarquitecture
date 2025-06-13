using Application.Contracts.Requests;
using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IAuthenticationService
{
    Task<User?> AuthenticateUser(LoginRequest request, CancellationToken cancellationToken = default);

    Task<string?> GenerateToken(string username, bool isAdmin, CancellationToken cancellationToken = default);
}