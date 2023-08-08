using AnyCompany.Infrastructure.Repository.Model;
using AnyCompany.Service.Customer.ViewModel;
using AnyCompany.ViewModel;
using AutoMapper;

namespace AnyCompany.Core
{
    public class AutoMapping : Profile
    {
        public AutoMapping() { 
            
            CreateMap<CustomerOrders, CustomerOrdersView>();
            CreateMap<Order,OrderView>().ReverseMap();
            CreateMap<Customer,CustomerView>().ReverseMap();
        }
    }
}
