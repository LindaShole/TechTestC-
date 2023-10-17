using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyCompany.Entities
{
    public class Customer
    {
        [DisplayName("ID")]
        public int CustomerId { get; set; }
        public string Country { get; set; }

        [DisplayName("Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateOfBirth { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
