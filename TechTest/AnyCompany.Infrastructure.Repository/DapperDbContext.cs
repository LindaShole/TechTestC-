using AnyCompany.Core;
using AnyCompany.Infrastructure.Repository.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Repository
{
    public class DapperDbContext : IDapperDbContext
    {
        private readonly IConnectionDbFactory _connectionDbFactory;

        public DapperDbContext(IConnectionDbFactory configurationSettings)
        {
            _connectionDbFactory = configurationSettings;
        }

        public IDbConnection CreateConnection(ConnectionType connectionType)
        {
            return new SqlConnection(_connectionDbFactory.CreateConnection(connectionType));
        }
    }
}
