using AnyCompany.DataAccess.Repository;
using AnyCompany.Domain.Entities;
using AnyCompany.Infrastructure.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AnyCompany.Tests
{

    [TestClass]
    public class CustomerRepositoryWrapperTest
    {

        //test CustomerRepositoryWrapper

        private CustomerRepositoryWrapper _customerRepositoryWrapper;
        private Customer _customer;
        private static Random _ran = new Random();


        private string Name = Guid.NewGuid().ToString();
        private string Country = CountryEnum.UK.ToString();
        private DateTime DateOfBirth = DateTime.MinValue.Add(
            TimeSpan.FromTicks((long)(_ran.NextDouble() * DateTime.MaxValue.Ticks)));


        [TestInitialize]
        public void Setup()
        {
            _customerRepositoryWrapper = new CustomerRepositoryWrapper();
            _customer = new Customer
            {
                 Name = Name,
                Country = Country,
                DateOfBirth = DateOfBirth
            };
        }

        [TestMethod]
        public void Can_Get_All_Customers()
        {
            var customers = _customerRepositoryWrapper.GetAllCustomers();
            Assert.IsNotNull(customers);
        }

        [TestMethod]
        public void Can_Save_Customer()
        {

            _customerRepositoryWrapper.Save(_customer);
            var customers = _customerRepositoryWrapper.GetAllCustomers();
            //get the inserted customer
            var insertedCustomer = customers.Find(x => x.Name == Name);
            Assert.AreEqual(insertedCustomer.Name, _customer.Name);
        }

 
        [TestMethod]
        public void Can_Get_Customer_By_Id()
        {
            var customers = _customerRepositoryWrapper.GetAllCustomers();
            var firstCustomer = customers.FirstOrDefault();
            var customer = _customerRepositoryWrapper.Load(firstCustomer.CustomerId);
            Assert.IsNotNull(customer);
            Assert.AreEqual(customer.Name, firstCustomer.Name);
        }
    }
}
