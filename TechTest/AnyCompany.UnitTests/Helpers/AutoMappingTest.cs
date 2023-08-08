using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.UnitTests.Helpers
{
    public class AutoMappingTest : Profile
    {
        public AutoMappingTest()
        {
            CreateMap<AnyCompany.Infrastructure.Repository.Model.Customer, AnyCompany.Service.Customer.ViewModel.CustomerView>().ReverseMap();
            CreateMap<AnyCompany.Infrastructure.Repository.Model.CustomerOrders, AnyCompany.Service.Customer.ViewModel.CustomerOrdersView>();
            CreateMap<AnyCompany.Infrastructure.Repository.Model.Order, AnyCompany.ViewModel.OrderView>().ReverseMap();
        }
    }
}
