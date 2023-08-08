using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Repository.Core
{
    public interface IConnectionDbFactory
    {
        string CreateConnection(ConnectionType connectionType);
    }
}
