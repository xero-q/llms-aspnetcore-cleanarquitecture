using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface IPromptRepository:IGenericRepositoryAsync<Prompt>
{
    Task<IEnumerable<Prompt>> GetAllAsyncByThread(int threadId);
}