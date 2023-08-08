using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Repository.Common
{
    public class Common
    {
        public static double GetCountryVAT(string country)
        {
            switch(country)
            {
                case "UK":
                    return 0.2d;
                case "ZA":
                    return 0.15d;
                default:
                    return 0;
            }
        }
    }
}
