using AnyCompany.Infrastructure.Repository.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Repository
{
    public interface IDapperDbContext
    {
        IDbConnection CreateConnection(ConnectionType connectionType);
    }
}
