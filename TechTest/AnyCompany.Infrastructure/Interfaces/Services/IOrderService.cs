using AnyCompany.Domain.Dto;
using AnyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Interfaces.Services
{
    public interface IOrderService
    {
        bool PlaceOrder(OrderDto order, int customerId);

        List<OrderDto> GetOrdersByCustomerId(int customerId);

    }
}
