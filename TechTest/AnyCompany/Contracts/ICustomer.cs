using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Contracts
{
    public interface ICustomer
    {
        int CustomerID { get; set; }
        string Country { get; set; }

        DateTime DateOfBirth { get; set; }

        string Name { get; set; }
    }
}
