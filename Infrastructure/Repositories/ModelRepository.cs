using Domain.Interfaces;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ModelRepository(LLMDbContext context, IValidator<Model> validator) : IModelRepository
{
    public async Task<bool> CreateAsync(Model model)
    {
        await validator.ValidateAndThrowAsync(model);
        context.Models.Add(model);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<Model?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
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