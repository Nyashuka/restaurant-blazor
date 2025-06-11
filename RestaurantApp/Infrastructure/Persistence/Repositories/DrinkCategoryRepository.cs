
using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class DrinkCategoryRepository : IDrinkCategoryRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory;

    public DrinkCategoryRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task AddAsync(DrinkCategory drinkCategory)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        dbContext.DrinkCategories.Add(drinkCategory);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<DrinkCategory>> GetAllAsync()
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.DrinkCategories.ToListAsync();
    }

    public async Task<DrinkCategory?> GetByIdAsync(int id)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.DrinkCategories.SingleOrDefaultAsync(dt => dt.Id == id);
    }

    public async Task RemoveAsync(DrinkCategory drinkCategory)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        dbContext.DrinkCategories.Remove(drinkCategory);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(DrinkCategory category)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        dbContext.DrinkCategories.Update(category);
        await dbContext.SaveChangesAsync();
    }
}
