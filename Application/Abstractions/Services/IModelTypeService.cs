using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IModelTypeService
{
    Task<bool> CreateAsync(ModelType modelType, CancellationToken cancellationToken);

    Task<ModelType?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<ModelType>> GetAllAsync(CancellationToken cancellationToken);
}