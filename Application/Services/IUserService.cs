using Domain.Entities;

namespace Application.Services;

public interface IUserService
{
    Task<bool> CreateAsync(User user);

    Task<bool> UsernameExistsAsync(string username);

    Task<User?> GetByUsernameAsync(string username);
}