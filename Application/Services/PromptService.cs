using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Domain.Entities;

namespace Application.Services;

public class PromptService(IPromptRepository promptRepository): IPromptService
{
    public async Task<IEnumerable<Prompt>> GetAllAsyncByThread(int threadId)
    {
        return await promptRepository.GetAllAsyncByThread(threadId);
    }
}