using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class EventTypeRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory) : IEventTypeRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory = dbContextFactory;

    public async Task AddAsync(EventType eventType)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.EventTypes.Add(eventType);
        await context.SaveChangesAsync();
    }

    public async Task<List<EventType>> GetAllAsync()
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context.EventTypes.ToListAsync();
    }

    public async Task<EventType?> GetByIdAsync(int id)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return context.EventTypes.SingleOrDefault(et => et.Id == id);
    }

    public async Task UpdateAsync(EventType eventType)
    {
        await using var context = _dbContextFactory.CreateDbContext();
        
        context.EventTypes.Update(eventType);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(EventType eventType)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.EventTypes.Remove(eventType);
        await context.SaveChangesAsync();
    }
}