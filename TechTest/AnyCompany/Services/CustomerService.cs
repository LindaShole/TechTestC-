using AnyCompany.Entities;
using AnyCompany.Repositories;
using System.Collections.Generic;

namespace AnyCompany.Services
{
    public static class CustomerService
    {
        public static List<Customer> GetAllCustomers()
        {
            return CustomerRepository.LoadAll();
        }

        public static Customer GetCustomerById(int id)
        {
            return CustomerRepository.Load(id);
        }

        public static int AddCustomer(Customer customer)
        {
            return CustomerRepository.AddCustomer(customer);
        }
    }
}
