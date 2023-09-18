using System;

namespace AnyCompany
{
    public class OrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICustomerRepository customerRepository;

         public OrderService(IOrderRepository orderRepo, ICustomerRepository customerRepo)
         {
                orderRepository = orderRepo ?? throw new ArgumentNullException(nameof(orderRepo));
                customerRepository = customerRepo ?? throw new ArgumentNullException(nameof(customerRepo));
         }


        public bool PlaceOrder(Order order, int customerId)
        {

             if (order == null || customerId <= 0)
            {
                // Input validation
                throw new ArgumentException("Invalid order or customerId");
            }
            
            Customer customer = CustomerRepository.Load(customerId);
            
            if (order.Amount == 0)
            {
                return false;
            }

            // Use constants for magic values
            const string UkCountryCode = "UK";
            const double UkVatRate = 0.2d;

            if (customer.Country == UkCountryCode)
            {
                order.VAT = UkVatRate;
            }
            else
            {
                order.VAT = 0;
            }

            // Error handling for data access operations
            try
            {
                orderRepository.Save(order);
                return true;
            }
            catch (Exception e)
            {
                // Handle the exception
                return false;
            }
        }
    }
}
