using AnyCompany.Core;
using AnyCompany.Infrastructure.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Repository.CustomerRepository
{
    public interface ICustomerDapperRepository : IGenericDapperRepository<Customer>
    {
        Task<Customer> GetById(int customerId);

        IEnumerable<Customer> GetAll();
    }
}
