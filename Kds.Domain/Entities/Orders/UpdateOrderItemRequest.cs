namespace Kds.Domain.Entities.Orders
{
    public class UpdateOrderItemRequest
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}