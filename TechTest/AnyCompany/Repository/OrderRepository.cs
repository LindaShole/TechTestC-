using AnyCompany.Repository.IRepository;
using System.Data.SqlClient;

namespace AnyCompany
{
    internal class OrderRepository : IOrderRepository
    {
        private static string ConnectionString = @"Data Source=(local);Database=Orders;User Id=admin;Password=password;";
        private const string InsertOrderQuery = "INSERT INTO Orders (OrderId, Amount, VAT) VALUES (@OrderId, @Amount, @VAT)";
        public void Save(Order order)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(InsertOrderQuery, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", order.OrderId);
                    command.Parameters.AddWithValue("@Amount", order.Amount);
                    command.Parameters.AddWithValue("@VAT", order.VAT);

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
    }
}
