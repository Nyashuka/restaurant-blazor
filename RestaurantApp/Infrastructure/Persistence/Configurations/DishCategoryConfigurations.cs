using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Configurations;

public class DishCategoryConfigurations : IEntityTypeConfiguration<DishCategory>
{
    public void Configure(EntityTypeBuilder<DishCategory> builder)
    {
        builder.ToTable("DishCategories");

        builder.HasKey(dt => dt.Id);

        builder.Property(dt => dt.Id)
            .ValueGeneratedOnAdd();

        builder.Property(dt => dt.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(dt => dt.IsShared)
            .IsRequired();
    }
}
