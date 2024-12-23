using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Enums;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Configurations;
using RestaurantApp.Infrastructure.Security;

namespace RestaurantApp.Infrastructure.Persistence.DbContexts;

public class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        
        CreateDefaultUsers(modelBuilder);
    }

    private void CreateDefaultUsers(ModelBuilder modelBuilder)
    {
        PasswordHasher.CreatePasswordHash("test", out byte[] hash, out byte[] salt);
        modelBuilder.Entity<User>().HasData(
            new User(10, RoleEnum.Chief, "Chief", "", "chief@gmail.com", hash, salt),
            new User(11, RoleEnum.Manager, "Manager", "", "manager@gmail.com", hash, salt)
            );
        
    }
}
