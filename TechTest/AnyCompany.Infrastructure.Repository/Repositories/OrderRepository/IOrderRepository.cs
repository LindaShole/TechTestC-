using AnyCompany.Core;
using AnyCompany.Infrastructure.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Repository.OrderRepository
{
    public interface IOrderRepository: IGenericDapperRepository<Order>
    {
        IEnumerable<Order> GetByCustomerIds(List<int> customerIds);

        void Save(Order order);
    }
}
