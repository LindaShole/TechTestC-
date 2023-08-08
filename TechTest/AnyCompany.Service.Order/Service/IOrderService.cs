using AnyCompany.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Service.Order.Service
{
    public interface IOrderService
    {
        Task<bool> PlaceOrder(OrderView order);

        
    }
}
