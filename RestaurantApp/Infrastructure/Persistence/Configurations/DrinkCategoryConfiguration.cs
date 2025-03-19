using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Configurations;

public class DrinkCategoryConfiguration : IEntityTypeConfiguration<DrinkCategory>
{
    public void Configure(EntityTypeBuilder<DrinkCategory> builder)
    {
        builder.ToTable("DrinkCategories");
    }
}
