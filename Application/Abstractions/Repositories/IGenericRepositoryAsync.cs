namespace Application.Abstractions.Repositories;

public interface IGenericRepositoryAsync<T> where T : class
{
    Task<bool> CreateAsync(T entity);
    
    Task<T?> GetByIdAsync(int id);
   
    Task<IEnumerable<T>> GetAllAsync();
    
    Task<bool> UpdateAsync(T entity);
    
    Task<bool> DeleteByIdAsync(int id);
}