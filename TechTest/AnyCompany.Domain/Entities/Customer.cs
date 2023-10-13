using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Name { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

    }
}