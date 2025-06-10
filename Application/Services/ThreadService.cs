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

    public async Task<bool> TitleExistsAsync(string title)
    {
        return await threadRepository.TitleExistsAsync(title);
    }

    public async Task<IEnumerable<Thread>> GetAllByUserIdAsync(int userId)
    {
        return await threadRepository.GetAllByUserIdAsync(userId);
    }
}