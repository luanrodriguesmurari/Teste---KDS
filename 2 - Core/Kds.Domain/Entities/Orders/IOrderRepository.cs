namespace Kds.Domain.Entities.Orders
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order order);

        Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderId);
        Task AddOrderItemAsync(OrderItem item);
        Task UpdateOrderItemAsync(OrderItem item);
        Task DeleteOrderItemAsync(OrderItem item);
    }
}