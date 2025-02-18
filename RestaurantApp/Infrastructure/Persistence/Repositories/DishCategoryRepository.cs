using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class DishCategoryRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory) : IDishCategoryRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory = dbContextFactory;

    public async Task AddAsync(DishCategory dishSubcategory)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        dbContext.DishCategories.Add(dishSubcategory);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<DishCategory>> GetAllAsync()
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.DishCategories.ToListAsync();
    }

    public async Task<DishCategory?> GetByIdAsync(int id)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        return dbContext.DishCategories.SingleOrDefault(dt => dt.Id == id);
    }

    public async Task RemoveAsync(DishCategory dishSubcategory)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();

        dbContext.DishCategories.Remove(dishSubcategory);
    }
}
