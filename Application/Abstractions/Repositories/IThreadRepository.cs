namespace Application.Abstractions.Repositories;
using Thread = Domain.Entities.Thread;

public interface IThreadRepository:IGenericRepositoryAsync<Thread>
{
    Task<bool> TitleExistsAsync(string title);
    
    Task<IEnumerable<Thread>> GetAllByUserIdAsync(int userId, int pageNumber = 1, int pageSize = 20);
    
    Task<int> GetTotalThreadsCount(int userId);
    
    Task<Thread?> GetByIdAsync(int threadId, bool includeJoins = false);
}