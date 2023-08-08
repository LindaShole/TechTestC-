using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Repository.Core
{
    public class ConnectionDbFactory : IConnectionDbFactory
    {
        public string CreateConnection(ConnectionType connectionType)
        {
            switch (connectionType) {

                case ConnectionType.Order:
                    return ConfigurationManager.ConnectionStrings["CustomerConnectionString"].ConnectionString;
                case ConnectionType.Customer:
                    return ConfigurationManager.ConnectionStrings["OrderConnectionString"].ConnectionString;
                
            }
            return "";
        }

    }
}
