using AnyCompany.Base.Domain.Contract;
using System;

namespace AnyCompany
{
    public class Customer : ICustomer
    {
        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Name { get; set; }
    }
}
