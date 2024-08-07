using Kds.Domain.Enums;

namespace Kds.Domain.Entities.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderTime { get; set; }
        public List<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; }
    }
}