using AnyCompany.Domain.Entities;
using System.Collections.Generic;

namespace AnyCompany.Infrastructure.Interfaces.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetOrdersByCustomerId(int customerId);

        void Save(Order order);
    }
}
