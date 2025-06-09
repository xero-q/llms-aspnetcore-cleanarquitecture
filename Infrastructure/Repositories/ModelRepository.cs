using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ModelRepository(LLMDbContext context) : IModelRepository
{
    public async Task<bool> CreateAsync(Model model)
    {
        context.Models.Add(model);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<Model?> GetByIdAsync(int id)
    {
        return await context.Models.FindAsync(id);
    }

    public async Task<IEnumerable<Model>> GetAllAsync()
    {
        return await context.Models.AsNoTracking().ToListAsync();
    }

    public async Task<bool> UpdateAsync(Model modelType)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}