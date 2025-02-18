
using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory;

    public OrderRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task AddAsync(Order order)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        context.Orders.Add(order);
        await context.SaveChangesAsync();
    }

    public async Task<List<Order>> GetAllAsync()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        return await context.Orders.ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        return await context.Orders.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task RemoveAsync(Order order)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        context.Orders.Remove(order);
        await context.SaveChangesAsync();
    }
}
