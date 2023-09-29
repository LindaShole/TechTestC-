using AnyCompany.DataAccess.Repository;
using AnyCompany.Domain.Dto;
using AnyCompany.Factory;
using AnyCompany.Infrastructure.Helpers;
using AnyCompany.Infrastructure.Interfaces.Factory;
using AnyCompany.Infrastructure.Interfaces.Repository;
using AnyCompany.Infrastructure.Interfaces.Services;
using AnyCompany.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AnyCompany.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        public ICustomerService _customerService;
        private CustomerRepositoryWrapper _customerRepository;
        private CustomerFactory _customerFactory;
        private static Random _ran = new Random();

        private string Name = Guid.NewGuid().ToString();
        private string Country = CountryEnum.UK.ToString();
        private DateTime DateOfBirth = DateTime.MinValue.Add(
            TimeSpan.FromTicks((long)(_ran.NextDouble() * DateTime.MaxValue.Ticks)));

        private CustomerDto _customer;

        [TestInitialize]
        public void Setup()
        {
            _customerFactory = new CustomerFactory();
            _customerRepository = new CustomerRepositoryWrapper();
            _customerService = new CustomerService(_customerRepository, _customerFactory);
             _customer = new CustomerDto
            {
                Name = Name,
                Country = Country,
                DateOfBirth = DateOfBirth
             };

        }


        [TestMethod]
        public void CanGetAllCustomer()
        {
            var response = _customerService.GetAllCustomers();
            Assert.IsNotNull(response);
        }


        [TestMethod]
        public void CanInsertCustomer()
        {
            _customerService.Save(_customer);
            var response = _customerService.GetAllCustomers();

            var insertedCustomer = response.Find(x => x.Name == Name);
            Assert.AreEqual(insertedCustomer.Name, _customer.Name);
        }


        [TestMethod]
        public void CanGetAllCustomersWithOrders()
        {
            var response = _customerService.GetAllCustomers();
            Assert.IsNotNull(response);
        }

    }
}
