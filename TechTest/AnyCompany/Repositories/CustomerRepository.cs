using AnyCompany.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace AnyCompany.Repositories
{
    public static class CustomerRepository
    {
        //private static string ConnectionString = @"Data Source=(localhost);Database=CustomersDb;User Id=admin;Password=password;";
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["CustomersConnection"].ConnectionString;

        public static Customer Load(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Customers WHERE CustomerId = " + customerId,
                    connection);
                var reader = command.ExecuteReader();

                Customer customer = new Customer();

                while (reader.Read())
                {
                    customer.CustomerId = Convert.ToInt32(reader["CustomerId"].ToString());
                    customer.Name = reader["Name"].ToString();
                    customer.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                    customer.Country = reader["Country"].ToString();
                }

                return customer;
            }
        }

        public static List<Customer> LoadAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Customers", connection);
                var reader = command.ExecuteReader();

                List<Customer> customers = new List<Customer>();

                while (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        CustomerId = Convert.ToInt32(reader["CustomerId"].ToString()),
                        Name = reader["Name"].ToString(),
                        DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString()),
                        Country = reader["Country"].ToString()
                    };

                    customers.Add(customer);
                }

                return customers;
            }
        }

        public static int AddCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Customers VALUES (@Name, @DateOfBirth, @Country)", connection);

                command.Parameters.AddWithValue("@Name", customer.Name);
                command.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                command.Parameters.AddWithValue("@Country", customer.Country);

                return command.ExecuteNonQuery();
            }
        }
    }
}
