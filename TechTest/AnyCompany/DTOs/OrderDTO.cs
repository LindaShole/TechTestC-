using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; private set; }
        public double Amount { get; set; }
        public double VAT { get; private set; }
        public int CustomerId { get; set; }

        public string CustomerName { get; private set; }
    }
}
