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

    public async Task<IEnumerable<Thread>> GetAllByUserIdAsync(int userId)
    {
        return await context.Threads.Where(t => t.UserId == userId).AsNoTracking().ToListAsync();
    }
}