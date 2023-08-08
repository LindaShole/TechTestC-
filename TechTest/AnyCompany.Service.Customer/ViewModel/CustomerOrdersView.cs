using AnyCompany.Infrastructure.Repository.Model;
using AnyCompany.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Service.Customer.ViewModel
{
    public class CustomerOrdersView
    {
        public CustomerView Customer { get; set; } = new CustomerView();

        public List<OrderView> Orders { get; set; } = new List<OrderView>();
    }
}
