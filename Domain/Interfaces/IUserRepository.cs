using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<bool> CreateAsync(User user);

    Task<bool> UsernameExistsAsync(string username);
    
    Task<User?> GetByIdAsync(int id);
    
    Task<User?> GetByUsernameAsync(string username);
   
    Task<IEnumerable<User>> GetAllAsync();
    
    Task<bool> UpdateAsync(User user);
    
    Task<bool> DeleteByIdAsync(int id);
}