using API.Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesAPI.Domain.Abstract
{
    public interface IUserEntity
    {
        List<Users> getListofUsers();
        bool IsAuthenticated(string userName, string password);
        Task<bool> Authenticate(string userName, string password);

    }
}