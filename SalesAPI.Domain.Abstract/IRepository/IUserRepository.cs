using API.Common.DTO;
using System.Collections.Generic;

namespace SalesAPI.Domain.Abstract
{
    public interface IUserRepository
    {
        List<Users> GetUsers();
    }
}