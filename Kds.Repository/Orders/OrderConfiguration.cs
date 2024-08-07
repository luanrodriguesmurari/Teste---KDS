using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kds.Domain.Entities.Orders;
using Kds.Domain.Enums;

namespace Kds.Repository.Orders
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.CustomerName).IsRequired().HasMaxLength(100);
            builder.Property(o => o.OrderTime).IsRequired();
            builder.Property(o => o.Status).IsRequired();

            builder.HasMany(o => o.Items)
                   .WithOne()
                   .HasForeignKey(oi => oi.OrderId);

            builder.HasData(
                new Order
                {
                    Id = 1,
                    CustomerName = "Luan Rodrigues",
                    OrderTime = DateTime.Now,
                    Status = OrderStatus.Pending
                },
                new Order
                {
                    Id = 2,
                    CustomerName = "João Murari",
                    OrderTime = DateTime.Now,
                    Status = OrderStatus.InProgress
                }
            );
        }
    }
}