using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IUserService
{
    Task<bool> CreateAsync(User user);

    Task<bool> UsernameExistsAsync(string username);

    Task<User?> GetByUsernameAsync(string username);
    
    Task<User?> GetByIdAsync(int id);
}