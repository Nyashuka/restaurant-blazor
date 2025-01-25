using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory;

    public MenuRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task AddAsync(Menu menu)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        _ = context.Menus.Add(menu);
        _ = await context.SaveChangesAsync();
    }

    public async Task<List<Menu>> GetAllAsync()
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context.Menus.Include(x => x.EventType).ToListAsync();
    }

    public async Task<Menu?> GetByIdAsync(int id)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context.Menus.Include(x => x.EventType).SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task RemoveAsync(Menu menu)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        _ = context.Menus.Remove(menu);
        _ = await context.SaveChangesAsync();
    }
}