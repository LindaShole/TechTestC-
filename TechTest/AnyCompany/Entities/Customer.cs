using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnyCompany.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}
