using AnyCompany.Configurations;
using AnyCompany.DTOs;
using AnyCompany.Entities;
using AnyCompany.Interfaces;
using AnyCompany.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnyCompany.Services
{
    public class OrderService : IOrderService
    {
        protected readonly IMapper _mapper;
        protected readonly AnyCompanyDbContext _context;

        public OrderService(AnyCompanyDbContext context)
        {
            _mapper = AnyCompanyMappingProfile.GetMapperInstance();
            _context = context;
        }

        /// <summary>
        /// Retrieves all orders relating to a customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<OrderDTO>> LoadCustomerOrders(int customerId)
        {
            try
            {
                var orders = await OrderRepository.GetByCustomerIdAsync(customerId, _context);
                return _mapper.Map<IEnumerable<OrderDTO>>(orders);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Places an order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task PlaceOrder(OrderDTO order)
        {
            try
            {
                if (order.Amount <= 0)
                    throw new Exception("Amount must be greater than 0.");

                var entity = _mapper.Map<Order>(order);

                var customer = await CustomerRepository.GetAsync(order.CustomerId, _context);
                if (customer == null)
                    throw new Exception("Cutomer not found");

                entity.Customer = customer;

                entity.VAT = CalculateVAT(_mapper.Map<CustomerDTO>(customer));

                await OrderRepository.CreateAsync(entity, _context);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private double CalculateVAT(CustomerDTO customer) => customer.Country == "UK" ? 0.2d : 0;
    }
}
