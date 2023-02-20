using AnyCompany.Configurations;
using AnyCompany.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AnyCompany.Repositories
{
    public static class OrderRepository
    {
        public static async Task CreateAsync(Order order, AnyCompanyDbContext context)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId, AnyCompanyDbContext context)
            => await context
            .Orders
            .Where(o => o.CustomerId == customerId)
            .Include(o => o.Customer)
            .ToListAsync();
    }
}
