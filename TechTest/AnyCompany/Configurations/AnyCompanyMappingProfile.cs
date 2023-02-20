using AnyCompany.DTOs;
using AnyCompany.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Configurations
{
    public class AnyCompanyMappingProfile : Profile
    {
        public AnyCompanyMappingProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(d => d.NumberOfOrders, opt => opt.MapFrom(s => s.Orders.Count)).ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
        }

        public static IMapper GetMapperInstance()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AnyCompanyMappingProfile>());
            return mapperConfiguration.CreateMapper();
        }
    }
}
