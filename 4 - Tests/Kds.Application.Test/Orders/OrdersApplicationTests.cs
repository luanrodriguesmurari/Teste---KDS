using AutoMapper;
using Kds.Domain.Business;
using Kds.Domain.Entities.Orders;
using Moq;

namespace Kds.Application.Test.Orders
{
    public class OrdersApplicationTests
    {
        private readonly OrdersApplication _ordersApplication;
        private readonly Mock<IOrdersBusiness> _ordersBusinessMock;
        private readonly Mock<IMapper> _mapperMock;

        public OrdersApplicationTests()
        {
            _ordersBusinessMock = new Mock<IOrdersBusiness>();
            _mapperMock = new Mock<IMapper>();
            _ordersApplication = new OrdersApplication(_ordersBusinessMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAllOrdersAsync_ShouldReturnOrders()
        {
            // Arrange
            var orders = new List<Order> { new Order { Id = 1, CustomerName = "Luan Rodrigues" } };
            _ordersBusinessMock.Setup(b => b.GetAllOrdersAsync()).ReturnsAsync(orders);
            _mapperMock.Setup(m => m.Map<IEnumerable<OrderResponse>>(orders)).Returns(new List<OrderResponse>());

            // Act
            var result = await _ordersApplication.GetAllOrdersAsync();

            // Assert
            Assert.NotNull(result);
            _ordersBusinessMock.Verify(b => b.GetAllOrdersAsync(), Times.Once);
        }

        [Fact]
        public async Task GetOrderByIdAsync_ShouldReturnOrder()
        {
            // Arrange
            var order = new Order { Id = 1, CustomerName = "Luan Rodrigues" };
            _ordersBusinessMock.Setup(b => b.GetOrderByIdAsync(It.IsAny<int>())).ReturnsAsync(order);
            _mapperMock.Setup(m => m.Map<OrderResponse>(order)).Returns(new OrderResponse());

            // Act
            var result = await _ordersApplication.GetOrderByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            _ordersBusinessMock.Verify(b => b.GetOrderByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task CreateOrderAsync_ShouldReturnCreatedOrder()
        {
            // Arrange
            var createOrderRequest = new CreateOrderRequest { CustomerName = "Luan Rodrigues" };
            var order = new Order { Id = 1, CustomerName = "Luan Rodrigues" };
            var orderResponse = new OrderResponse { Id = 1, CustomerName = "Luan Rodrigues" };
            _mapperMock.Setup(m => m.Map<Order>(createOrderRequest)).Returns(order);
            _ordersBusinessMock.Setup(b => b.CreateOrderAsync(order)).ReturnsAsync(order);
            _mapperMock.Setup(m => m.Map<OrderResponse>(order)).Returns(orderResponse);

            // Act
            var result = await _ordersApplication.CreateOrderAsync(createOrderRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(orderResponse, result);
            _ordersBusinessMock.Verify(b => b.CreateOrderAsync(order), Times.Once);
        }

        [Fact]
        public async Task UpdateOrderAsync_ShouldReturnUpdatedOrder()
        {
            // Arrange
            var updateOrderRequest = new UpdateOrderRequest { CustomerName = "Luan Rodrigues" };
            var order = new Order { Id = 1, CustomerName = "Luan Rodrigues" };
            var orderResponse = new OrderResponse { Id = 1, CustomerName = "Luan Rodrigues" };
            _mapperMock.Setup(m => m.Map<Order>(updateOrderRequest)).Returns(order);
            _ordersBusinessMock.Setup(b => b.UpdateOrderAsync(It.IsAny<int>(), order)).ReturnsAsync(order);
            _mapperMock.Setup(m => m.Map<OrderResponse>(order)).Returns(orderResponse);

            // Act
            var result = await _ordersApplication.UpdateOrderAsync(1, updateOrderRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(orderResponse, result);
            _ordersBusinessMock.Verify(b => b.UpdateOrderAsync(It.IsAny<int>(), order), Times.Once);
        }

        [Fact]
        public async Task DeleteOrderAsync_ShouldReturnTrue()
        {
            // Arrange
            _ordersBusinessMock.Setup(b => b.DeleteOrderAsync(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _ordersApplication.DeleteOrderAsync(1);

            // Assert
            Assert.True(result);
            _ordersBusinessMock.Verify(b => b.DeleteOrderAsync(It.IsAny<int>()), Times.Once);
        }
    }
}