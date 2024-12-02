using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Configurations;

namespace RestaurantApp.Infrastructure.Persistence.DbContexts;

public class RestaurantDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
