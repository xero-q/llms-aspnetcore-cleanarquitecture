using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ModelTypeRepository(LLMDbContext context) : IModelTypeRepository
{
    public async Task<bool> CreateAsync(ModelType modelType)
    {
        context.ModelTypes.Add(modelType);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<ModelType?> GetByIdAsync(int id)
    {
        return await context.ModelTypes.FindAsync(id);
    }

    public async Task<IEnumerable<ModelType>> GetAllAsync()
    {
        return await context.ModelTypes.AsNoTracking().ToListAsync();
    }

    public async Task<bool> UpdateAsync(ModelType modelType)
    {
        var existing = await context.ModelTypes.FindAsync(modelType.Id);
        if (existing == null)
            return false;

        context.Entry(existing).CurrentValues.SetValues(modelType);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var modelType = await context.ModelTypes.FindAsync(id);
        if (modelType == null)
            return false;

        context.ModelTypes.Remove(modelType);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }
}