using AnyCompany.Base;
using AnyCompany.Base.Domain.Contract;
using AnyCompany.Base.IRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace AnyCompany
{
    internal class OrderRepository : IOrderRepository
    {
        private static string ConnectionString = ConfigurationManager.AppSettings["DBConn"].ToString();

        public void Save(IOrder order)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Orders VALUES (@OrderId, @Amount, @VAT, @CustomerId)", connection);

                command.Parameters.AddWithValue("@OrderId", order.OrderId);
                command.Parameters.AddWithValue("@Amount", order.Amount);
                command.Parameters.AddWithValue("@VAT", order.VAT);
                command.Parameters.AddWithValue("@CustomerId", order.CustomerId);

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch(Exception ex)
            {
                //Log Exception
            }
        }
    }
}
