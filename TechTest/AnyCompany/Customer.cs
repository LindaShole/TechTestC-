using System;
using System.Collections.Generic;

namespace AnyCompany
{
    public class Customer
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }

        public Customer(string name, DateTime dateOfBirth, string country)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Country = country;
            Orders = new List<Order>();
        }
    }
}
