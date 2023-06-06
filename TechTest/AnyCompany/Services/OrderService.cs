using AnyCompany.Base;
using AnyCompany.Base.Domain.Contract;
using AnyCompany.Base.IRepository;
using System;
using System.Collections.Generic;

namespace AnyCompany
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository = Factory.CreateOrderRepository();

        public bool PlaceOrder(IOrder order, int customerId)
        {
            try
            {
                ICustomer customer = CustomerRepository.Load(customerId);

                if (order.Amount == 0)
                    return false;

                if (customer.Country == "UK")
                {
                    order.VAT = 0.2d;
                    order.CustomerId = customerId;
                }
                else
                {
                    order.VAT = 0;
                    order.CustomerId = customerId;
                }

                orderRepository.Save(order);

                return true;
            }
            catch (Exception ex)
            {
                //Log exception
               return false;
            }
        }
    }
}
