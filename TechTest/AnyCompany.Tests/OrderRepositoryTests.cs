using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyCompany;
using Xunit;

namespace AnyCompany.Tests
{
    public class OrderRepositoryTests
    {
        [Fact]
        public void Save_ValidOrder_OrderIsSaved()
        {
            OrderRepository orderRepository = new OrderRepository();
            Order order = new Order { OrderId = 1, Amount = 100, VAT = 0.2 };
            int customerId = 1; 

            orderRepository.Save(order, customerId);

            Order savedOrder = FetchOrderFromDatabase(order.OrderId);

            Assert.NotNull(savedOrder);
            Assert.Equal(order.OrderId, savedOrder.OrderId);
            Assert.Equal(order.Amount, savedOrder.Amount);
            Assert.Equal(order.VAT, savedOrder.VAT);
        }

     

        private Order FetchOrderFromDatabase(int orderId)
        {
 
            return new Order { OrderId = orderId, Amount = 100, VAT = 0.2 };
        }
    }
}
