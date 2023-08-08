using AnyCompany.Core;
using AnyCompany.Infrastructure.Repository;
using AnyCompany.Infrastructure.Repository.Core;
using AnyCompany.Infrastructure.Repository.CustomerRepository;
using AnyCompany.Infrastructure.Repository.Model;
using AnyCompany.Tests.Builders;
using AnyCompany.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnyCompany.Tests.Repositories
{
    [TestClass]
    public class CustomerDapperRepositoryTests
    {
        private readonly Mock<IDapperDbContext> _dapperDbContext;
        private readonly DapperInMemoryDatabase _dapperInMemoryDatabase;

        public CustomerDapperRepositoryTests()
        {
            _dapperInMemoryDatabase = new DapperInMemoryDatabase();
            _dapperDbContext = new Mock<IDapperDbContext>();
            _dapperDbContext.Setup(x => x.CreateConnection(It.IsAny<ConnectionType>())).Returns(_dapperInMemoryDatabase.CreateConnection());
        }

        [TestMethod]
        public void CustomerDapperRepository_GetCustomerById()
        {
            //Arrange
            var customerRepository = new CustomerDapperRepository(_dapperDbContext.Object);
            var expectedCustomerId = 2903;
            var expectedCustomer = CustomerBuilder.CustomerBuild(expectedCustomerId);
            var customers = new List<Customer> { 
                CustomerBuilder.CustomerBuild(1, "John", "UK", DateTime.Parse("1965-10-23")),
                expectedCustomer,
                CustomerBuilder.CustomerBuild(234,"ZIM","Vox",DateTime.Parse("2000-01-23"))
            }.AsEnumerable();

            //Act
            _dapperInMemoryDatabase.InsertData<Customer>(customers);
            var result = customerRepository.GetById(expectedCustomerId).Result;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCustomer.Name, result.Name);
            Assert.AreEqual(expectedCustomer.Country, result.Country);
            Assert.AreEqual(expectedCustomer.DateOfBirth, result.DateOfBirth);
            Assert.AreEqual(expectedCustomer.CustomerId, result.CustomerId);
        }

        [TestMethod]
        public void CustomerDapperRepository_GetCustomerById_Customer_Does_Not_Exist()
        {
            //Arrange
            var customerRepository = new CustomerDapperRepository(_dapperDbContext.Object);
            var expectedCustomerId = 2903;
            var customers = new List<Customer> {
                CustomerBuilder.CustomerBuild(1, "John", "UK", DateTime.Parse("1965-10-23")),
                CustomerBuilder.CustomerBuild(31),
                CustomerBuilder.CustomerBuild(234,"ZIM","Vox",DateTime.Parse("2000-01-23"))
            }.AsEnumerable();

            //Act
            _dapperInMemoryDatabase.InsertData<Customer>(customers);
            var result =  customerRepository.GetById(expectedCustomerId).Result;

            //Assert
            Assert.IsNull(result);
        }


        [TestMethod]
        public void CustomerDapperRepository_GetAll() {
            //Arrange
            var customerRepository = new CustomerDapperRepository(_dapperDbContext.Object);
            var expectedCount = 3;
            var customers = new List<Customer> {
                CustomerBuilder.CustomerBuild(1, "John", "UK", DateTime.Parse("1965-10-23")),
                CustomerBuilder.CustomerBuild(31),
                CustomerBuilder.CustomerBuild(234,"ZIM","Vox",DateTime.Parse("2000-01-23"))
            }.AsEnumerable();

            //Act
            _dapperInMemoryDatabase.InsertData<Customer>(customers);
            var result = customerRepository.GetAll();

            //Assert
            Assert.AreEqual(expectedCount, result.Count());
        }

        [TestMethod]
        public void CustomerDapperRepository_GetAll_No_Customers_Exist()
        {
            var customerRepository = new CustomerDapperRepository(_dapperDbContext.Object);
            
            var customers = new List<Customer> {
            }.AsEnumerable();

            //Act
            _dapperInMemoryDatabase.InsertData<Customer>(customers);
            var result = customerRepository.GetAll();

            //Assert
            Assert.AreEqual(0,result.Count());
        }
    }
}
