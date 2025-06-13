namespace Application.Abstractions.Repositories;
using Thread = Domain.Entities.Thread;

public interface IThreadRepository:IGenericRepositoryAsync<Thread>
{
    Task<bool> TitleExistsAsync(int userId, string title, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<Thread>> GetAllByUserIdAsync(int userId, int pageNumber = 1, int pageSize = 20, CancellationToken cancellationToken = default);
    
    Task<int> GetTotalThreadsCount(int userId, CancellationToken cancellationToken = default);
    
    Task<Thread?> GetByIdAsync(int threadId, bool includeJoins = false, CancellationToken cancellationToken = default);
}