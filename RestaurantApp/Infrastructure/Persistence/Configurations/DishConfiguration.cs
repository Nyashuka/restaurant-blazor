using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Configurations;

public class DishConfiguration : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.ToTable("Dishes");

        builder.HasOne(x => x.DishCategory)
            .WithMany()
            .HasForeignKey(x => x.DishCategoryId);

        builder.Property(x => x.Weight)
            .IsRequired();

        builder.Property(x => x.RecommendedWeightPerPortion)
            .IsRequired();

        builder.HasOne(x => x.DishCategory)
            .WithMany()
            .HasForeignKey(x => x.DishCategoryId);
    }
}