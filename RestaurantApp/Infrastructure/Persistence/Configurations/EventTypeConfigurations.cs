using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Configurations;

public class EventTypeConfiguration : IEntityTypeConfiguration<EventType>
{
    public void Configure(EntityTypeBuilder<EventType> builder)
    {
        builder.ToTable("EventTypes");

        builder.HasKey(et => et.Id);

        builder.Property(et => et.Id)
            .ValueGeneratedOnAdd();

        builder.Property(et => et.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}