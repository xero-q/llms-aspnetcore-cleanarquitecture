using Application.Abstractions.Repositories;
using Infrastructure.Database.Persistence;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Infrastructure.Repositories;

public class GenericRepositoryAsync<T>(LLMDbContext context):IGenericRepositoryAsync<T> where T:Entity
{
    public virtual async Task<bool> CreateAsync(T entity, CancellationToken cancellationToken=default)
    {
        context.Set<T>().Add(entity);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0;
    }

    public virtual async Task<T?> GetByIdAsync(int id,CancellationToken cancellationToken=default)
    {
        return await context.Set<T>().FindAsync(id, cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken=default)
    {
        return await context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public virtual async Task<bool> UpdateAsync(T entity,CancellationToken cancellationToken=default)
    {
        var existing = await context.Set<T>().FindAsync(entity.Id,cancellationToken);
        if (existing == null)
            return false;

        context.Entry(existing).CurrentValues.SetValues(entity);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0;
    }

    public virtual async Task<bool> DeleteByIdAsync(int id,CancellationToken cancellationToken=default)
    {
        var entity = await context.Set<T>().FindAsync(id, cancellationToken);
        if (entity == null)
            return false;

        context.Set<T>().Remove(entity);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0;
    }
}