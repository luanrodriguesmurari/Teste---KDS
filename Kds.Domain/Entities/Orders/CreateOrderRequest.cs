using Kds.Domain.Enums;

namespace Kds.Domain.Entities.Orders
{
    public class CreateOrderRequest
    {
        public string CustomerName { get; set; }
        public DateTime OrderTime { get; set; }
        public List<CreateOrderItemRequest> Items { get; set; }
        public OrderStatus Status { get; set; }
    }
}