using API.Common.DTO;
using DataAccess.SQLServer.Repository;
using SalesAPI.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAPI.Domain
{
   public  class UserValidate
    {

        #region PRIVATE PROPERTIES

        private readonly IUserEntity _UserEntity;
      //  private static List<Users> allUsers;

        #endregion

        #region CONSTRUCTOR

        public UserValidate(IUserEntity UserEntity)
        {
            _UserEntity = UserEntity;
          //  allUsers = _UserEntity.getListofUsers();
        }
        #endregion

        #region METHODS
        public static bool Login(string username, string password)
        {
           UserRepository e = new UserRepository();
           var UserLists = e.GetUsers();
           return UserLists.Any(user =>
           user.UserId.Equals(username, StringComparison.OrdinalIgnoreCase)
           && user.Password == password);
        }
        #endregion

    }
}
