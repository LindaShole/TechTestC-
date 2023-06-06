using AnyCompany.Base.Domain.Contract;
using AnyCompany.Base.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Base
{
    public static class Factory
    {
        public static IOrder CreateOrder()
        {
            return new Order();
        }

        public static ICustomer CreateCustomer()
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
