using System;

namespace AnyCompany.Infrastructure.Repository.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Name { get; set; }
    }
}
