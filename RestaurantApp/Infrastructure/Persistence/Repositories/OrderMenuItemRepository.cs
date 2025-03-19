using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class OrderMenuItemRepository : IOrderMenuItemRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory;

    public OrderMenuItemRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task AddAsync(OrderMenuItem item)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        context.OrderMenuItems.Add(item);
        await context.SaveChangesAsync();
    }

    public async Task<List<OrderMenuItem>> GetAllAsync()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        return await context.OrderMenuItems
            .Include(x => x.FoodItem)
            .Include(x => x.OrderDay)
            .ToListAsync();
    }

    public async Task<List<OrderMenuItem>> GetAllByOrderDayIdAsync(int orderDayId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        return await context.OrderMenuItems
            .Include(x => x.FoodItem)
            .Include(x => x.OrderDay)
            .Where(x => x.OrderDayId == orderDayId)
            .ToListAsync();
    }

    public async Task<OrderMenuItem?> GetByIdAsync(int id)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        return await context.OrderMenuItems
            .Include(x => x.FoodItem)
            .Include(x => x.OrderDay)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task RemoveAsync(OrderMenuItem item)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        context.OrderMenuItems.Remove(item);
        await context.SaveChangesAsync();
    }
}