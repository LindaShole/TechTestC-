using AnyCompany.Domain.Dto;
using AnyCompany.Domain.Entities;
using AnyCompany.Infrastructure.Interfaces.Factory;
using AnyCompany.Infrastructure.Interfaces.Repository;
using AnyCompany.Infrastructure.Interfaces.Services;
using AnyCompany.Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Services
{
    public class OrderService : IOrderService
    {
        public readonly IOrderRepository _orderRepository;
        public readonly ICustomerRepository _customerRepository;
        public readonly IOrderFactory _orderFactory;
        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, IOrderFactory orderFactory)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _orderFactory = orderFactory;
        }



        public bool PlaceOrder(OrderDto order, int customerId)
        {
            Customer customer = _customerRepository.Load(customerId);
            var orderEntity = _orderFactory.CreateOrder(customerId, customer.Country, order.Amount);
            _orderRepository.Save(orderEntity);
            return true;
        }

        public List<OrderDto> GetOrdersByCustomerId(int customerId)
        {
            var response = _orderRepository.GetOrdersByCustomerId(customerId);
            return OrderMapper.ToDto(response) ;

        }

    }
}

