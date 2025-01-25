
using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory;

    public MenuItemRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task AddAsync(MenuItem menuItem)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.MenuItems.Add(menuItem);
        await context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(List<MenuItem> menuItems)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.MenuItems.AddRange(menuItems);
        await context.SaveChangesAsync();
    }

    public async Task<List<MenuItem>> GetAllAsync()
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context.MenuItems.ToListAsync();
    }

    public async Task<MenuItem?> GetByIdAsync(int id)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context.MenuItems.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task RemoveAsync(MenuItem menuItem)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.MenuItems.Remove(menuItem);
        await context.SaveChangesAsync();
    }
}