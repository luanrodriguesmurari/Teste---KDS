using Kds.Domain.Enums;

namespace Kds.Domain.Entities.Orders
{
    public class UpdateOrderRequest
    {
        public string CustomerName { get; set; }
        public DateTime OrderTime { get; set; }
        public List<UpdateOrderItemRequest> Items { get; set; }
        public OrderStatus Status { get; set; }
    }
}