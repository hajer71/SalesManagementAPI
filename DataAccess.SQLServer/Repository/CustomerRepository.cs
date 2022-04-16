using API.Common.DTO;
using DataAccess.SQLServer.DBHelper; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAPI.Domain.Abstract;

namespace DataAccess.SQLServer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        SqlHelper helper = new SqlHelper();

        #region All customer 

        public List<Customer> GetListofCustomer()
        {
            DataTable dt = helper.GetDataTable("GetAllCustomers");
            List<Customer> AllCustomer = new List<Customer>();

            foreach (DataRow dr in dt.Rows)
            {
                Customer CR = new Customer
                {
                    CustomerId = Int32.Parse(dr["CustomerId"].ToString()),
                    CustomerName = dr["CustomerName"].ToString(),
                    Address = dr["Address"].ToString(),
                    City = dr["City"].ToString()
                };
                AllCustomer.Add(CR);
            }
            return AllCustomer;
        }

        #endregion


        #region get Customer By Id  

        public Customer GetCustomerById(int id)
        {
            IDbDataParameter[] parameters =
        {
            new SqlParameter("@CustomerId", id)
        };
            DataTable dt = helper.GetDataTable("GetCustomerById", parameters);
            Customer C = null;

            foreach (DataRow dr in dt.Rows)
            {
                C = new Customer
                {
                    CustomerId = Int32.Parse(dr["CustomerId"].ToString()),
                    CustomerName = dr["CustomerName"].ToString(),
                    Address = dr["Address"].ToString(),
                    City = dr["City"].ToString(),
                };
            }
            return C;
        }

        #endregion


        #region Add customer 

        public void AddCustomer(Customer CR)
        {
            IDbDataParameter[] parameters =
            {
            new SqlParameter("@CustomerName", CR.CustomerName),
            new SqlParameter("@Address", CR.Address),
            new SqlParameter("@City", CR.City)
            };
            helper.ExecuteNonQuery("AddNewCustomer", parameters);
        }

        #endregion


        #region Delete customer 

        public void DeleteCustomer(int id)
        {
            IDbDataParameter[] parameters =
        {
            new SqlParameter("@CustomerId", id)
        };
            helper.ExecuteNonQuery("DeleteCustomer", parameters);
        }

        public List<Customer> GetListofCustomer(ICustomerRepository customer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
