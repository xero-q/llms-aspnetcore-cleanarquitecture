using Thread = Domain.Entities.Thread;

namespace Application.Abstractions.Services;

public interface IThreadService
{
    Task<bool> CreateAsync(Thread model);
    
    Task<bool> TitleExistsAsync(int userId, string title);
    
    Task<IEnumerable<Thread>> GetAllByUserIdAsync(int userId);

    Task<Dictionary<string, List<Thread>>> GetAllByUserIdGroupedByDateAsync(int userId, int pageNumber = 1, int pageSize = 20);

    Task<int> GetTotalThreadsCount(int userId);

    Task<Thread?> GetByIdAsyncWithJoins(int threadId);
    
    Task<bool> DeleteByIdAsync(int id);
}