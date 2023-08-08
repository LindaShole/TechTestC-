using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AnyCompany.Tests.Helpers
{
    public class DapperInMemoryDatabase
    {
        private readonly OrmLiteConnectionFactory ormLiteConnectionFactory = new OrmLiteConnectionFactory(":memory:",SqliteOrmLiteDialectProvider.Instance) ;

        public IDbConnection CreateConnection() => ormLiteConnectionFactory.OpenDbConnection();

        public void InsertData<T>(IEnumerable<T> data)
        {

            using (var conn = ormLiteConnectionFactory.OpenDbConnection()) {
                conn.CreateTableIfNotExists<T>();
                conn.InsertAll<T>(data);
            }
        }
    }
}
