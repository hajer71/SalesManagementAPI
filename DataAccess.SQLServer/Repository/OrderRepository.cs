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
    public class OrderRepository : IOrderRepository
    {
        SqlHelper helper = new SqlHelper();

        #region All Orders 

        public List<Order> getListofAllOrders()
        {
            DataTable dt = helper.GetDataTable("GetAllOrders");
            List<Order> AllOrders = new List<Order>();

            foreach (DataRow dr in dt.Rows)
            {
                Order OR = new Order
                {
                    OrderId = Int32.Parse(dr["OrderId"].ToString()),
                    CustomerId = Int32.Parse(dr["CustomerId"].ToString()),
                    TotalQuantity = Int32.Parse(dr["TotalQuantity"].ToString()),
                    TotalAmount = Int32.Parse(dr["TotalAmount"].ToString())
                };
                AllOrders.Add(OR);
            }
            return AllOrders;
        }

        #endregion


        #region get Order By Id  

        public Order GetOrderById2(int id)
        {
            IDbDataParameter[] parameters =
        {
            new SqlParameter("@OrderId", id)
        };
            DataTable dt = helper.GetDataTable("GetOrderById2", parameters);
            Order O = null;

            foreach (DataRow dr in dt.Rows)
            {
                O = new Order
                {
                    OrderId = Int32.Parse(dr["OrderId"].ToString()),
                    OrderDate = dr["OrderDate"].ToString(),
                    CustomerId = Int32.Parse(dr["CustomerId"].ToString()),
                    TotalQuantity = Int32.Parse(dr["TotalQuantity"].ToString()),
                    TotalAmount = Int32.Parse(dr["TotalAmount"].ToString())
                };
            }
            return O;
        }

        #endregion


        #region Add Order 

        public void AddOrder(Order OR)
        {
            IDbDataParameter[] parameters =
            {
            new SqlParameter("@OrderDate", OR.OrderDate),
            new SqlParameter("@CustomerId", OR.CustomerId),
            new SqlParameter("@TotalQuantity", OR.TotalQuantity),
            new SqlParameter("@TotalAmount", OR.TotalAmount)
            };
            helper.ExecuteNonQuery("AddNewOrder", parameters);
        }

        #endregion


        #region Edit Order  

        public void UpdateOrder(Order OR)
        {
            IDbDataParameter[] parameters =
        {
            new SqlParameter("@OrderId", OR.OrderId),
            new SqlParameter("@OrderDate", OR.OrderDate),
            new SqlParameter("@CustomerId", OR.CustomerId),
            new SqlParameter("@TotalQuantity", OR.TotalQuantity),
            new SqlParameter("@TotalAmount", OR.TotalAmount)
            };

            helper.ExecuteNonQuery("EditOrder", parameters);
        }
        #endregion


        #region Delete Order 

        public void DeleteOrder(int id)
        {
            IDbDataParameter[] parameters =
        {
            new SqlParameter("@OrderId", id)
        };
            helper.ExecuteNonQuery("DeleteOrder", parameters);
        }

        #endregion
    }
}
