using AnyCompany.Infrastructure.Repository.CustomerRepository;
using AnyCompany.Infrastructure.Repository.Model;
using AnyCompany.Infrastructure.Repository.OrderRepository;
using AnyCompany.Service.Customer.ViewModel;
using AnyCompany.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Service.Customer.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IMapper _mapper;

        private readonly ICustomerDapperRepository _customerDapperRepository;

        public CustomerService(IMapper mapper,IOrderRepository orderRepository,ICustomerDapperRepository customerDapperRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            
            _customerDapperRepository = customerDapperRepository ?? throw new ArgumentNullException(nameof(customerDapperRepository));

            CustomerRepository.InitRepo(_customerDapperRepository);
        }


        public IEnumerable<CustomerOrdersView> GetAllCustomerOrders()
        {
            var allCustomerOrders = new List<CustomerOrdersView>();


            var allCustomers = CustomerRepository.GetAll(); //method injection as static repo can't be decoupled

            if (allCustomers.Any())
            {
                var allCustomerIds = allCustomers.Select(cs => cs.CustomerId).ToList();
                var allOrders = _orderRepository.GetByCustomerIds(allCustomerIds);
                foreach (var currentCustomer in allCustomers)
                {
                    var currentCustomerOrders = allOrders.Where(o => o.CustomerId == currentCustomer.CustomerId).ToList();
                    var mappedCustomer = _mapper.Map<CustomerView>(currentCustomer);
                    var mappedOrders = _mapper.Map<List<OrderView>>(currentCustomerOrders);
                    allCustomerOrders.Add(new CustomerOrdersView { Customer = mappedCustomer, Orders = mappedOrders });
                }
            }
            return allCustomerOrders.AsEnumerable();
        }

    }
    
}
