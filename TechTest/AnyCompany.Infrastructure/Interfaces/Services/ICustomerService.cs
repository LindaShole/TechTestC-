using AnyCompany.Domain.Dto;
using System.Collections.Generic;

namespace AnyCompany.Infrastructure.Interfaces.Services
{
    public interface ICustomerService
    {

        List<CustomerDto> GetAllCustomers();

        CustomerDto Load(int customerId);

        void Save(CustomerDto customer);

    }
}
