using AnyCompany.Domain.Entities;
using System.Collections.Generic;

namespace AnyCompany.Infrastructure.Interfaces.Repository
{
    public interface ICustomerRepository
    {

        List<Customer> GetAllCustomers();

        Customer Load(int customerId);

        void Save(Customer customer);

    }
}
