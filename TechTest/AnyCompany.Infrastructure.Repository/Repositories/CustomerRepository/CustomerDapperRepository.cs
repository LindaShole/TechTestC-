using AnyCompany.Core;
using AnyCompany.Infrastructure.Repository.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Repository.CustomerRepository
{
    public class CustomerDapperRepository : GenericDapperRepository<Customer>, ICustomerDapperRepository
    {
        private static readonly string CUSTOMER_BY_ID_SQL = "SELECT * FROM Customer WHERE CustomerId = @CustomerId";

        private static readonly string ALL_CUSTOMERS_SQL = "SELECT * FROM Customer";

        public CustomerDapperRepository(IDapperDbContext dbContext) : base(dbContext,Core.ConnectionType.Customer)
        {
            
        }

        public IEnumerable<Customer> GetAll()
        {
            return Query(ALL_CUSTOMERS_SQL);
        }

        public async Task<Customer> GetById(int customerId)
        {
            var param = new DynamicParameters();
            param.Add("@CustomerId", customerId, System.Data.DbType.Int32);

            return await QueryFirstOrDefaultAsync(CUSTOMER_BY_ID_SQL, param);
        }
    }
}
