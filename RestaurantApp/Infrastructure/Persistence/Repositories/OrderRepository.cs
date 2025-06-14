

using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Enums;
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

        return await context.Orders
            .Include(x => x.EventType)
            .Include(x => x.OrderDays)
            .ToListAsync();
    }

    public async Task<List<DateTime>> GetBookedDates()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        var tomorrow = DateTime.Today.AddDays(1);
        return await context.OrderDays
            .Where(od => od.Date.Date >= tomorrow)
            .Select(od => od.Date.Date)
            .Distinct()
            .ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        return await context.Orders
            .Include(x => x.EventType)
            .Include(x => x.OrderDays)
                .ThenInclude(od => od.OrderMenuItems)
                .ThenInclude(omi => omi.FoodItem)
            .ThenInclude(fm => fm.Category)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Order>> GetByStatusAsync(OrderStatusEnum status)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        return await context.Orders
            .Where(x => x.Status == status)
            .Include(x => x.EventType)
            .Include(x => x.OrderDays)
                    .ThenInclude(od => od.OrderMenuItems)
                        .ThenInclude(omi => omi.FoodItem)
            .ToListAsync();
    }

    public async Task<List<Order>> GetByUserIdAsync(int userId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        return await context.Orders.Where(x => x.UserId == userId)
            .Include(x => x.EventType)
            .Include(x => x.OrderDays)
                    .ThenInclude(od => od.OrderMenuItems)
                        .ThenInclude(omi => omi.FoodItem)
            .ToListAsync();
    }

    public async Task<List<Order>> GetCrossedOrdersAsync(int orderId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        var targetOrderDays = await context.OrderDays
            .Where(od => od.OrderId == orderId)
            .Select(od => od.Date)
            .ToListAsync();

        if (targetOrderDays.Count == 0)
            return [];

        return await context.Orders
            .Include(o => o.OrderDays)
            .Where(o => o.Id != orderId)
            .Where(o => o.Status == OrderStatusEnum.Created)
            .Where(o => o.OrderDays.Any(od => targetOrderDays.Contains(od.Date)))
            .ToListAsync();
    }

    public async Task<Dictionary<DateTime, List<Order?>>> GetUnprocessedGroupedByDateCrossing()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        return await context.OrderDays
            .Where(x => x.Order!.Status == OrderStatusEnum.Created)
            .GroupBy(od => od.Date.Date)
            .ToDictionaryAsync(g => g.Key, g => g.Select(od => od.Order).Distinct().ToList());
    }

    public async Task RemoveAsync(Order order)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        context.Orders.Remove(order);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        context.Orders.Update(order);
        await context.SaveChangesAsync();
    }
}
