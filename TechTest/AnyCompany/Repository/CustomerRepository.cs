using AnyCompany.Domain;
using System;
using System.Data.SqlClient;

namespace AnyCompany
{
    public static class CustomerRepository
    {
        private static string ConnectionString = @"Data Source=(local);Database=Customers;User Id=admin;Password=password;";
        public static Customer Load(int customerId)
        {
            Customer customer = new Customer();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE CustomerId = " + customerId, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Customer
                            {
                                Name = reader["Name"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                Country = reader["Country"].ToString()
                            };
                        }
                    }
                }
                connection.Close();
            }
            return customer;
        }
    }
}