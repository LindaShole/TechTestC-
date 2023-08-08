using AnyCompany.Infrastructure.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Tests.Builders
{
    public class CustomerBuilder
    {
        public static Customer CustomerBuild(int customerId = 1,string country = "ZA",string name = "TechTest",DateTime? dateOfBirth = null) { 
        
            return new Customer { 
                CustomerId = customerId,
                Country = country,
                DateOfBirth = dateOfBirth ?? DateTime.Now,
                Name = name
            };

        }
    }
}
