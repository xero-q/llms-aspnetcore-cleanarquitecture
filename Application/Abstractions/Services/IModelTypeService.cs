using Domain.Entities;

namespace Application.Services;

public interface IModelTypeService
{
    Task<bool> CreateAsync(ModelType modelType);

    Task<ModelType?> GetByIdAsync(int id);

    Task<IEnumerable<ModelType>> GetAllAsync();
}