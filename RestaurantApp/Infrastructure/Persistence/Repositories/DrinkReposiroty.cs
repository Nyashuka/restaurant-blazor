
using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class DrinkRepository : IDrinkRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory;

    public DrinkRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task AddAsync(Drink drink)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.Drinks.Add(drink);
        await context.SaveChangesAsync();
    }

    public async Task<List<Drink>> GetAllAsync(bool getDisabled)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context.Drinks
            .Where(x => x.IsEnabled != getDisabled)
            .Include(x => x.Category).ToListAsync();
    }

    public async Task<List<Drink>> GetByCategoryAsync(int categoryId)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context.Drinks
            .Where(x => x.CategoryId == categoryId)
            .Include(x => x.Category).ToListAsync();
    }

    public async Task<Drink?> GetByIdAsync(int id)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context
            .Drinks
            .Include(x => x.Category)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task RemoveAsync(Drink drink)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.Drinks.Remove(drink);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Drink drink)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.Drinks.Update(drink);
        await context.SaveChangesAsync();
    }
}
