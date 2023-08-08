using AnyCompany.Core;
using Dapper;
using System.Collections.Generic;
using AnyCompany.Infrastructure.Repository.Model;
using System.Linq;

namespace AnyCompany.Infrastructure.Repository.OrderRepository
{
    public class OrderRepository : GenericDapperRepository<Order>, IOrderRepository
    {

        private static readonly string CREATE_ORDER_SQL = "INSERT INTO [Order] (OrderId,Amount,VAT,CustomerId) VALUES (@OrderId, @Amount, @VAT,@CustomerId)";

        private static readonly string ORDERS_BY_CUSTOMDER_IDS_SQL = "SELECT * FROM [Order] WHERE 1 = 1";
        
        public OrderRepository(IDapperDbContext dbContext) : base(dbContext, Core.ConnectionType.Customer)
        {
        }

        public IEnumerable<Order> GetByCustomerIds(List<int> customerIds)
        {
            var fileSQL = ORDERS_BY_CUSTOMDER_IDS_SQL + " AND CustomerId IN (" + string.Join(",", customerIds.Select(x => x)) + ")";
            return Query(fileSQL);
        }

        public async void Save(Order order)
        {
            var param = new DynamicParameters();

            param.Add("@OrderId", order.OrderId,System.Data.DbType.Int32); //Assume orderId is primary key which is incremental
            param.Add("@Amount", order.Amount,System.Data.DbType.Double);
            param.Add("@VAT", order.VAT,System.Data.DbType.Double);
            param.Add("@CustomerId", order.CustomerId,System.Data.DbType.Int32);

            await ExecuteAsync(CREATE_ORDER_SQL,param);
        }
    }
}
