using Application.Abstractions.Repositories;
using Application.Helpers;
using Domain.Entities;
using FluentValidation;

namespace Application.Services;

public class UserService(IUserRepository userRepository, IValidator<User> validator) : IUserService
{
    public async Task<bool> CreateAsync(User user)
    {
        await validator.ValidateAndThrowAsync(user);
        var hashedUser = new User
        {
            Id = user.Id,
            Username = user.Username,
            Password = PasswordHelper.HashPassword(user.Password)
        };

        return await userRepository.CreateAsync(hashedUser);
    }
    
    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await userRepository.UsernameExistsAsync(username);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await userRepository.GetByUsernameAsync(username);
    }
}