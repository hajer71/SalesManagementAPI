using API.Common.DTO;
using DataAccess.SQLServer.DBHelper;
using SalesAPI.Domain;
using SalesAPI.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SQLServer.Repository
{
    public class ProductRepository : IProductRepository
    {
        SqlHelper helper = new SqlHelper();

        #region All Product 

        public List<Product> getListofAllProduct()
        {
            DataTable dt = helper.GetDataTable("GetAllProducts");
            List<Product> AllProduct = new List<Product>();

            foreach (DataRow dr in dt.Rows)
            {
                Product PR = new Product
                {
                    ProductId = Int32.Parse(dr["ProductId"].ToString()),
                    ProductCode = dr["ProductCode"].ToString(),
                    ProductName = dr["ProductName"].ToString(),
                    Unit = dr["Unit"].ToString(),
                    Price = Int32.Parse(dr["Price"].ToString()),
                    Description = dr["Description"].ToString()
                };
                AllProduct.Add(PR);
            }
            return AllProduct;
        }

        #endregion


        #region get Product By Id  

        public Product GetProductById(int id)
        {
            IDbDataParameter[] parameters =
        {
            new SqlParameter("@ProductId", id)
        };
            DataTable dt = helper.GetDataTable("GetProductByCode", parameters);
            Product P = null;

            foreach (DataRow dr in dt.Rows)
            {
                P = new Product
                {
                    ProductId = Int32.Parse(dr["ProductId"].ToString()),
                    ProductCode = dr["ProductCode"].ToString(),
                    ProductName = dr["ProductName"].ToString(),
                    Unit = dr["Unit"].ToString(),
                    Price = Int32.Parse(dr["Price"].ToString()),
                    Description = dr["Description"].ToString()
                };
            }
            return P;
        }

        #endregion


        #region Add Product 

        public void AddProduct(Product PR)
        {
            IDbDataParameter[] parameters =
            {
            new SqlParameter("@ProductCode", PR.ProductCode),
            new SqlParameter("@ProductName", PR.ProductName),
            new SqlParameter("@Unit", PR.Unit),
            new SqlParameter("@Price", PR.Price),
            new SqlParameter("@Description", PR.Description)
            };
            helper.ExecuteNonQuery("AddNewProduct", parameters);
        }

        #endregion


        #region Edit Product 

        public void UpdateProduct(Product PR)
        {
            IDbDataParameter[] parameters =
        {
            new SqlParameter("@ProductId", PR.ProductId),
            new SqlParameter("@ProductCode", PR.ProductCode),
            new SqlParameter("@ProductName", PR.ProductName),
            new SqlParameter("@Unit", PR.Unit),
            new SqlParameter("@Price", PR.Price),
            new SqlParameter("@Description", PR.Description)
            };

            helper.ExecuteNonQuery("EditProduct", parameters);
        }
        #endregion


        #region Delete Product 

        public void DeleteProduct(int id)
        {
            IDbDataParameter[] parameters =
        {
            new SqlParameter("@ProductId", id)
        };
            helper.ExecuteNonQuery("DeleteProduct", parameters);
        }

        #endregion
    }
}
