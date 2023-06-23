using AnyCompany.Contracts;
using AnyCompany.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany
{
    public static class Factory
    {
        public static Order CreateOrder()
        {
            return new Order();
        }

        public static Customer CreateCustomer()
        {
            return new Customer();
        }

        public static IOrderRepository CreateOrderRepository()
        {
            return new OrderRepository();
        }

        public static IOrderService CreateOrderService()
        {
            return new OrderService();
        }
    }
}
