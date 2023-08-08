using AnyCompany.Core;
using AnyCompany.Infrastructure.Repository.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Repository.CustomerRepository
{
    public static class CustomerRepository
    {
        private static ICustomerDapperRepository _customerDapperRepository;

        public static void InitRepo(ICustomerDapperRepository customerDapperRepository)
        {
            _customerDapperRepository = customerDapperRepository ?? throw new ArgumentNullException(nameof(customerDapperRepository));
        }

        public static async Task<Customer> Load(int customerId)
        {
            var customer = await _customerDapperRepository.GetById(customerId);
            
            return customer == null ? new Customer() : customer;
        }

        public static IEnumerable<Customer> GetAll()
        {
            return _customerDapperRepository.GetAll();
        }
    }
}
