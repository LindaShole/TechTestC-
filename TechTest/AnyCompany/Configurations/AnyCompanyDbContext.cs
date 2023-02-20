using AnyCompany.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Configurations
{
    public class AnyCompanyDbContext : DbContext
    {
        public AnyCompanyDbContext() : base("name=AnyCompanyContext") { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
