using AnyCompany.Core;
using AnyCompany.Infrastructure.Repository;
using AnyCompany.Infrastructure.Repository.Core;
using AnyCompany.Infrastructure.Repository.OrderRepository;
using AnyCompany.Tests.Builders;
using AnyCompany.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.UnitTests.IntegrationTests
{
    [TestClass]
    public class OrderRepositoryIntegrationTests
    {
        private readonly IDapperDbContext _dapperDbContext;

        private readonly Mock<IConnectionDbFactory> _configurationSettings;

        public OrderRepositoryIntegrationTests()
        {

            _configurationSettings = new Mock<IConnectionDbFactory>();

            _configurationSettings.Setup(x => x.CreateConnection(It.IsAny<ConnectionType>())).Returns(@"Data Source=localhost\dev2019;Database=Orders;User Id=admin;Password=password;");


            _dapperDbContext = new DapperDbContext(_configurationSettings.Object);

        }

        [TestMethod]
        public void OrderRepository_SaveOrder()
        {
            //Arrange
            
            var orderRepository = new OrderRepository(_dapperDbContext);
            var expectedOrderId = 2903;
            var expectedCustomerId = 48393;
            var expectedOrder = OrderBuilder.OrderBuild(expectedOrderId, expectedCustomerId);

            //Act
           
            orderRepository.Save(expectedOrder);
            var resultOrder = orderRepository.GetByCustomerIds(new List<int> { expectedOrderId });

            //Assert
            var orderResult = resultOrder.FirstOrDefault();
            Assert.AreEqual(1, resultOrder.Count());
            Assert.AreEqual(expectedOrder.OrderId, orderResult.OrderId);
            Assert.AreEqual(expectedOrder.Amount, orderResult.Amount);
            Assert.AreEqual(expectedOrder.CustomerId, orderResult.CustomerId);
            Assert.AreEqual(expectedOrder.VAT, orderResult.VAT);
        }
    }

}
