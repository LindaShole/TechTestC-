using AnyCompany.Domain.Entities;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace AnyCompany.DataAccess.Repository
{
    public static class CustomerRepository
    {
        /// <summary>
        /// Load customer by id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static Customer Load(int customerId)
        {
            Customer customer = new Customer();
            using (var unitOfWork = new UnitOfWork.UnitOfWork())
            {
                //Use Dapper to query the database
                var query = "SELECT * FROM Customer WHERE CustomerId = @CustomerId";
                customer = unitOfWork.GetConnection().QuerySingleOrDefault<Customer>(query, new { CustomerId = customerId }, unitOfWork.GetTransaction());

            }
            return customer;
        }

        /// <summary>
        /// get all customers
        /// </summary>
        /// <returns>List of customers</returns>
        public static List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            //hold customer in a dictionary to avoid duplicates
            Dictionary<int, Customer> customerDictionary = new Dictionary<int, Customer>();
            using (var unitOfWork = new UnitOfWork.UnitOfWork())
            {
                //Use Dapper to query the database and get customers and orders
                var query = "SELECT * FROM Customer c FULL OUTER JOIN [Orders] o on c.CustomerId = o.CustomerId";
                customers = unitOfWork.GetConnection().Query<Customer, Order, Customer>(query, (customer, order) =>
                {
                    //check if customer already exists in the dictionary
                    if (!customerDictionary.TryGetValue(customer.CustomerId, out Customer customerEntry))
                    {
                        customerEntry = customer;
                        customerDictionary.Add(customerEntry.CustomerId, customerEntry);
                    }
                    //add order to the customer
                    customerEntry.Orders.Add(order);
                    return customerEntry;
                }, splitOn: "CustomerId, OrderId", transaction: unitOfWork.GetTransaction()).ToList();

            }
            return customers;
        }


        /// <summary>
        /// Save customer
        /// </summary>
        /// <param name="customer"></param>
        public static void Save(Customer customer)
        {
            using (var unitOfWork = new UnitOfWork.UnitOfWork())
            {
                //Use Dapper to query the database
                var query = "INSERT INTO Customer (Name, DateOfBirth, Country) VALUES (@Name, @DateOfBirth, @Country)";
                var output = unitOfWork.GetConnection().QueryFirstOrDefault<Customer>(query, customer,
                                       unitOfWork.GetTransaction());
                //commit the transaction
                unitOfWork.Commit();

            }
        }

    }
}
