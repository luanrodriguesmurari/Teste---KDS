using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kds.Domain.Entities.Orders;

namespace Kds.Repository.Orders
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(oi => oi.Id);
            builder.Property(oi => oi.Id).ValueGeneratedOnAdd();
            builder.Property(oi => oi.Name).IsRequired().HasMaxLength(100);
            builder.Property(oi => oi.Quantity).IsRequired();
            builder.Property(oi => oi.Notes).HasMaxLength(500);
            builder.Property(oi => oi.OrderId).IsRequired();

            builder.HasData(
                new OrderItem
                {
                    Id = 1,
                    Name = "Item 1",
                    Quantity = 2,
                    Notes = "First item",
                    OrderId = 1
                },
                new OrderItem
                {
                    Id = 2,
                    Name = "Item 2",
                    Quantity = 1,
                    Notes = "Second item",
                    OrderId = 1
                },
                new OrderItem
                {
                    Id = 3,
                    Name = "Item 3",
                    Quantity = 3,
                    Notes = "Third item",
                    OrderId = 2
                }
            );
        }
    }
}