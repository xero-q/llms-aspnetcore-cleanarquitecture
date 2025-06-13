namespace Application.Abstractions.Repositories;

public interface IGenericRepositoryAsync<T> where T : class
{
    Task<bool> CreateAsync(T entity, CancellationToken cancellationToken = default);
    
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
   
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    
    Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}