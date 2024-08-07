using Kds.Domain.Business;
using Kds.Domain.Entities.Orders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kds.Business
{
    public class OrdersBusiness : IOrdersBusiness
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrdersBusiness> _logger;

        public OrdersBusiness(IOrderRepository orderRepository, ILogger<OrdersBusiness> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            try
            {
                return await _orderRepository.GetAllOrdersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching all orders. Ex.: {ex.Message}", ex);
                return Enumerable.Empty<Order>();
            }
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            try
            {
                return await _orderRepository.GetOrderByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching order with id {id}. Ex.: {ex.Message}", ex);
                return null;
            }
        }

        public async Task<Order?> CreateOrderAsync(Order order)
        {
            try
            {
                await _orderRepository.AddAsync(order);
                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating order. Ex.: {ex.Message}", ex);
                return null;
            }
        }

        public async Task<Order?> UpdateOrderAsync(int id, Order order)
        {
            try
            {
                await _orderRepository.UpdateAsync(order);
                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating order with id {id}. Ex.: {ex.Message}", ex);
                return null;
            }
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            try
            {
                var order = await _orderRepository.GetOrderByIdAsync(id);
                if (order != null)
                {
                    await _orderRepository.DeleteAsync(order);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting order with id {id}. Ex.: {ex.Message}", ex);
                return false;
            }
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderId)
        {
            try
            {
                return await _orderRepository.GetOrderItemsAsync(orderId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching items for order with id {orderId}. Ex.: {ex.Message}", ex);
                return Enumerable.Empty<OrderItem>();
            }
        }

        public async Task<OrderItem?> AddOrderItemAsync(int orderId, OrderItem item)
        {
            try
            {
                await _orderRepository.AddOrderItemAsync(item);
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding item to order with id {orderId}. Ex.: {ex.Message}", ex);
                return null;
            }
        }

        public async Task<OrderItem?> UpdateOrderItemAsync(int orderId, int itemId, OrderItem item)
        {
            try
            {
                await _orderRepository.UpdateOrderItemAsync(item);
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating item with id {itemId} in order with id {orderId}. Ex.: {ex.Message}", ex);
                return null;
            }
        }

        public async Task<bool> DeleteOrderItemAsync(int orderId, int itemId)
        {
            try
            {
                var items = await _orderRepository.GetOrderItemsAsync(orderId);
                var orderItem = items.FirstOrDefault(i => i.Id == itemId);
                if (orderItem != null)
                {
                    await _orderRepository.DeleteOrderItemAsync(orderItem);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting item with id {itemId} in order with id {orderId}. Ex.: {ex.Message}", ex);
                return false;
            }
        }
    }
}