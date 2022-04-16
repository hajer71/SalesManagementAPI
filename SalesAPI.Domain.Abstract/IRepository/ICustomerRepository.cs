using API.Common.DTO;
using System.Collections.Generic;

namespace SalesAPI.Domain.Abstract
{
    public interface ICustomerRepository
    {     
       void AddCustomer(Customer CR);
        void DeleteCustomer(int id);
        Customer GetCustomerById(int id);
        List<Customer> GetListofCustomer();
        List<Customer> GetListofCustomer(ICustomerRepository customer);
    }
}