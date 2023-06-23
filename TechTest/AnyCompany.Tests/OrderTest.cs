using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyCompany.Contracts;
using AnyCompany.IRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace AnyCompany.Tests
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void PlaceOrder()
        {
            int customerId = 1;

            IOrder order = (IOrder)Factory.CreateOrder();
            order.OrderId = 1;
            order.Amount = 10;
            order.VAT = 12;

            IOrderService orderService = Factory.CreateOrderService();

            //Act
            var result = orderService.PlaceOrder(order, customerId);

            //Assert
            Assert.IsFalse(result);
        }

    }
}
