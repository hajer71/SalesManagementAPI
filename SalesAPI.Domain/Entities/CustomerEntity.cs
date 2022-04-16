using API.Common.DTO;
using DataAccess.SQLServer.Repository;
using SalesAPI.Domain.Abstract;
using System;
using System.Collections.Generic;

namespace SalesAPI.Domain.Entities
{
    public class CustomerEntity : ICustomerEntity
    {
        #region PRIVATE PROPERTIES

        private readonly ICustomerRepository _CustomerRepository;

        #endregion

        #region CONSTRUCTOR

        public CustomerEntity(ICustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }
        #endregion

        #region METHODS

        public List<Customer> GetListofCustomer()
        {
            try
            {
                return _CustomerRepository.GetListofCustomer();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                return _CustomerRepository.GetCustomerById(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AddCustomer(Customer CR)
        {

            try
            {
                _CustomerRepository.AddCustomer(CR);
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteCustomer(int id)
        {
            try
            {
                _CustomerRepository.DeleteCustomer(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

    }
}
