using AnyCompany.Infrastructure.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Tests.Builders
{
    public class OrderBuilder
    {
        public static Order OrderBuild(int orderId = 12, int customerId = 1,double amount = 2.33,double vat = 15.00) {

            return new Order
            {
                CustomerId = customerId,
                Amount = amount,
                OrderId = orderId,
                VAT = vat
            };
        }
    }
}
