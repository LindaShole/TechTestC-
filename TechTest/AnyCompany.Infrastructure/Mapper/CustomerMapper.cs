using AnyCompany.Domain.Dto;
using AnyCompany.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AnyCompany.Infrastructure.Mapper
{
    public static class CustomerMapper
    {
        //map customer list to customer dto list
        public static List<CustomerDto> MapToCustomerDtoList(this List<Customer> customers)
        {
            return customers.Select(x =>
            new CustomerDto
            {
                Country = x.Country,
                DateOfBirth = x.DateOfBirth,
                Name = x.Name,
                Orders = OrderMapper.ToDto(x.Orders)
            }).ToList();
        }
    }
}
