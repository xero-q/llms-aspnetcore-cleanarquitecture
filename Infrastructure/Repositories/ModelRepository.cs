using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Database.Persistence;
namespace Infrastructure.Repositories;

public class ModelRepository(LLMDbContext context) : GenericRepositoryAsync<Model>(context), IModelRepository
{
    
}