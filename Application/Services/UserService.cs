using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Helpers;
using Domain.Entities;
using FluentValidation;

namespace Application.Services;

public class UserService(IUserRepository userRepository, IValidator<User> validator) : IUserService
{
    public async Task<bool> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        await validator.ValidateAndThrowAsync(user, cancellationToken);
        var hashedUser = new User
        {
            Id = user.Id,
            Username = user.Username,
            Password = PasswordHelper.HashPassword(user.Password)
        };

        return await userRepository.CreateAsync(hashedUser, cancellationToken);
    }
    
    public async Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken = default)
    {
        return await userRepository.UsernameExistsAsync(username, cancellationToken);
    }

    public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await userRepository.GetByUsernameAsync(username, cancellationToken);
    }

    public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await userRepository.GetByIdAsync(id, cancellationToken);
    }
}