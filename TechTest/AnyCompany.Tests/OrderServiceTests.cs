using AnyCompany.Configurations;
using AnyCompany.DTOs;
using AnyCompany.Entities;
using AnyCompany.Interfaces;
using AnyCompany.Services;
using AnyCompany.Tests.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnyCompany.Tests
{
    public class OrderServiceTests
    {
        private List<Order> _orders;
        private List<Customer> _customers;
        private Mock<DbSet<Order>> _mockOrderSet;
        private IOrderService _orderService;
        private Mock<AnyCompanyDbContext> _mockDbContext;

        public OrderServiceTests()
        {
            _mockDbContext = new Mock<AnyCompanyDbContext>();
            _orders = new List<Order>()
            {
                new Order() { OrderId = 1, CustomerId = 1, Amount = 100, VAT = 0.15 },
                new Order() { OrderId = 2, CustomerId = 1, Amount = 50, VAT = 0.1 },
                new Order() { OrderId = 3, CustomerId = 2, Amount = 75, VAT = 0.2 },
                new Order() { OrderId = 4, CustomerId = 3, Amount = 200, VAT = 0.2 }
            };

            _customers = new List<Customer>()
            {
                new Customer() { CustomerId = 1, Country = "USA", DateOfBirth = System.DateTime.Today, Name = "John Smith" },
                new Customer() { CustomerId = 2, Country = "UK", DateOfBirth = System.DateTime.Today, Name = "Alice Brown" },
                new Customer() { CustomerId = 3, Country = "France", DateOfBirth = System.DateTime.Today, Name = "Jean Dupont" },
            };

            var mockCustomerSet = _customers.AsQueryable().GetMockSet();
            mockCustomerSet.Setup(m => m.Include("Orders")).Returns(mockCustomerSet.Object);

            _mockOrderSet = _orders.AsQueryable().GetMockSet();
            _mockOrderSet.Setup(m => m.Include("Customer")).Returns(_mockOrderSet.Object);

            _mockDbContext.Setup(db => db.Orders).Returns(_mockOrderSet.Object);
            _mockDbContext.Setup(db => db.Customers).Returns(mockCustomerSet.Object);

            _orderService = new OrderService(_mockDbContext.Object);
        }

        [Fact]
        public async void PlaceOrder_Valid_OrderDTOAsync()
        {
            // Arrange
            var order = new OrderDTO()
            {
                CustomerId = 1,
                Amount = 20
            };

            //// Act
            await _orderService.PlaceOrder(order);

            // Verify
            _mockOrderSet.Verify(m => m.Add(It.IsAny<Order>()), Times.Once());
            _mockDbContext.Verify(m => m.SaveChangesAsync(), Times.Once());
        }

        [Fact]
        public async void PlaceOrder_InValid_Amount_Exception()
        {
            // Arrange
            var order = new OrderDTO()
            {
                CustomerId = 1,
                Amount = 0
            };

            //// Act and Assert
            await Assert.ThrowsAsync<Exception>(async () => await _orderService.PlaceOrder(order));
        }

        [Fact]
        public async Task PlaceOrder_InValid_CustomerId_Exception()
        {
            // Arrange
            var order = new OrderDTO()
            {
                CustomerId = 99,
                Amount = 100
            };

            //// Act and Assert
            await Assert.ThrowsAsync<Exception>(async () => await _orderService.PlaceOrder(order));
        }

        [Fact]
        public async void LoadCustomerOrders_Valid_NotEmpty()
        {
            // Act
            var results = await _orderService.LoadCustomerOrders(1);

            // Assert
            Assert.Equal(2, results.Count());
            Assert.Equal(100, results.ElementAt(0).Amount);
            Assert.Equal(50, results.ElementAt(1).Amount);
        }

        [Fact]
        public async void LoadCustomerOrders_DoesntExist_CustomerId_Empty()
        {
            // Act
            var results = await _orderService.LoadCustomerOrders(99);

            // Assert
            Assert.Empty(results);
        }
    }
}
