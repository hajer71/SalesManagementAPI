using API.Common.DTO;
using DataAccess.SQLServer.DBHelper;
using SalesAPI.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SQLServer.Repository
{
    public class UserRepository : IUserRepository
    {
        SqlHelper helper = new SqlHelper();

        #region All Product 

        public List<Users> GetUsers()
        {
            DataTable dt = helper.GetDataTable("GetUsers");
            List<Users> Users = new List<Users>();

            foreach (DataRow dr in dt.Rows)
            {
                Users PR = new Users
                {
                    Id = Int32.Parse(dr["Id"].ToString()),
                    UserId = dr["UserId"].ToString(),
                    UserName = dr["UserName"].ToString(),
                    Password = dr["Password"].ToString(),
                    RoleId = Int32.Parse(dr["RoleId"].ToString())

                };
                Users.Add(PR);
            }
            return Users;


        }
        #endregion
    }

}