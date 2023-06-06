using AnyCompany.Base;
using AnyCompany.Base.Domain.Contract;
using AnyCompany.Base.IRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Tests
{
    [TestClass]
    public class OrderServiceTest
    {
        [TestMethod]
        public void PlaceOrder_AmountEqualsZero_False()
        {
            //Arrage
            int customerId = 1;

            IOrder order = Factory.CreateOrder();
            order.OrderId = 3;
            order.Amount = 0;
            order.VAT = 12;

            IOrderService orderService = Factory.CreateOrderService();

            //Act
            var result = orderService.PlaceOrder(order, customerId);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PlaceOrder_AmountGreaterOrLessThanZero_True()
        {
            //Arrage
            int customerId = 1;

            IOrder order = Factory.CreateOrder();
            order.OrderId = 2;
            order.Amount = 100;
            order.VAT = 12;

            IOrderService orderService = Factory.CreateOrderService();

            //Act
            var result = orderService.PlaceOrder(order, customerId);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
