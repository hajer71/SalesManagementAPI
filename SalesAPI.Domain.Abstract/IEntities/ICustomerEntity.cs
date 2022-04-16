using API.Common.DTO;
using System.Collections.Generic;

namespace SalesAPI.Domain.Abstract
{
    public interface ICustomerEntity
    {
        void AddCustomer(Customer CR);
        void DeleteCustomer(int id);
        Customer GetCustomerById(int id);
        List<Customer> GetListofCustomer();
    }
}