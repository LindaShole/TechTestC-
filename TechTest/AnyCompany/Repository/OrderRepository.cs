using AnyCompany.IRepository;
using System.Data.SqlClient;
using AnyCompany.Contracts;
using System.Configuration;

namespace AnyCompany
{
    internal class OrderRepository : IOrderRepository
    {
        //private static string ConnectionString = @"Data Source=(local);Database=Orders;User Id=admin;Password=password;";

        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();

        public void Save(IOrder order)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Orders VALUES (@OrderId, @Amount, @VAT)", connection);

            command.Parameters.AddWithValue("@OrderId", order.OrderId);
            command.Parameters.AddWithValue("@Amount", order.Amount);
            command.Parameters.AddWithValue("@VAT", order.VAT);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
