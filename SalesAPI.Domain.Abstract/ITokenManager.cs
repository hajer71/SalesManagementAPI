using API.Common;
using System.Threading.Tasks;

namespace SalesAPI.Domain.Abstract
{
    public interface ITokenManager
    {
        Task<Token> GenerateToken();
        Task<bool> VerifyToken(string token);
    }
}