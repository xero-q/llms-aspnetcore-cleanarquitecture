using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Domain.Entities;
using FluentValidation;

namespace Application.Services;

public class ModelTypeService(IModelTypeRepository modelTypeRepository, IValidator<ModelType> validator):IModelTypeService
{
    public async Task<bool> CreateAsync(ModelType modelType)
    {
        await validator.ValidateAndThrowAsync(modelType);
        return await modelTypeRepository.CreateAsync(modelType);
    }

    public async Task<ModelType?> GetByIdAsync(int id)
    {
        return await modelTypeRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<ModelType>> GetAllAsync()
    {
        return await modelTypeRepository.GetAllAsync();
    }
}