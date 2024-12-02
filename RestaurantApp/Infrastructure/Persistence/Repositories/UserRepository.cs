
using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbFactory;

    public UserRepository(IDbContextFactory<RestaurantDbContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task AddAsync(User user)
    {
        using (var dbContext = _dbFactory.CreateDbContext())
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(User user)
    {
        using (var dbContext = _dbFactory.CreateDbContext())
        {
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        using (var dbContext = _dbFactory.CreateDbContext())
        {
            return await dbContext.Users
                .FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        using (var dbContext = _dbFactory.CreateDbContext())
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }

    public async Task UpdateAsync(User user)
    {
        using (var dbContext = _dbFactory.CreateDbContext())
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
        }
    }
}