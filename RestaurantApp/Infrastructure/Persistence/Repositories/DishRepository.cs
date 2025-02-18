using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class DishRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory) : IDishRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory = dbContextFactory;

    public async Task AddAsync(Dish dish)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.Dishes.Add(dish);
        await context.SaveChangesAsync();
    }

    public async Task<List<Dish>> GetAllAsync()
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context.Dishes.Include(x => x.DishCategory).ToListAsync();
    }

    public async Task<List<Dish>> GetByCategoryAsync(int categoryId)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context.Dishes.Where(x => x.DishCategoryId == categoryId).Include(x => x.DishCategory).ToListAsync();
    }

    public async Task<Dish?> GetByIdAsync(int id)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return context.Dishes.Include(x => x.DishCategory).SingleOrDefault(x => x.Id == id);
    }

    public async Task RemoveAsync(Dish dish)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.Dishes.Remove(dish);
        await context.SaveChangesAsync();
    }
}