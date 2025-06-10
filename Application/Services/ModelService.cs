using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Domain.Entities;
using FluentValidation;

namespace Application.Services;

public class ModelService(IModelRepository modelRepository, IValidator<Model> validator):IModelService
{
    public async Task<bool> CreateAsync(Model model)
    {
        await validator.ValidateAndThrowAsync(model);
        return await modelRepository.CreateAsync(model);
    }

    public async Task<IEnumerable<Model>> GetAllAsync()
    {
        return await modelRepository.GetAllAsync();
    }

    public async Task<Model?> GetByIdAsync(int id)
    {
        return await modelRepository.GetByIdAsync(id);
    }
}