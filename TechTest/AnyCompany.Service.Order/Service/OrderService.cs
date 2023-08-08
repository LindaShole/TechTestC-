using AnyCompany.Core;
using AnyCompany.Infrastructure.Repository.Common;
using AnyCompany.Infrastructure.Repository.CustomerRepository;
using AnyCompany.Infrastructure.Repository.Model;
using AnyCompany.Infrastructure.Repository.OrderRepository;
using AnyCompany.Service.Order.Service;
using AnyCompany.ViewModel;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace AnyCompany.Service.Order.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        private readonly ICustomerDapperRepository _customerDapperRepository;

        private readonly IMapper _mapper;

        public OrderService(IMapper mapper,IOrderRepository orderRepository,ICustomerDapperRepository customerDapperRepository ,string orderConnectionString) { 
           
            _customerDapperRepository = customerDapperRepository;

            _orderRepository = orderRepository;

            _mapper = mapper;
        }

        public async Task<bool> PlaceOrder(OrderView order)
        {
            Customer customer = await CustomerRepository.Load(order.CustomerId);

            if (customer == null)
                return false;

            if (order.Amount == 0)
                return false;

            order.VAT = Common.GetCountryVAT(customer.Country);
            
            var currentOrder = _mapper.Map<Infrastructure.Repository.Model.Order>(order);
            _orderRepository.Save(currentOrder);

            return true;
        }
    }
}
