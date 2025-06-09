using Domain.Entities;

namespace Application.Services;

public interface IModelService
{
    Task<bool> CreateAsync(Model model);

    Task<IEnumerable<Model>> GetAllAsync();

    Task<Model?> GetByIdAsync(int id);
}