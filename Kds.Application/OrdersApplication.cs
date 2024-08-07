using AutoMapper;
using Kds.Domain.Applications;
using Kds.Domain.Business;
using Kds.Domain.Entities.Orders;

namespace Kds.Application
{
    public class OrdersApplication : IOrdersApplication
    {
        private readonly IOrdersBusiness _ordersBusiness;
        private readonly IMapper _mapper;

        public OrdersApplication(IOrdersBusiness ordersBusiness, IMapper mapper)
        {
            _ordersBusiness = ordersBusiness;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderResponse>> GetAllOrdersAsync()
        {
            var orders = await _ordersBusiness.GetAllOrdersAsync();
            return _mapper.Map<IEnumerable<OrderResponse>>(orders);
        }

        public async Task<OrderResponse?> GetOrderByIdAsync(int id)
        {
            var order = await _ordersBusiness.GetOrderByIdAsync(id);
            return _mapper.Map<OrderResponse>(order);
        }

        public async Task<OrderResponse> CreateOrderAsync(CreateOrderRequest orderRequest)
        {
            var order = _mapper.Map<Order>(orderRequest);
            var createdOrder = await _ordersBusiness.CreateOrderAsync(order);
            return _mapper.Map<OrderResponse>(createdOrder);
        }

        public async Task<OrderResponse> UpdateOrderAsync(int id, UpdateOrderRequest orderRequest)
        {
            var order = _mapper.Map<Order>(orderRequest);
            var updatedOrder = await _ordersBusiness.UpdateOrderAsync(id, order);
            return _mapper.Map<OrderResponse>(updatedOrder);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await _ordersBusiness.DeleteOrderAsync(id);
        }

        public async Task<IEnumerable<OrderItemResponse>> GetOrderItemsAsync(int orderId)
        {
            var items = await _ordersBusiness.GetOrderItemsAsync(orderId);
            return _mapper.Map<IEnumerable<OrderItemResponse>>(items);
        }

        public async Task<OrderItemResponse> AddOrderItemAsync(int orderId, CreateOrderItemRequest itemRequest)
        {
            var item = _mapper.Map<OrderItem>(itemRequest);
            var createdItem = await _ordersBusiness.AddOrderItemAsync(orderId, item);
            return _mapper.Map<OrderItemResponse>(createdItem);
        }

        public async Task<OrderItemResponse> UpdateOrderItemAsync(int orderId, int itemId, UpdateOrderItemRequest itemRequest)
        {
            var item = _mapper.Map<OrderItem>(itemRequest);
            var updatedItem = await _ordersBusiness.UpdateOrderItemAsync(orderId, itemId, item);
            return _mapper.Map<OrderItemResponse>(updatedItem);
        }

        public async Task<bool> DeleteOrderItemAsync(int orderId, int itemId)
        {
            return await _ordersBusiness.DeleteOrderItemAsync(orderId, itemId);
        }
    }
}