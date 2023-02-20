using AnyCompany.Configurations;
using AnyCompany.DTOs;
using AnyCompany.Interfaces;
using AnyCompany.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Services
{
    public class CustomerService : ICustomerService
    {
        protected readonly IMapper _mapper;
        protected readonly AnyCompanyDbContext _context;

        public CustomerService(AnyCompanyDbContext context)
        {
            _mapper = AnyCompanyMappingProfile.GetMapperInstance();
            _context = context;
        }

        /// <summary>
        /// Retrieves a single Customer entity
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CustomerDTO> LoadCustomer(int customerId)
        {
            try
            {
                var customer = await CustomerRepository.GetAsync(customerId, _context);
                return _mapper.Map<CustomerDTO>(customer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves all Customers
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<CustomerDTO>> LoadCustomers()
        {
            try
            {
                var customers = await CustomerRepository.GetAsync(_context);
                return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
