using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SQLServer.DBHelper
{
    public class SqlHelper
    {
        SqlConnection cnn = null;
        public SqlHelper()
        {
            cnn = new SqlConnection(@"Data Source=.\sqlexpress01;Initial Catalog=SaleMS;Integrated Security=True");
        }

        public DataTable GetDataTable(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];   
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cnn.Close();

            }
          
        }
        public DataTable GetDataTable(string sql, IDbDataParameter[] parameters)
        {
                
            SqlCommand cmd = new SqlCommand(sql);
            foreach (SqlParameter param in parameters)
            {
                cmd.Parameters.Add(param);
            }
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public void ExecuteNonQuery(string sql)
        {
            try
            {
            // Check the connection is open or not, then only open the connection
            if(cnn.State != ConnectionState.Open)
                cnn.Open();

            SqlCommand command = new SqlCommand(sql);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = cnn;
            command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
            cnn.Close();

            }
            //cnn.S
     
        }
        public void ExecuteNonQuery(string sql, IDbDataParameter[] parameters)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql);
            foreach (SqlParameter param in parameters)
            {
                cmd.Parameters.Add(param);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

    }
}
