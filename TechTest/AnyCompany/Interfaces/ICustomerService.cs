using AnyCompany.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDTO> LoadCustomer(int customerId);
        Task<IEnumerable<CustomerDTO>> LoadCustomers();
    }
}
