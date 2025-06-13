using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface IUserRepository:IGenericRepositoryAsync<User>
{
  Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken = default);

  Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);
}