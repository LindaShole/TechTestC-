using AnyCompany.DataAccess.Repository;
using AnyCompany.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AnyCompany.Tests
{

    [TestClass]
    public class OrderRepositoryTests
    {

        //test OrderRepository

        private OrderRepository _orderRepository;
        private Order _order;

        public const int OrderId = 1;
        public const double Amount = 25.0;
        public const double VAT = 0;
        public const int CustomerId = 8;

        [TestInitialize]
        public void Setup()
        {
            _orderRepository = new OrderRepository();
            _order = new Order
            {
                OrderId = OrderId,
                Amount = Amount,
                VAT = VAT,
                CustomerId = CustomerId
            };
        }

        [TestMethod]
        public void CanSaveAnOrderAndGetOrdersForTheCustomer()
        {
           
            _orderRepository.Save(_order);
            var orders = _orderRepository.GetOrdersByCustomerId(CustomerId);
            Assert.IsNotNull(orders);
        }

        [TestMethod]
        public void GetOrdersByCustomerId()
        {
             _order = new Order
            {
                OrderId = OrderId,
                Amount = Amount,
                VAT = VAT,
                CustomerId = CustomerId
            };
            var orders = _orderRepository.GetOrdersByCustomerId(CustomerId);
            Assert.IsNotNull(orders);
        }




    }
}
