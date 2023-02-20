using AnyCompany.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Interfaces
{
    public interface IOrderService
    {
        Task PlaceOrder(OrderDTO order);
        Task<IEnumerable<OrderDTO>> LoadCustomerOrders(int customerId);
    }
}
