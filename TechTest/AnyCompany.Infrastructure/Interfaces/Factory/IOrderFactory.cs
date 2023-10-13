using AnyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Interfaces.Factory
{
    public interface IOrderFactory
    {
        Order CreateOrder(int customerId, string country, double amount);
    }
}
