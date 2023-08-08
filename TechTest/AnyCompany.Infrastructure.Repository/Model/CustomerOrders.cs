using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Repository.Model
{
    public class CustomerOrders
    {
        public Customer Customer { get; set; } = new Customer();

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
