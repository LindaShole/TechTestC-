using AnyCompany.Configurations;
using AnyCompany.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AnyCompany.Repositories
{
    public static class CustomerRepository
    {
        public static async Task<Customer> GetAsync(int customerId, AnyCompanyDbContext context)
            => await context
            .Customers
            .Include(c => c.Orders)
            .FirstOrDefaultAsync(a => a.CustomerId == customerId);

        public static async Task<IEnumerable<Customer>> GetAsync(AnyCompanyDbContext context)
            => await context
            .Customers
            .OrderBy(a => a.CustomerId)
            .ToListAsync();
    }
}
