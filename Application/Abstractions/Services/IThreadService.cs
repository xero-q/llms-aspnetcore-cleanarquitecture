using Thread = Domain.Entities.Thread;

namespace Application.Abstractions.Services;

public interface IThreadService
{
    Task<bool> CreateAsync(Thread model, CancellationToken cancellationToken = default);
    
    Task<bool> TitleExistsAsync(int userId, string title, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<Thread>> GetAllByUserIdAsync(int userId,  int pageNumber = 1, int pageSize = 20, CancellationToken cancellationToken = default);

    Task<Dictionary<string, List<Thread>>> GetAllByUserIdGroupedByDateAsync(int userId, int pageNumber = 1, int pageSize = 20, CancellationToken cancellationToken = default);

    Task<int> GetTotalThreadsCount(int userId, CancellationToken cancellationToken = default);

    Task<Thread?> GetByIdAsyncWithJoins(int threadId, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}