using AnyCompany.Base;
using AnyCompany.Base.Domain.Contract;
using AnyCompany.Base.IRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AnyCompany.UnitTests
{
    [TestClass]
    public class OrderServiceTests
    {
        [TestMethod]
        public void PlaceOrder_AmountEqualsZero_False()
        {
            //Arrage
            int customerId = 1;

            IOrder order = Factory.CreateOrder();
            order.OrderId = 1;
            order.Amount = 0;
            order.VAT = 12;

            //ICustomer customer = Factory.CreateCustomer();
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
            order.OrderId = 1;
            order.Amount = 1;
            order.VAT = 12;

            IOrderService orderService = Factory.CreateOrderService();

            //Act
            var result = orderService.PlaceOrder(order, customerId);

            //Assert
            Assert.IsTrue(result);
        }

    }
}
