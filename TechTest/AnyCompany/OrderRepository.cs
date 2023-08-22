using System.Data.SqlClient;

namespace AnyCompany
{
    public class OrderRepository
    {
        private static string ConnectionString = @"Data Source=(local);Database=Orders;User Id=admin;Password=password;";

        public void Save(Order order, int customerId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Orders (CustomerId, OrderId, Amount, VAT) VALUES (@CustomerId, @OrderId, @Amount, @VAT)", connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    command.Parameters.AddWithValue("@OrderId", order.OrderId);
                    command.Parameters.AddWithValue("@Amount", order.Amount);
                    command.Parameters.AddWithValue("@VAT", order.VAT);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
