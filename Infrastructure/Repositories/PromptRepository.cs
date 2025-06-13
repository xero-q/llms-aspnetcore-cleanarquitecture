using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Database.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PromptRepository(LLMDbContext context) : GenericRepositoryAsync<Prompt>(context), IPromptRepository
{
   public async Task<IEnumerable<Prompt>> GetAllAsyncByThread(int threadId, CancellationToken cancellationToken = default)
    {
        return await context.Prompts.Where(p=>p.ThreadId == threadId).OrderBy(p=>p.CreatedAt).AsNoTracking().ToListAsync(cancellationToken);
    }
}