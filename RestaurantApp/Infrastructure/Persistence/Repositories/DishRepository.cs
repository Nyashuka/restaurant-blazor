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

    public async Task<List<Dish>> GetAllAsync(bool getDisabled)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context.Dishes
            .Include(x => x.Category)
            .Where(x =>
                (getDisabled && (!x.Category.IsEnabled || !x.IsEnabled)) ||
                (!getDisabled && x.Category.IsEnabled && x.IsEnabled)
            )
            .ToListAsync();
    }

    public async Task<List<Dish>> GetByCategoryAsync(int categoryId, bool getDisabled)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context.Dishes
            .Include(x => x.Category)
            .Where(x => x.CategoryId == categoryId &&
                ((getDisabled && (!x.Category.IsEnabled || !x.IsEnabled)) ||
                (!getDisabled && x.Category.IsEnabled && x.IsEnabled))
                )
            .ToListAsync();
    }

    public async Task<Dish?> GetByIdAsync(int id)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        return await context.Dishes
            .Where(x => x.Id == id)
            .Include(x => x.Category)
            .Include(x => x.Ingredients)
            .SingleOrDefaultAsync();
    }

    public async Task RemoveAsync(Dish dish)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.Dishes.Remove(dish);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Dish dish)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.Dishes.Update(dish);
        await context.SaveChangesAsync();
    }
}