using AnyCompany.Service.Customer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Service.Customer.Service
{
    public interface ICustomerService
    {
        IEnumerable<CustomerOrdersView> GetAllCustomerOrders();
    }
}
