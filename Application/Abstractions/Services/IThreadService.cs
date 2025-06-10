using Thread = Domain.Entities.Thread;

namespace Application.Abstractions.Services;

public interface IThreadService
{
    Task<bool> CreateAsync(Thread model);
    
    Task<bool> TitleExistsAsync(string title);
}