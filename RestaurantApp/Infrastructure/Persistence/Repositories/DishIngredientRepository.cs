using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class DishIngredientRepository : IDishIngredientRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory;

    public DishIngredientRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task AddAsync(DishIngredient dishIngredient)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.DishIngredients.Add(dishIngredient);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(List<DishIngredient> dishIngredients)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.DishIngredients.AddRange(dishIngredients);
        await context.SaveChangesAsync();
    }

    public async Task<List<DishIngredient>> GetAllDishIngredientsAsync(int dishId)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context.DishIngredients.Where(x => x.DishId == dishId).ToListAsync();
    }

    public async Task<DishIngredient?> GetByIdAsync(int id)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context.DishIngredients.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task RemoveAsync(DishIngredient dishIngredient)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.DishIngredients.Remove(dishIngredient);
        await context.SaveChangesAsync();
    }

    public async Task RemoveRangeAsync(List<DishIngredient> dishIngredients)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.DishIngredients.RemoveRange(dishIngredients);
        await context.SaveChangesAsync();
    }
}