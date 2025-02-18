
using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class OrderDayRepository : IOrderDayRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory;

    public OrderDayRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task AddAsync(OrderDay orderDay)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        context.OrderDays.Add(orderDay);
        await context.SaveChangesAsync();
    }

    public async Task<List<OrderDay>> GetAllAsync()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        return await context.OrderDays.ToListAsync();
    }

    public async Task<OrderDay?> GetByIdAsync(int id)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        return await context.OrderDays.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task RemoveAsync(OrderDay orderDay)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        context.OrderDays.Remove(orderDay);
        await context.SaveChangesAsync();
    }
}
