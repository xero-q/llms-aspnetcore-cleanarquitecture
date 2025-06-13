using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using FluentValidation;
using Thread = Domain.Entities.Thread;

namespace Application.Services;

public class ThreadService(IThreadRepository threadRepository,IValidator<Thread> validator):IThreadService
{
    public async Task<bool> CreateAsync(Thread thread, CancellationToken cancellationToken = default)
    {
        await validator.ValidateAndThrowAsync(thread, cancellationToken);
        return await threadRepository.CreateAsync(thread, cancellationToken);
    }

    public async Task<bool> TitleExistsAsync(int userId, string title, CancellationToken cancellationToken = default)
    {
        return await threadRepository.TitleExistsAsync(userId, title, cancellationToken);
    }

    public async Task<IEnumerable<Thread>> GetAllByUserIdAsync(int userId,  int pageNumber = 1, int pageSize = 20,CancellationToken cancellationToken = default)
    {
        return await threadRepository.GetAllByUserIdAsync(userId, pageNumber, pageSize, cancellationToken);
    }
    
    public async Task<Dictionary<string, List<Thread>>> GetAllByUserIdGroupedByDateAsync(int userId,int pageNumber = 1, int pageSize = 20, CancellationToken cancellationToken = default)
    {
        var threads = await threadRepository.GetAllByUserIdAsync(userId, pageNumber, pageSize, cancellationToken);

        return threads
            .GroupBy(t => t.CreatedAt.Date.ToString("yyyy-MM-dd")) 
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public async Task<int> GetTotalThreadsCount(int userId, CancellationToken cancellationToken = default)
    {
        return await threadRepository.GetTotalThreadsCount(userId, cancellationToken);
    }

    public async Task<Thread?> GetByIdAsyncWithJoins(int threadId, CancellationToken cancellationToken = default)
    {
        return await threadRepository.GetByIdAsync(threadId, true, cancellationToken);
    }

    public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
       return await threadRepository.DeleteByIdAsync(id, cancellationToken);
    }
}