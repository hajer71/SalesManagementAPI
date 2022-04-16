using API.Common.DTO;
using System.Collections.Generic;

namespace SalesAPI.Domain.Abstract
{
    public interface IProductRepository
    {
        void AddProduct(Product PR);
        void DeleteProduct(int id);
        List<Product> getListofAllProduct();
        Product GetProductById(int id);
        void UpdateProduct(Product PR);
    }
}