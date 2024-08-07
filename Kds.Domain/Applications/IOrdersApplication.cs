using Kds.Domain.Entities.Orders;

namespace Kds.Domain.Applications
{
    public interface IOrdersApplication
    {
        Task<IEnumerable<OrderResponse>> GetAllOrdersAsync();
        Task<OrderResponse?> GetOrderByIdAsync(int id);
        Task<OrderResponse> CreateOrderAsync(CreateOrderRequest orderRequest);
        Task<OrderResponse> UpdateOrderAsync(int id, UpdateOrderRequest orderRequest);
        Task<bool> DeleteOrderAsync(int id);

        Task<IEnumerable<OrderItemResponse>> GetOrderItemsAsync(int orderId);
        Task<OrderItemResponse> AddOrderItemAsync(int orderId, CreateOrderItemRequest itemRequest);
        Task<OrderItemResponse> UpdateOrderItemAsync(int orderId, int itemId, UpdateOrderItemRequest itemRequest);
        Task<bool> DeleteOrderItemAsync(int orderId, int itemId);
    }
}