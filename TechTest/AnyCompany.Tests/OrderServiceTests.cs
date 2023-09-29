using AnyCompany.DataAccess.Repository;
using AnyCompany.Domain.Dto;
using AnyCompany.Domain.Entities;
using AnyCompany.Factory;
using AnyCompany.Infrastructure.Helpers;
using AnyCompany.Infrastructure.Interfaces.Repository;
using AnyCompany.Infrastructure.Interfaces.Services;
using AnyCompany.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AnyCompany.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        private IOrderService _orderService;
        private CustomerRepositoryWrapper _customerRepositoryWrapper;
        private OrderRepository _orderRepository;
        private OrderFactory _orderFactory;
        private static Random _ran = new Random();

        private string Name = Guid.NewGuid().ToString();
        private string Name2 = Guid.NewGuid().ToString();
        private string Name3 = Guid.NewGuid().ToString();
        private string Country = CountryEnum.UK.ToString();
        private string Country2 = CountryEnum.ZA.ToString();
        private DateTime DateOfBirth = DateTime.MinValue.Add(
            TimeSpan.FromTicks((long)(_ran.NextDouble() * DateTime.MaxValue.Ticks)));
        private const double UKVat = 0.2d;
        private double _orderAmount;

        private Customer _customer;
        private Customer _customer2;
        private Customer _customer3;
        private OrderDto _orderDto;
        private Order _order;


        [TestInitialize]
        public void Setup()
        {
            _customerRepositoryWrapper = new CustomerRepositoryWrapper();
            _orderRepository = new OrderRepository();
            _orderFactory = new OrderFactory();
            _orderService = new OrderService(_orderRepository, _customerRepositoryWrapper, _orderFactory);
            _orderAmount = _ran.NextDouble() * 100;

            _customer = new Customer
            {
                Name = Name,
                Country = Country,
                DateOfBirth = DateOfBirth
            };

            _customer2 = new Customer
            {
                Name = Name2,
                Country = Country2,
                DateOfBirth = DateOfBirth
            };

            _customer3 = new Customer
            {
                Name = Name3,
                Country = Country,
                DateOfBirth = DateOfBirth
            };

            _orderDto = new OrderDto
            {
                Amount = _orderAmount
            };

        }



        [TestMethod]
        public void CanInsertOrdersForUKCustomerAndGetPositiveVAT()
        {
            //Insert the customer first
            _customerRepositoryWrapper.Save(_customer);
            var customers = _customerRepositoryWrapper.GetAllCustomers();
            //get the inserted customer
            var insertedCustomer = customers.Find(x => x.Name == Name);

            _orderService.PlaceOrder(_orderDto, insertedCustomer.CustomerId);

            var ordertoBeInserted = _orderFactory.CreateOrder(insertedCustomer.CustomerId, insertedCustomer.Country, _orderAmount);

            var orders = _orderService.GetOrdersByCustomerId(insertedCustomer.CustomerId);
            var insertedOrder = orders.FirstOrDefault(x => x.Amount == _orderDto.Amount);

            Assert.AreEqual(ordertoBeInserted.VAT, UKVat);
            Assert.IsTrue(insertedOrder.VAT > 0);
            Assert.AreEqual(insertedOrder.Amount, _orderDto.Amount);


        }

     
        [TestMethod]
        public void CanInsertOrdersForNonUKCustomerAndGetZeroVAT()
        {
             _customerRepositoryWrapper.Save(_customer2);
            var customers = _customerRepositoryWrapper.GetAllCustomers();
            //get the inserted customer
            var insertedCustomer = customers.Find(x => x.Name == Name2);
             _orderService.PlaceOrder(_orderDto, insertedCustomer.CustomerId);

            var ordertoBeInserted = _orderFactory.CreateOrder(insertedCustomer.CustomerId, insertedCustomer.Country, _orderAmount);

            var orders = _orderService.GetOrdersByCustomerId(insertedCustomer.CustomerId);
            var insertedOrder = orders.FirstOrDefault(x => x.Amount == _orderDto.Amount);

            Assert.AreEqual(ordertoBeInserted.VAT, 0);
            Assert.IsTrue(insertedOrder.VAT == 0);
            Assert.AreEqual(insertedOrder.Amount, _orderDto.Amount);
        }

        //Test get all customers has orders
        [TestMethod]
        public void CanGetAllCustomersWithOrderLinked()
        {
            _customerRepositoryWrapper.Save(_customer3);
            var customersBeforeLink = _customerRepositoryWrapper.GetAllCustomers();
            //get the inserted customer
            var insertedCustomer = customersBeforeLink.Find(x => x.Name == Name3);
            _orderService.PlaceOrder(_orderDto, insertedCustomer.CustomerId);

            var ordertoBeInserted = _orderFactory.CreateOrder(insertedCustomer.CustomerId, insertedCustomer.Country, _orderAmount);

            var orders = _orderService.GetOrdersByCustomerId(insertedCustomer.CustomerId);
            var insertedOrder = orders.FirstOrDefault(x => x.Amount == _orderDto.Amount);

            var customersAfterLink = _customerRepositoryWrapper.GetAllCustomers();
            var customerWithOrder = customersAfterLink.FirstOrDefault(x => x.CustomerId == insertedCustomer.CustomerId);

            Assert.IsNotNull(customerWithOrder.Orders);
            Assert.IsTrue(customerWithOrder.Orders.Count > 0);

        }


    }
}
