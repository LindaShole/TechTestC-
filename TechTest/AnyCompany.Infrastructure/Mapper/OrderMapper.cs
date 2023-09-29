using AnyCompany.Domain.Dto;
using AnyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Mapper
{
    public static class OrderMapper
    {

        public static List<OrderDto> ToDto(this List<Order> entity)
        {
            if (entity.Count < 1)
                return new List<OrderDto>();
            return entity.Select(x => x == null ? null :  new OrderDto
            {
                Amount = x.Amount,
                OrderId = x.OrderId,
                VAT = x.VAT
            }).ToList();
        }
    }
}
