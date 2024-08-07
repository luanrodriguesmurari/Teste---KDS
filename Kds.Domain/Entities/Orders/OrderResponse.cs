using Kds.Domain.Enums;

namespace Kds.Domain.Entities.Orders
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderTime { get; set; }
        public List<OrderItemResponse> Items { get; set; }
        public OrderStatus Status { get; set; }
    }
}