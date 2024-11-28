using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence;

public class RestaurantDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
