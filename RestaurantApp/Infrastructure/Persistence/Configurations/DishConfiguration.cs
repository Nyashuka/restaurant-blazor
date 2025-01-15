using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Configurations;

public class DishConfiguration : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.ToTable("Dishes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(x => x.DishType)
            .WithMany()
            .HasForeignKey(x => x.DishTypeId);

        builder.Property(x => x.PricePerUnit)
            .IsRequired();

        builder.Property(x => x.Weight)
            .IsRequired();

        builder.Property(x => x.ServingPerUnit)
            .IsRequired();
    }
}