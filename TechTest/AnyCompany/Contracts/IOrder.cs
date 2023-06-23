using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Contracts
{
    public interface IOrder
    {
        int OrderId { get; set; }
        double Amount { get; set; }
        double VAT { get; set; }
        int CustomerId { get; set; }
    }
}
