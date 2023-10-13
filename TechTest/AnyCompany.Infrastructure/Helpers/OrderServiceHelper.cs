using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Helpers
{
    public static class OrderServiceHelper
    {

        //get the VAT rate for a country based on the customer country
        public static double GetVATRate(string country)
        {
            switch (country)
            {
                case "UK":
                    return 0.2d;
                default:
                    return 0;
            }
        }

        //validate order amount
        public static double GetOrderAmount(double amount)
        {
            if (amount <= 0)
            {
                throw new Exception($"Invalid order amount : {amount}");
            }
            return amount;
        }

    }
}
