using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Database.Persistence;

namespace Infrastructure.Repositories;

public class ModelTypeRepository(LLMDbContext context) : GenericRepositoryAsync<ModelType>(context), IModelTypeRepository
{
   
}