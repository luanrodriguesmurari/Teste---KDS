using Microsoft.AspNetCore.Mvc;
using Kds.Domain.Applications;
using Kds.Domain.Entities.Orders;
using Microsoft.AspNetCore.Authorization;

namespace Kds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersApplication _ordersApplication;

        public OrdersController(IOrdersApplication ordersApplication)
        {
            _ordersApplication = ordersApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var orders = await _ordersApplication.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            var order = await _ordersApplication.GetOrderByIdAsync(id);
            return order == null ? NotFound() : Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderRequest orderRequest)
        {
            var createdOrder = await _ordersApplication.CreateOrderAsync(orderRequest);
            return CreatedAtAction(nameof(GetOrderByIdAsync), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderAsync(int id, [FromBody] UpdateOrderRequest orderRequest)
        {
            var updatedOrder = await _ordersApplication.UpdateOrderAsync(id, orderRequest);
            return Ok(updatedOrder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            var deleted = await _ordersApplication.DeleteOrderAsync(id);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet("{id}/items")]
        public async Task<IActionResult> GetOrderItemsAsync(int id)
        {
            var items = await _ordersApplication.GetOrderItemsAsync(id);
            return Ok(items);
        }

        [HttpPost("{id}/items")]
        public async Task<IActionResult> AddOrderItemAsync(int id, [FromBody] CreateOrderItemRequest itemRequest)
        {
            var createdItem = await _ordersApplication.AddOrderItemAsync(id, itemRequest);
            return CreatedAtAction(nameof(GetOrderItemsAsync), new { id = id }, createdItem);
        }

        [HttpPut("{id}/items/{itemId}")]
        public async Task<IActionResult> UpdateOrderItemAsync(int id, int itemId, [FromBody] UpdateOrderItemRequest itemRequest)
        {
            var updatedItem = await _ordersApplication.UpdateOrderItemAsync(id, itemId, itemRequest);
            return Ok(updatedItem);
        }

        [HttpDelete("{id}/items/{itemId}")]
        public async Task<IActionResult> DeleteOrderItemAsync(int id, int itemId)
        {
            var deleted = await _ordersApplication.DeleteOrderItemAsync(id, itemId);
            return deleted ? NoContent() : NotFound();
        }
    }
}