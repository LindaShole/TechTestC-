using AnyCompany.Domain;
using AnyCompany.Repository.IRepository;

namespace AnyCompany
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public bool PlaceOrder(Order order, int customerId)
        {
            Customer customer = _customerRepository.Load(customerId);

            if (order.Amount <= 0)
                return false;

            order.VAT = customer.Country == "UK" ? 0.2d : 0;

            _orderRepository.Save(order);

            return true;
        }
    }
}
