using AnyCompany.Base.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Base.IRepository
{
    public interface IOrderService
    {
        bool PlaceOrder(IOrder order, int customerId);
    }
}
