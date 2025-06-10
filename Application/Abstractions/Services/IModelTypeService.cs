using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IModelTypeService
{
    Task<bool> CreateAsync(ModelType modelType);

    Task<ModelType?> GetByIdAsync(int id);

    Task<IEnumerable<ModelType>> GetAllAsync();
}