using AnyCompany.Base;
using AnyCompany.Base.Domain.Contract;
using AnyCompany.Base.IRepository;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace AnyCompany
{
    public static class CustomerRepository
    {
        private static string ConnectionString = ConfigurationManager.AppSettings["DBConn"].ToString();

        public static ICustomer Load(int customerId)
        {
            ICustomer customer = Factory.CreateCustomer();
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE CustomerId = " + customerId,
                    connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customer.Name = reader["Name"].ToString();
                    customer.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                    customer.Country = reader["Country"].ToString();
                }

                connection.Close();

                return customer;
            }
            catch(Exception ex)
            {
                return new Customer();
            }

        }
    }
}
