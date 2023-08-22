using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnyCompany.Tests
{
    public class CustomerRepositoryTests
    {
        [Fact]
        public void Load_ValidCustomerId_ReturnsCustomerWithOrders()
        {
            int customerId = 1;
            Customer customer = CustomerRepository.Load(customerId);

            Assert.NotNull(customer);
            Assert.Equal(customerId, customer.Id);
            Assert.NotEmpty(customer.Orders);
        }

        [Fact]
        public void Load_InvalidCustomerId_ReturnsNull()
        {
            int invalidCustomerId = -1;
            Customer customer = CustomerRepository.Load(invalidCustomerId);

            Assert.Null(customer);
        }
    }
}
