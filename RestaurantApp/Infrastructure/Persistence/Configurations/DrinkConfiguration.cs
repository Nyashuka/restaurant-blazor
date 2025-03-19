using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Configurations;

public class DrinkConfiguration : IEntityTypeConfiguration<Drink>
{
    public void Configure(EntityTypeBuilder<Drink> builder)
    {
        builder.ToTable("Drinks");

        builder.Property(x => x.Volume)
            .IsRequired();

        builder.Property(x => x.VolumePerPerson)
            .IsRequired();

        builder.Property(x => x.IsAlcoholic)
            .IsRequired();
    }
}
