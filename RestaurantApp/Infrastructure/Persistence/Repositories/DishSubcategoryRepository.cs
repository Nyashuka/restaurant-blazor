using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class DishSubcategoryRepository : IDishCategoryRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory;

    public DishSubcategoryRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task AddAsync(DishCategory dishSubcategory)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        
        dbContext.Add(dishSubcategory);
        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(DishCategory dishSubcategory)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        
        dbContext.Remove(dishSubcategory);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<DishCategory>> GetAllAsync()
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        
        return await dbContext.DishCategories.ToListAsync();
    }

    public async Task<DishCategory?> GetByIdAsync(int id)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        
        return await dbContext.DishCategories.FindAsync(id);
    }
}