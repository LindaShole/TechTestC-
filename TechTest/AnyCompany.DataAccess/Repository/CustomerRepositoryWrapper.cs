using AnyCompany.Domain.Entities;
using AnyCompany.Infrastructure.Interfaces.Repository;
using System.Collections.Generic;

namespace AnyCompany.DataAccess.Repository
{
    /// <summary>
    /// Customer repository wrapper class
    /// </summary>
    public class CustomerRepositoryWrapper : ICustomerRepository
    {

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomers()
        {
            return CustomerRepository.GetAllCustomers();
        }


        /// <summary>
        /// Load customer by id
        /// </summary>
        /// <param name="customerId">Cutsomer Id</param>
        /// <returns></returns>
        public Customer Load(int customerId)
        {
            return CustomerRepository.Load(customerId);
        }

        public void Save(Customer customer)
        {
            CustomerRepository.Save(customer);
        }
    }
}
