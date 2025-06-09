using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository(LLMDbContext context) : GenericRepositoryAsync<User>(context), IUserRepository
{
   
    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await context.Users.AnyAsync(u => u.Username == username);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
    }
}