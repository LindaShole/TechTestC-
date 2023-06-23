using AnyCompany.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.IRepository
{
    public interface ICustomerService
    {
        void LoadCustomer(ICustomer customer);
    }
}
