using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IModelService
{
    Task<bool> CreateAsync(Model model, CancellationToken cancellationToken);

    Task<IEnumerable<Model>> GetAllAsync(CancellationToken cancellationToken);

    Task<Model?> GetByIdAsync(int id, CancellationToken cancellationToken);
}