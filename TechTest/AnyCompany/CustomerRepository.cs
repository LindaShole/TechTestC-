using System;
using System.Data.SqlClient;

namespace AnyCompany
{
    public static class CustomerRepository
    {
        private static string ConnectionString = @"Data Source=(local);Database=Customers;User Id=admin;Password=password;";

        public static Customer Load(int customerId)
        {

            try{

                    Customer customer = new Customer();

                    using(SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        //Perform database operation
                         SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE CustomerId = " + customerId,
                        connection);

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            customer.Name = reader["Name"].ToString();
                            customer.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                            customer.Country = reader["Country"].ToString();
                        }


                    }

                    return customer;

                }
                catch (SqlException ex)
                {
                // Handle SQL exceptions
                Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    Console.WriteLine(ex.Message);
                }

                    
        }
    }
}
