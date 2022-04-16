using API.Common.DTO;
using SalesAPI.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SalesAPI.Domain.Entities
{
    public class UserEntity : IUserEntity
    {
        #region PRIVATE PROPERTIES
        private readonly IUserRepository _UserRepository;
        #endregion

        #region CONSTRUCTOR
        public UserEntity(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }
        #endregion

        #region METHODS
        public List<Users> getListofUsers()
        {
            try
            {
                return _UserRepository.GetUsers();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region BASIC Auth
        public bool IsAuthenticated(string userName, string password)
        {
            var listOfUsers = _UserRepository.GetUsers();
            return listOfUsers.Any(user => user.UserId.Equals(userName, StringComparison.OrdinalIgnoreCase)
                                    && user.Password == password);
        }
        #endregion 
        
        #region Token Auth
          public async Task<bool> Authenticate(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return await Task.FromResult(false);

            /* We can check the availability of the user in database here */
            var listOfUsers = _UserRepository.GetUsers();
            bool exsit = listOfUsers.Any(user => user.UserId.Equals(userName, StringComparison.OrdinalIgnoreCase)
                                    && user.Password == password);

            return await Task.FromResult(exsit);
        }

        #endregion
    
       

        #endregion





    }
}
