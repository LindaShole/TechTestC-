using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AnyCompany
{
    public static class CustomerRepository
    {
        private static string ConnectionString = @"Data Source=(local);Database=Customers;User Id=admin;Password=password;";

        public static Customer Load(int customerId)
        {
            Customer customer = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE CustomerId = @CustomerId", connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            DateTime dateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                            string country = reader["Country"].ToString();
                            customer = new Customer(name, dateOfBirth, country);
                        }
                    }
                }
            }

            if (customer != null)
            {
                customer.Orders = LoadOrdersForCustomer(customerId);
            }

            return customer;
        }

        private static List<Order> LoadOrdersForCustomer(int customerId)
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Orders WHERE CustomerId = @CustomerId", connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int orderId = Convert.ToInt32(reader["OrderId"]);
                            double amount = Convert.ToDouble(reader["Amount"]);
                            double vat = Convert.ToDouble(reader["VAT"]);
                            orders.Add(new Order { OrderId = orderId, Amount = amount, VAT = vat });
                        }
                    }
                }
            }

            return orders;
        }
    }
}
