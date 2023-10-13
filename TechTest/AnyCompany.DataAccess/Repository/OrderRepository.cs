using AnyCompany.Domain.Entities;
using AnyCompany.Infrastructure.Interfaces.Repository;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace AnyCompany.DataAccess.Repository
{
    /// <summary>
    /// Order repository class
    /// </summary>
    public class OrderRepository : IOrderRepository
    {

        /// <summary>
        /// Create order
        /// </summary>
        /// <param name="order"></param>
        public void Save(Order order)
        {
            using (var unitOfWork = new UnitOfWork.UnitOfWork())
            {
                //Use Dapper to query the database
                // new { OrderId = order.OrderId, Amount = order.Amount, VAT = order.VAT, CustomerId = order.CustomerId }

                var query = "INSERT INTO [Orders] (Amount, VAT, CustomerId) VALUES (@Amount, @VAT, @CustomerId)";
                var output = unitOfWork.GetConnection().QueryFirstOrDefault<Order>(query, order,
                    unitOfWork.GetTransaction());
                //commit the transaction
                unitOfWork.Commit();

            }
        }

        /// <summary>
        /// get orders by customer id
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <returns>List of Orders</returns>
        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            List<Order> orders = new List<Order>();
            using (var unitOfWork = new UnitOfWork.UnitOfWork())
            {
                //Use Dapper to query the database
                var query = "SELECT * FROM [Orders] WHERE CustomerId = @CustomerId";
                orders = unitOfWork.GetConnection().Query<Order>(query, new { CustomerId = customerId }, unitOfWork.GetTransaction()).ToList();

            }
            return orders;
        }
    }
}
