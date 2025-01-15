using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Configurations;

public class DishTypeConfigurations : IEntityTypeConfiguration<DishType>
{
    public void Configure(EntityTypeBuilder<DishType> builder)
    {
        builder.ToTable("DishTypes");

        builder.HasKey(dt => dt.Id);

        builder.Property(dt => dt.Id)
            .ValueGeneratedOnAdd();

        builder.Property(dt => dt.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}
