using AnyCompany.Configurations;
using AnyCompany.DTOs;
using AnyCompany.Entities;
using AnyCompany.Interfaces;
using AnyCompany.Services;
using AnyCompany.Tests.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnyCompany.Tests
{
    public class CustomerServiceTests
    {
        private List<Customer> _customers;
        private ICustomerService _customerService;
        private Mock<AnyCompanyDbContext> _mockDbContext;

        public CustomerServiceTests()
        {
            _mockDbContext = new Mock<AnyCompanyDbContext>();
            _customers = new List<Customer>()
            {
                new Customer() { CustomerId = 1, Country = "USA", DateOfBirth = System.DateTime.Today, Name = "John Smith" },
                new Customer() { CustomerId = 2, Country = "UK", DateOfBirth = System.DateTime.Today, Name = "Alice Brown" },
                new Customer() { CustomerId = 3, Country = "France", DateOfBirth = System.DateTime.Today, Name = "Jean Dupont" },
            };

            var mockCustomerSet = _customers.AsQueryable().GetMockSet();
            mockCustomerSet.Setup(m => m.Include("Orders")).Returns(mockCustomerSet.Object);

            _mockDbContext.Setup(db => db.Customers).Returns(mockCustomerSet.Object);

            _customerService = new CustomerService(_mockDbContext.Object);
        }

        [Fact]
        public async void LoadCustomer_Valid_CustomerId_CustomerDTO()
        {
            //// Act
            var result = await _customerService.LoadCustomer(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CustomerDTO>(result);
            Assert.Equal(1, result.CustomerId);
            Assert.Equal("USA", result.Country);
            Assert.Equal("John Smith", result.Name);
            Assert.Equal(System.DateTime.Today, result.DateOfBirth);
        }

        [Fact]
        public async void LoadCustomer_DoesntExist_CustomerId_Null()
        {

            // Act
            var result = await _customerService.LoadCustomer(99);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async void LoadCustomers_Valid_Empty()
        {
            // Arrange
            var mockDbContext = new Mock<AnyCompanyDbContext>();
            var customers = new List<Customer>();
            var mockCustomerSet = customers.AsQueryable().GetMockSet();
            mockDbContext.Setup(db => db.Customers).Returns(mockCustomerSet.Object);
            var customerService = new CustomerService(mockDbContext.Object);

            // Act
            var results = await customerService.LoadCustomers();

            // Assert
            Assert.Empty(results);
        }

        [Fact]
        public async void LoadCustomers_Valid_NotEmpty()
        {
            // Act
            var results = await _customerService.LoadCustomers();

            // Assert
            Assert.Equal(3, results.Count());
            Assert.Equal("John Smith", results.ElementAt(0).Name);
            Assert.Equal("Alice Brown", results.ElementAt(1).Name);
            Assert.Equal("Jean Dupont", results.ElementAt(2).Name);

        }
    }
}
