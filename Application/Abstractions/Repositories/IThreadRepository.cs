namespace Application.Abstractions.Repositories;
using Thread = Domain.Entities.Thread;

public interface IThreadRepository:IGenericRepositoryAsync<Thread>
{
    Task<bool> TitleExistsAsync(string title);
    
    Task<IEnumerable<Thread>> GetAllByUserIdAsync(int userId);
}