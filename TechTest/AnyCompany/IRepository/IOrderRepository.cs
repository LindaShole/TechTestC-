using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyCompany.Contracts;

namespace AnyCompany.IRepository
{
    public interface IOrderRepository
    {
        void Save(IOrder order);
    }
}
