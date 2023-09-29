using AnyCompany.Domain.Dto;
using AnyCompany.Infrastructure.Interfaces.Factory;
using AnyCompany.Infrastructure.Interfaces.Repository;
using AnyCompany.Infrastructure.Interfaces.Services;
using AnyCompany.Infrastructure.Mapper;
using System.Collections.Generic;
using System.Linq;

namespace AnyCompany.Services
{
    public class CustomerService : ICustomerService
    {
        public readonly ICustomerRepository _customerRepository;
        public readonly ICustomerFactory _customerFactory;


        public CustomerService(ICustomerRepository customerRepository, ICustomerFactory customerFactory)
        {
            _customerRepository = customerRepository;
            _customerFactory = customerFactory;
        }
        public List<CustomerDto> GetAllCustomers()
        {
            var response = _customerRepository.GetAllCustomers();
            return CustomerMapper.MapToCustomerDtoList(response);

        }

        public CustomerDto Load(int customerId)
        {
            var response = _customerRepository.Load(customerId);
            return new CustomerDto
            {
                Country = response.Country,
                DateOfBirth = response.DateOfBirth,
                Name = response.Name,
                Orders = OrderMapper.ToDto(response.Orders)
            };

        }

        public void Save(CustomerDto customer)
        {
            var customerEntity = _customerFactory.CreateCustomer(customer.Name,  customer.Country, customer.DateOfBirth);
            _customerRepository.Save(customerEntity);
        }
    }
}
