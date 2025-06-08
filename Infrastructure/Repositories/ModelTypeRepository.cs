using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repositories;

public class ModelTypeRepository:IModelTypeRepository
{
    private readonly LLMDbContext _context;
    private readonly IValidator<ModelType> _validator;

    public ModelTypeRepository(LLMDbContext context, IValidator<ModelType> validator)
    {
        _context = context;
        _validator = validator;
    }
    
    public async Task<bool> CreateAsync(ModelType modelType)
    {
        await _validator.ValidateAndThrowAsync(modelType);
        _context.ModelTypes.Add(modelType);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<ModelType?> GetByIdAsync(int id)
    {
        return await _context.ModelTypes.FindAsync(id);
    }

    public async Task<IEnumerable<ModelType>> GetAllAsync()
    {
        return await _context.ModelTypes.AsNoTracking().ToListAsync();
    }

    public async Task<bool> UpdateAsync(ModelType modelType)
    {
        var existing = await _context.ModelTypes.FindAsync(modelType.Id);
        if (existing == null)
            return false;

        _context.Entry(existing).CurrentValues.SetValues(modelType);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var modelType = await _context.ModelTypes.FindAsync(id);
        if (modelType == null)
            return false;

        _context.ModelTypes.Remove(modelType);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}