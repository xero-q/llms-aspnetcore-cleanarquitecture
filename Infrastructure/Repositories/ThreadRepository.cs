using Application.Abstractions.Repositories;
using Infrastructure.Database.Persistence;
using Microsoft.EntityFrameworkCore;
using Thread = Domain.Entities.Thread;

namespace Infrastructure.Repositories;

public class ThreadRepository(LLMDbContext context):GenericRepositoryAsync<Thread>(context),IThreadRepository
{
    public async Task<bool> TitleExistsAsync(string title)
    {
        return await context.Threads.AnyAsync(t => t.Title == title);
    }

    public async Task<IEnumerable<Thread>> GetAllByUserIdAsync(int userId, int pageNumber = 1, int pageSize = 20)
    {
        return await context.Threads
            .Include(t => t.Model)
            .ThenInclude(m => m.Provider)
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> GetTotalThreadsCount(int userId)
    {
        var query = context.Threads
            .Where(t => t.UserId == userId)
            .AsNoTracking();

        return await query.CountAsync();
    }

    public async Task<Thread?> GetByIdAsync(int threadId, bool includeJoins = false)
    {
        if (includeJoins)
        {
            return  await context.Threads.Include(t => t.Model).ThenInclude(m => m.Provider).FirstOrDefaultAsync(t => t.Id == threadId);
        }

        return await context.Threads.FindAsync(threadId);
    }
}