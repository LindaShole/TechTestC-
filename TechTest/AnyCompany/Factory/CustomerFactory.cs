using AnyCompany.Domain.Entities;
using AnyCompany.Infrastructure.Interfaces.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Factory
{
    public class CustomerFactory : ICustomerFactory
    {
        public Customer CreateCustomer(string name, string country, DateTime dateOfBirth)
        {
            if(dateOfBirth < DateTime.Now.AddYears(-1))
            {
                throw new Exception("Customer must be atleast 1 years old");
            }
            return new Customer
            {
                Name = name,
                Country = country,
                DateOfBirth = dateOfBirth
            };
        }
    }
}
