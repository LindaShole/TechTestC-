using AnyCompany.Infrastructure.Repository.CustomerRepository;
using AnyCompany.Infrastructure.Repository.Model;
using AnyCompany.Infrastructure.Repository.OrderRepository;
using AnyCompany.Service.Customer.Service;
using AnyCompany.Tests.Builders;
using AnyCompany.UnitTests.Helpers;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnyCompany.UnitTests.Services
{
    [TestClass]
    public class CustomerServiceTests
    {
        private readonly Mock<IOrderRepository> _orderRepository;

        private readonly IMapper _mapper;

        private readonly Mock<ICustomerDapperRepository> _customerDapperRepository;

        public CustomerServiceTests() {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMappingTest());
            });
            _orderRepository = new Mock<IOrderRepository>();
            _customerDapperRepository = new Mock<ICustomerDapperRepository>();
            _mapper = config.CreateMapper();
        }

        [TestMethod]
        public void CustomerService_GetAllCustomerOrders() {

            //arrange
            var firstCustomerId = 123;
            var secondCustomerId = 44;

            var allCustomers = new List<Customer> { CustomerBuilder.CustomerBuild(firstCustomerId),
                CustomerBuilder.CustomerBuild(secondCustomerId,"KEN","Izomi",DateTime.Parse("1995-07-07")) };

            var allOrders = new List<Order> { OrderBuilder.OrderBuild(customerId:secondCustomerId), 
                OrderBuilder.OrderBuild(customerId: firstCustomerId,orderId:4483,amount:483),
                OrderBuilder.OrderBuild(customerId:firstCustomerId,orderId:44831,amount:49400)};

            _customerDapperRepository.Setup(cr => cr.GetAll()).Returns(allCustomers);
            _orderRepository.Setup(or => or.GetByCustomerIds(It.IsAny<List<int>>())).Returns(allOrders);

            var customerService = new CustomerService(_mapper, _orderRepository.Object, _customerDapperRepository.Object);

            //act
            var allCustomerOrders = customerService.GetAllCustomerOrders();

            //assert
            var resultFirstCustomerOrders = allCustomerOrders.Where(c => c.Customer.CustomerId == firstCustomerId).FirstOrDefault();
            var resultSecondCustomerOrders = allCustomerOrders.Where(c => c.Customer.CustomerId == secondCustomerId).FirstOrDefault();

            Assert.IsNotNull(allCustomerOrders);
            Assert.AreEqual(2, allCustomerOrders.Count());
            Assert.AreEqual(2, resultFirstCustomerOrders.Orders.Count());
            Assert.AreEqual(1, resultSecondCustomerOrders.Orders.Count());
            Assert.IsFalse(resultFirstCustomerOrders.Orders.Exists(o => o.CustomerId != firstCustomerId));
            Assert.IsFalse(resultSecondCustomerOrders.Orders.Exists(o => o.CustomerId != secondCustomerId));
        }
    }
}
