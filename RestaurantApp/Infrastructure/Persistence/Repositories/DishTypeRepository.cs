using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class DishTypeRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory) : IDishTypeRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory = dbContextFactory;

    public async Task AddAsync(DishType dishType)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        dbContext.DishTypes.Add(dishType);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<DishType>> GetAllAsync()
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.DishTypes.ToListAsync();
    }

    public async Task<DishType?> GetByIdAsync(int id)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        return dbContext.DishTypes.SingleOrDefault(dt => dt.Id == id);
    }

    public async Task RemoveAsync(DishType dishType)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        dbContext.DishTypes.Remove(dishType);
    }
}
