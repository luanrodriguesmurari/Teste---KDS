using Kds.Domain.Entities.Orders;

namespace Kds.Domain.Business
{
    public interface IOrdersBusiness
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(int id, Order order);
        Task<bool> DeleteOrderAsync(int id);
        Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderId);
        Task<OrderItem> AddOrderItemAsync(int orderId, OrderItem item);
        Task<OrderItem> UpdateOrderItemAsync(int orderId, int itemId, OrderItem item);
        Task<bool> DeleteOrderItemAsync(int orderId, int itemId);
    }
}