using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Database.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ModelRepository(LLMDbContext context) : GenericRepositoryAsync<Model>(context), IModelRepository
{
    public override async Task<IEnumerable<Model>> GetAllAsync()
    {
        return await context.Models.Include(m=>m.Provider).AsNoTracking().ToListAsync();
    }
}