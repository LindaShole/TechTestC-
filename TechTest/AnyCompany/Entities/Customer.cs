using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnyCompany.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }

        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}
