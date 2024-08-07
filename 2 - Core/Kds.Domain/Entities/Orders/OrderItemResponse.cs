namespace Kds.Domain.Entities.Orders
{
    public class OrderItemResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}