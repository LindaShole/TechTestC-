using AnyCompany.IRepository;
using AnyCompany.Contracts;
using System;

namespace AnyCompany
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository = new OrderRepository();

        public bool PlaceOrder(IOrder order, int customerId)
        {
            try {

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
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
