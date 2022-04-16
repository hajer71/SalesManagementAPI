using API.Common.DTO;
using DataAccess.SQLServer.Repository;
using SalesAPI.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAPI.Domain.Entities
{
    public class ProductEntity : IProductEntity
    {
        #region PRIVATE PROPERTIES

        private readonly IProductRepository _productRepository;

        #endregion

        #region CONSTRUCTOR

        public ProductEntity(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region METHODS
        public List<Product> getListofAllProduct()
        {
            try
            {
                return _productRepository.getListofAllProduct();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Product GetProductById(int id)
        {
            try
            {
                return _productRepository.GetProductById(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AddProduct(Product PR)
        {
            try
            {
                _productRepository.AddProduct(PR);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateProduct(Product PR)
        {
            try
            {
                _productRepository.UpdateProduct(PR);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                _productRepository.DeleteProduct(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion
    }
}
