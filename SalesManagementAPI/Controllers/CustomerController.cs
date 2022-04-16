using API.Common.DTO;
using SalesAPI.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalesManagementAPI.Security;
using NLog;


namespace SalesManagementAPI.Controllers
{
    public class CustomerController : ApiController
    {
        #region PRIVATE PROPERTIES
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly ICustomerEntity _CustomerEntity;

        #endregion

        #region CONSTRUCTOR

        public CustomerController(ICustomerEntity CustomerEntity)
        {
            _CustomerEntity = CustomerEntity;
        }
        #endregion

        #region METHOD 

        #region GET 

        [HttpGet]      
        //[TokenAuthenticationFilter]
        [BasicAuthentication]
        public IEnumerable<Customer> GetCustomers()
        {
            try
            {
                logger.Trace("GetCustomers Action" + Environment.NewLine + DateTime.Now);
                return _CustomerEntity.GetListofCustomer();

            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
        }

        #endregion

        #region ADD 

        [HttpPost]
        public void AddCustomers(Customer customer)
        {
            try
            {
                _CustomerEntity.AddCustomer(customer) ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region GET BY ID 

        [HttpPost]
        public Customer GetCustomerById(int Id)
        {
            try
            {
                return _CustomerEntity.GetCustomerById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion
        
        #region DELETE

        [HttpPost]
        public void DeleteCustomers(int Id)
        {
            try
            {
                _CustomerEntity.DeleteCustomer(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #endregion


    }
}
