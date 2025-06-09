using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

public class ModelTypeRepository(LLMDbContext context) : GenericRepositoryAsync<ModelType>(context), IModelTypeRepository
{
   public override async Task<bool> UpdateAsync(ModelType modelType)
    {
        var existing = await context.ModelTypes.FindAsync(modelType.Id);
        if (existing == null)
            return false;

        context.Entry(existing).CurrentValues.SetValues(modelType);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public override async Task<bool> DeleteByIdAsync(int id)
    {
        var modelType = await context.ModelTypes.FindAsync(id);
        if (modelType == null)
            return false;

        context.ModelTypes.Remove(modelType);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }
}