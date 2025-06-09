using Application.Abstractions.Repositories;
using Infrastructure.Database.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepositoryAsync<T>(LLMDbContext context):IGenericRepositoryAsync<T> where T:class
{
    public virtual async Task<bool> CreateAsync(T entity)
    {
        context.Set<T>().Add(entity);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().AsNoTracking().ToListAsync();
    }

    public virtual async Task<bool> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<bool> DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}