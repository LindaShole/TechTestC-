using AnyCompany.Infrastructure.Repository.CustomerRepository;
using AnyCompany.Infrastructure.Repository.OrderRepository;
using AnyCompany.UnitTests.Helpers;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.UnitTests.Services
{
    [TestClass]
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _orderRepository;

        private readonly Mock<ICustomerDapperRepository> _customerDapperRepository;

        private readonly IMapper _mapper;

        public OrderServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMappingTest());
            });
            _orderRepository = new Mock<IOrderRepository>();
            _customerDapperRepository = new Mock<ICustomerDapperRepository>();
            _mapper = config.CreateMapper();

        }


    }
}
