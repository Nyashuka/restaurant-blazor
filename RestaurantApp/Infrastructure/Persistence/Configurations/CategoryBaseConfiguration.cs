using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Configurations;

public class CategoryBaseConfiguration : IEntityTypeConfiguration<CategoryBase>
{
    public void Configure(EntityTypeBuilder<CategoryBase> builder)
    {
        builder.HasKey(dt => dt.Id);

        builder.Property(dt => dt.Id)
            .ValueGeneratedOnAdd();

        builder.Property(dt => dt.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(dt => dt.IsShared)
            .IsRequired();

        builder.Property(c => c.IsEnabled)
            .HasDefaultValue(true);
    }
}
