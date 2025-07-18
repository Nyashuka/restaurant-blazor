using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class DishCategoryRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory) : IDishCategoryRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory = dbContextFactory;

    public async Task AddAsync(DishCategory dishCategory)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        dbContext.DishCategories.Add(dishCategory);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<DishCategory>> GetAllAsync(bool getDisabled)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.DishCategories
            .Where(x => getDisabled || (!getDisabled && x.IsEnabled))
            .ToListAsync();
    }

    public async Task<DishCategory?> GetByIdAsync(int id)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        return dbContext.DishCategories.SingleOrDefault(dt => dt.Id == id);
    }

    public async Task RemoveAsync(DishCategory dishCategory)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        dbContext.DishCategories.Remove(dishCategory);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(DishCategory dishCategory)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        dbContext.DishCategories.Update(dishCategory);
        await dbContext.SaveChangesAsync();
    }
}
