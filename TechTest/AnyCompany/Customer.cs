using System;

namespace AnyCompany
{
    /// <summary>
    /// Represents a customer in the system.
    /// </summary>
    public class Customer
    {
        private string _country;
        private string _name;

        /// <summary>
        /// Gets or sets the country of the customer.
        /// </summary>
        public string Country
        {
            get => _country;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Country must not be null or whitespace.");
                }
                _country = value;
            }
        }

        /// <summary>
        /// Gets or sets the date of birth of the customer.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name must not be null or whitespace.");
                }
                _name = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="name">The name of the customer.</param>
        /// <param name="dateOfBirth">The date of birth of the customer.</param>
        /// <param name="country">The country of the customer.</param>
        public Customer(string name, DateTime dateOfBirth, string country)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Country = country;
        }
    }
}