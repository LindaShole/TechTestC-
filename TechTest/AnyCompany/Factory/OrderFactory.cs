using AnyCompany.Domain.Entities;
using AnyCompany.Infrastructure.Helpers;
using AnyCompany.Infrastructure.Interfaces.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Factory
{
    public class OrderFactory : IOrderFactory
    {
        public Order CreateOrder(int customerId, string country, double amount)
        {

            return new Order
            {
                CustomerId = customerId,
                Amount = OrderServiceHelper.GetOrderAmount(amount),
                VAT = OrderServiceHelper.GetVATRate(country),

            };
        }
    }
}
