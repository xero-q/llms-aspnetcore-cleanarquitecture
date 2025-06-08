using Application.Helpers;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository:IUserRepository
{
    private readonly LLMDbContext _context;
    private readonly IValidator<User> _validator;

    public UserRepository(LLMDbContext context, IValidator<User> validator)
    {
        _context = context;
        _validator = validator;
    }
    
    public async Task<bool> CreateAsync(User user)
    {
        await _validator.ValidateAndThrowAsync(user);
        var hashedUser = new User
        {
            Id = user.Id,
            Username = user.Username,
            Password = PasswordHelper.HashPassword(user.Password)
        };
            
        _context.Users.Add(hashedUser);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
    
    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _context.Users.AnyAsync(u => u.Username == username);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}