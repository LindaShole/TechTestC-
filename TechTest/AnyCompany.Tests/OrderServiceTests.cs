using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnyCompany.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void PlaceOrder_ValidOrderAndCustomer_ReturnsTrue()
        {
            OrderService orderService = new OrderService();
            Order order = new Order { OrderId = 1, Amount = 100, VAT = 0 };
            int customerId = 1;

            bool result = orderService.PlaceOrder(order, customerId);

            Assert.True(result);
        }

        [Fact]
        public void PlaceOrder_InvalidCustomer_ReturnsFalse()
        {
            OrderService orderService = new OrderService();
            Order order = new Order { OrderId = 1, Amount = 100, VAT = 0 };
            int invalidCustomerId = -1;

            bool result = orderService.PlaceOrder(order, invalidCustomerId);

            Assert.False(result);
        }

    }
}
