using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Configurations;


public class OrderMenuItemConfiguration : IEntityTypeConfiguration<OrderMenuItem>
{
    public void Configure(EntityTypeBuilder<OrderMenuItem> builder)
    {
        builder.ToTable("OrderMenuItems");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(x => x.FoodItem)
            .WithMany()
            .HasForeignKey(x => x.FoodItemId);

        builder.HasOne(x => x.OrderDay)
            .WithMany(od => od.OrderMenuItems)
            .HasForeignKey(x => x.OrderDayId);
    }
}
