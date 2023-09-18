using System;
using System.Data.SqlClient;

namespace AnyCompany
{
    internal class OrderRepository
    {
        private static string ConnectionString = @"Data Source=(local);Database=Orders;User Id=admin;Password=password;";

        public void Save(Order order)
        {

            try{
                using (SqlConnection connection = new SqlConnection(ConnectionString));
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO Orders (OrderId, Amount, VAT) VALUES (@OrderId, @Amount, @VAT)", connection);

                    command.Parameters.AddWithValue("@OrderId", order.OrderId);
                    command.Parameters.AddWithValue("@Amount", order.Amount);
                    command.Parameters.AddWithValue("@VAT", order.VAT);

                    command.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                // Handle the exception
                Console.WriteLine("An error occurred while saving the order: " + e.Message);
            }
        }

    }
}

