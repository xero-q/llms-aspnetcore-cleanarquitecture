using Domain.Entities;

namespace Domain.Interfaces;

public interface IModelTypeRepository
{
    Task<bool> CreateAsync(ModelType modelType);
    
    Task<ModelType?> GetByIdAsync(int id);
   
    Task<IEnumerable<ModelType>> GetAllAsync();
    
    Task<bool> UpdateAsync(ModelType modelType);
    
    Task<bool> DeleteByIdAsync(int id);
}