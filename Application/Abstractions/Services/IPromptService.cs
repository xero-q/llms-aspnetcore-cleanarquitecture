using Application.Abstractions.Repositories;
using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IPromptService
{
    Task<IEnumerable<Prompt>> GetAllAsyncByThread(int threadId, CancellationToken cancellationToken = default);
    
    Task<Prompt?> AddPromptAsync(int threadId, string promptText, CancellationToken cancellationToken = default);
}