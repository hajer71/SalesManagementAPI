using API.Common.DTO;
using SalesAPI.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SalesManagementAPI.Controllers
{
    public class OrderController : ApiController
    {
        #region PRIVATE PROPERTIES

        private readonly IOrderEntity _OrderEntity;
        #endregion

        #region CONSTRUCTOR

        public OrderController(IOrderEntity OrderEntity)
        {
            _OrderEntity = OrderEntity;
        }
        #endregion

        #region METHOD 

        [ActionName("GetOrders")]
        [Route("api/GetOrders")]

        public IEnumerable<Order> GetOrders()
        {
            try
            {
                return _OrderEntity.getListofAllOrders();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
