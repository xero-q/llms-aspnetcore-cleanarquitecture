using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IUserService
{
    Task<bool> CreateAsync(User user, CancellationToken cancellationToken = default);

    Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken = default);

    Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);
    
    Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}