namespace Kds.Domain.Entities.Orders
{
    public class CreateOrderItemRequest
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}