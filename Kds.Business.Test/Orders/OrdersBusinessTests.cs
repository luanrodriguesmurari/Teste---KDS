using Kds.Domain.Entities.Orders;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Kds.Business.Test.Orders
{
    public class OrdersBusinessTests
    {
        private readonly OrdersBusiness _ordersBusiness;
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<ILogger<OrdersBusiness>> _loggerMock;

        public OrdersBusinessTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _loggerMock = new Mock<ILogger<OrdersBusiness>>();
            _ordersBusiness = new OrdersBusiness(_orderRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAllOrdersAsync_ShouldReturnOrders()
        {
            // Arrange
            var orders = new List<Order> { new Order { Id = 1, CustomerName = "Luan Rodrigues" } };
            _orderRepositoryMock.Setup(r => r.GetAllOrdersAsync()).ReturnsAsync(orders);

            // Act
            var result = await _ordersBusiness.GetAllOrdersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(orders, result);
            _orderRepositoryMock.Verify(r => r.GetAllOrdersAsync(), Times.Once);
        }

        [Fact]
        public async Task GetAllOrdersAsync_ShouldReturnEmptyList_WhenExceptionThrown()
        {
            // Arrange
            _orderRepositoryMock.Setup(r => r.GetAllOrdersAsync()).ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _ordersBusiness.GetAllOrdersAsync();

            // Assert
            Assert.Empty(result);
            _orderRepositoryMock.Verify(r => r.GetAllOrdersAsync(), Times.Once);
        }

        [Fact]
        public async Task GetOrderByIdAsync_ShouldReturnOrder()
        {
            // Arrange
            var order = new Order { Id = 1, CustomerName = "Luan Rodrigues" };
            _orderRepositoryMock.Setup(r => r.GetOrderByIdAsync(It.IsAny<int>())).ReturnsAsync(order);

            // Act
            var result = await _ordersBusiness.GetOrderByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(order, result);
            _orderRepositoryMock.Verify(r => r.GetOrderByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GetOrderByIdAsync_ShouldReturnNull_WhenExceptionThrown()
        {
            // Arrange
            _orderRepositoryMock.Setup(r => r.GetOrderByIdAsync(It.IsAny<int>())).ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _ordersBusiness.GetOrderByIdAsync(1);

            // Assert
            Assert.Null(result);
            _orderRepositoryMock.Verify(r => r.GetOrderByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task CreateOrderAsync_ShouldReturnCreatedOrder()
        {
            // Arrange
            var order = new Order { Id = 1, CustomerName = "Luan Rodrigues" };
            _orderRepositoryMock.Setup(r => r.AddAsync(order)).Returns(Task.CompletedTask);

            // Act
            var result = await _ordersBusiness.CreateOrderAsync(order);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(order, result);
            _orderRepositoryMock.Verify(r => r.AddAsync(order), Times.Once);
        }

        [Fact]
        public async Task CreateOrderAsync_ShouldReturnNull_WhenExceptionThrown()
        {
            // Arrange
            var order = new Order { Id = 1, CustomerName = "Luan Rodrigues" };
            _orderRepositoryMock.Setup(r => r.AddAsync(order)).ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _ordersBusiness.CreateOrderAsync(order);

            // Assert
            Assert.Null(result);
            _orderRepositoryMock.Verify(r => r.AddAsync(order), Times.Once);
        }

        [Fact]
        public async Task UpdateOrderAsync_ShouldReturnUpdatedOrder()
        {
            // Arrange
            var order = new Order { Id = 1, CustomerName = "Luan Rodrigues" };
            _orderRepositoryMock.Setup(r => r.UpdateAsync(order)).Returns(Task.CompletedTask);

            // Act
            var result = await _ordersBusiness.UpdateOrderAsync(1, order);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(order, result);
            _orderRepositoryMock.Verify(r => r.UpdateAsync(order), Times.Once);
        }

        [Fact]
        public async Task UpdateOrderAsync_ShouldReturnNull_WhenExceptionThrown()
        {
            // Arrange
            var order = new Order { Id = 1, CustomerName = "Luan Rodrigues" };
            _orderRepositoryMock.Setup(r => r.UpdateAsync(order)).ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _ordersBusiness.UpdateOrderAsync(1, order);

            // Assert
            Assert.Null(result);
            _orderRepositoryMock.Verify(r => r.UpdateAsync(order), Times.Once);
        }

        [Fact]
        public async Task DeleteOrderAsync_ShouldReturnTrue()
        {
            // Arrange
            var order = new Order { Id = 1, CustomerName = "Luan Rodrigues" };
            _orderRepositoryMock.Setup(r => r.GetOrderByIdAsync(It.IsAny<int>())).ReturnsAsync(order);
            _orderRepositoryMock.Setup(r => r.DeleteAsync(order)).Returns(Task.CompletedTask);

            // Act
            var result = await _ordersBusiness.DeleteOrderAsync(1);

            // Assert
            Assert.True(result);
            _orderRepositoryMock.Verify(r => r.GetOrderByIdAsync(It.IsAny<int>()), Times.Once);
            _orderRepositoryMock.Verify(r => r.DeleteAsync(order), Times.Once);
        }

        [Fact]
        public async Task DeleteOrderAsync_ShouldReturnFalse_WhenOrderNotFound()
        {
            // Arrange
            _orderRepositoryMock.Setup(r => r.GetOrderByIdAsync(It.IsAny<int>())).ReturnsAsync((Order)null);

            // Act
            var result = await _ordersBusiness.DeleteOrderAsync(1);

            // Assert
            Assert.False(result);
            _orderRepositoryMock.Verify(r => r.GetOrderByIdAsync(It.IsAny<int>()), Times.Once);
            _orderRepositoryMock.Verify(r => r.DeleteAsync(It.IsAny<Order>()), Times.Never);
        }

        [Fact]
        public async Task DeleteOrderAsync_ShouldReturnFalse_WhenExceptionThrown()
        {
            // Arrange
            var order = new Order { Id = 1, CustomerName = "Luan Rodrigues" };
            _orderRepositoryMock.Setup(r => r.GetOrderByIdAsync(It.IsAny<int>())).ReturnsAsync(order);
            _orderRepositoryMock.Setup(r => r.DeleteAsync(order)).ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _ordersBusiness.DeleteOrderAsync(1);

            // Assert
            Assert.False(result);
            _orderRepositoryMock.Verify(r => r.GetOrderByIdAsync(It.IsAny<int>()), Times.Once);
            _orderRepositoryMock.Verify(r => r.DeleteAsync(order), Times.Once);
        }
    }
}