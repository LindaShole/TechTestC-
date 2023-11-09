using AnyCompany.Repository.IRepository;
using NSubstitute;
using NUnit.Framework;
using AnyCompany.Domain;

namespace AnyCompany.NunityTests
{
    public class OrderServiceTests
    {
        private IOrderRepository orderRepository;
        private ICustomerRepository customerRepository;
        private OrderService orderService;

        [SetUp]
        public void Setup()
        {
            orderRepository = Substitute.For<IOrderRepository>();
            customerRepository = Substitute.For<ICustomerRepository>();

            orderService = new OrderService(orderRepository, customerRepository);
        }

        [Test]
        public void PlaceOrder_ValidOrder_ShouldReturnTrue()
        {
            // Arrange
            int customerId = 123;
            Order order = new Order
            {
                OrderId = 1,
                Amount = 100.0,
                VAT = 0
            };
            Customer customer = new Customer
            {
                CustomerId = customerId,
                Country = "UK"
            };

            // Set up the behavior of the mock customer repository
            customerRepository.Load(customerId).Returns(customer);

            // Act
            bool result = orderService.PlaceOrder(order, customerId);

            // Assert
            // Verify that the order was saved
            orderRepository.Received(1).Save(order);

            // Verify that the result is true
            Assert.IsTrue(result);
        }
        [Test]
        public void PlaceOrder_InvalidOrderAmount_ShouldReturnFalse()
        {
            // Arrange
            int customerId = 123;
            Order order = new Order
            {
                OrderId = 1,
                Amount = -50.0,
                VAT = 0
            };
            Customer customer = new Customer
            {
                CustomerId = customerId,
                Country = "UK"
            };

            // Set up the behavior of the mock customer repository
            customerRepository.Load(customerId).Returns(customer);

            // Act
            bool result = orderService.PlaceOrder(order, customerId);

            // Assert
            // Verify that the order was not saved
            orderRepository.DidNotReceive().Save(Arg.Any<Order>());

            // Verify that the result is false
            Assert.IsFalse(result);
        }
    }
}