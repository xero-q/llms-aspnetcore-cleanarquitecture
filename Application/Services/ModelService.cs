using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Domain.Entities;
using FluentValidation;

namespace Application.Services;

public class ModelService(IModelRepository modelRepository, IValidator<Model> validator):IModelService
{
    public async Task<bool> CreateAsync(Model model, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(model, cancellationToken);
        return await modelRepository.CreateAsync(model, cancellationToken);
    }

    public async Task<IEnumerable<Model>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await modelRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Model?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await modelRepository.GetByIdAsync(id, cancellationToken);
    }
}