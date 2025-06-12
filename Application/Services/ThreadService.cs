using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using FluentValidation;
using Thread = Domain.Entities.Thread;

namespace Application.Services;

public class ThreadService(IThreadRepository threadRepository,IValidator<Thread> validator):IThreadService
{
    public async Task<bool> CreateAsync(Thread thread)
    {
        await validator.ValidateAndThrowAsync(thread);
        return await threadRepository.CreateAsync(thread);
    }

    public async Task<bool> TitleExistsAsync(int userId, string title)
    {
        return await threadRepository.TitleExistsAsync(userId, title);
    }

    public async Task<IEnumerable<Thread>> GetAllByUserIdAsync(int userId)
    {
        return await threadRepository.GetAllByUserIdAsync(userId);
    }
    
    public async Task<Dictionary<string, List<Thread>>> GetAllByUserIdGroupedByDateAsync(int userId,int pageNumber = 1, int pageSize = 20)
    {
        var threads = await threadRepository.GetAllByUserIdAsync(userId, pageNumber, pageSize);

        return threads
            .GroupBy(t => t.CreatedAt.Date.ToString("yyyy-MM-dd")) 
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public async Task<int> GetTotalThreadsCount(int userId)
    {
        return await threadRepository.GetTotalThreadsCount(userId);
    }

    public async Task<Thread?> GetByIdAsyncWithJoins(int threadId)
    {
        return await threadRepository.GetByIdAsync(threadId, true);
    }
}