using AnyCompany.Core;
using AnyCompany.Infrastructure.Repository;
using AnyCompany.Infrastructure.Repository.Core;
using AnyCompany.Infrastructure.Repository.Model;
using AnyCompany.Infrastructure.Repository.OrderRepository;
using AnyCompany.Tests.Builders;
using AnyCompany.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.UnitTests.Repositories
{
    [TestClass]
    public class OrderRepositoryTests
    {
        private readonly Mock<IDapperDbContext> _dapperDbContext;
        private readonly DapperInMemoryDatabase _dapperInMemoryDatabase;

        public OrderRepositoryTests()
        {
            _dapperInMemoryDatabase = new DapperInMemoryDatabase();
            _dapperDbContext = new Mock<IDapperDbContext>();
            _dapperDbContext.Setup(x => x.CreateConnection(It.IsAny<ConnectionType>())).Returns(_dapperInMemoryDatabase.CreateConnection());
        }

        [TestMethod]
        public void OrderRepository_GetByCustomerIds()
        {
            //Arrange
            var orderRepository = new OrderRepository(_dapperDbContext.Object);
            var expectedOrderId = 2903;
            var expectedCustomerId = 48393;
            var expectedOrder = OrderBuilder.OrderBuild(expectedOrderId, expectedCustomerId);
            _dapperInMemoryDatabase.InsertData(new List<Order> { expectedOrder,OrderBuilder.OrderBuild() });

            //Act
            var resultOrder = orderRepository.GetByCustomerIds(new List<int> { expectedCustomerId });

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
