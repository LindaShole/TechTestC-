using AnyCompany.Entities;
using AnyCompany.Repositories;
using System.Collections.Generic;

namespace AnyCompany.Services
{
    public static class OrderService
    {
        private static readonly OrderRepository orderRepository = new OrderRepository();

        public static bool PlaceOrder(Order order, int customerId)
        {
            Customer customer = CustomerRepository.Load(customerId);

            if (order.Amount == 0)
                return false;

            if (customer.Country == "UK")
                order.VAT = 0.2d;
            else
                order.VAT = 0;

            orderRepository.Save(order);

            return true;
        }

        public static List<Order> GetOrdersForCustomer(int customerId) 
        {
            return orderRepository.GetOrdersForCustomer(customerId);
        }
    }
}
