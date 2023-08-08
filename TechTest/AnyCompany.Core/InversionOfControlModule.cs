using AnyCompany.Infrastructure.Repository;
using AnyCompany.Infrastructure.Repository.Core;
using AnyCompany.Infrastructure.Repository.CustomerRepository;
using AnyCompany.Infrastructure.Repository.OrderRepository;
using AnyCompany.Service.Customer.Service;
using AnyCompany.Service.Order.Service;
using Autofac;
using System.Diagnostics.CodeAnalysis;

namespace AnyCompany.Core
{
    [ExcludeFromCodeCoverage]
    public class InversionOfControlModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Repositories
            builder.RegisterType<DapperDbContext>()
                .As<IDapperDbContext>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ConnectionDbFactory>()
                .As<IConnectionDbFactory>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CustomerDapperRepository>()
                .As<ICustomerDapperRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>()
                .InstancePerLifetimeScope();

            #endregion

            #region Services
            builder.RegisterType<CustomerService>()
                .As<ICustomerService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<OrderService>()
                .As<IOrderService>()
                .InstancePerLifetimeScope();
            #endregion
        }
    }
}
