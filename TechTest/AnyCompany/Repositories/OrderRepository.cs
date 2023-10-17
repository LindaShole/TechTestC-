using AnyCompany.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace AnyCompany.Repositories
{
    internal class OrderRepository
    {
        //private static string ConnectionString = @"Data Source=(localhost);Database=CustomersDb;User Id=admin;Password=password;";
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["CustomersConnection"].ConnectionString;

        public List<Order> GetOrdersForCustomer(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Orders WHERE CustomerId = " + customerId,
                    connection);
                var reader = command.ExecuteReader();

                List<Order> orders = new List<Order>();

                while (reader.Read())
                {
                    Order order = new Order
                    {
                        OrderId = Convert.ToInt32(reader["OrderId"].ToString()),
                        CustomerId = Convert.ToInt32(reader["CustomerId"].ToString()),
                        Amount = Convert.ToDouble(reader["Amount"].ToString()),
                        VAT = Convert.ToDouble(reader["VAT"].ToString())
                    };

                    orders.Add(order);
                }

                return orders;
            }
        }

        public void Save(Order order)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Orders VALUES (@CustomerId, @Amount, @VAT)", connection);

                command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                command.Parameters.AddWithValue("@Amount", order.Amount);
                command.Parameters.AddWithValue("@VAT", order.VAT);

                command.ExecuteNonQuery();
            }
        }
    }
}
