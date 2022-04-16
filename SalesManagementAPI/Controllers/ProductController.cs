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
    public class ProductController : ApiController
    {
        #region PRIVATE PROPERTIES

        private readonly IProductEntity _ProductEntity;
        #endregion

        #region CONSTRUCTOR

        public ProductController(IProductEntity ProductEntity)
        {
            _ProductEntity = ProductEntity;
        }
        #endregion

        #region METHOD 

        [ActionName("GetProducts")]
        [Route("api/GetProducts")]

        public IEnumerable<Product> GetProducts()
        {
            try
            {
                return _ProductEntity.getListofAllProduct();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}
