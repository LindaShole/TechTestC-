using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; private set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }

        public int? NumberOfOrders { get; private set; }
    }
}
