using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Domain.Entities;
using FluentValidation;

namespace Application.Services;

public class ModelTypeService(IModelTypeRepository modelTypeRepository, IValidator<ModelType> validator):IModelTypeService
{
    public async Task<bool> CreateAsync(ModelType modelType, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(modelType, cancellationToken);
        return await modelTypeRepository.CreateAsync(modelType,cancellationToken);
    }

    public async Task<ModelType?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await modelTypeRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<ModelType>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await modelTypeRepository.GetAllAsync(cancellationToken);
    }
}