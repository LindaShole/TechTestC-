using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Base.Domain.Contract
{
    public interface ICustomer
    {
        string Country { get; set; }

        DateTime DateOfBirth { get; set; }

        string Name { get; set; }
    }
}
