
using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class FoodItemRepository : IFoodItemRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory;

    public FoodItemRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }


    public async Task<List<FoodItem>> GetAllByCategoryIdAsync(int categoryId, bool isEnabled)
    {
        using var context = _dbContextFactory.CreateDbContext();

        return await context.FoodItems
            .Where(x => x.CategoryId == categoryId && x.IsEnabled == isEnabled)
            .Include(x => x.Category)
            .ToListAsync();

    }

    public async Task<FoodItem?> GetByIdAsync(int id)
    {
        using var context = _dbContextFactory.CreateDbContext();

        return await context.FoodItems
            .Include(x => x.Category)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
}
