using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;

namespace Application.Services;

public class ModelTypeService(IModelTypeRepository modelTupeRepository, IValidator<ModelType> validator):IModelTypeService
{
    public async Task<bool> CreateAsync(ModelType modelType)
    {
        await validator.ValidateAndThrowAsync(modelType);
        return await modelTupeRepository.CreateAsync(modelType);
    }

    public async Task<ModelType?> GetByIdAsync(int id)
    {
        return await modelTupeRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<ModelType>> GetAllAsync()
    {
        return await modelTupeRepository.GetAllAsync();
    }
}