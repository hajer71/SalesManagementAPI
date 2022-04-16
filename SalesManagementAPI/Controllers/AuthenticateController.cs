using SalesAPI.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SalesManagementAPI.Controllers
{
    public class AuthenticateController : ApiController
    {
        private readonly IUserEntity _userEntity = null;
        private readonly ITokenManager _tokenManager = null;
        public AuthenticateController(IUserEntity userEntity, ITokenManager tokenManager)
        {
            _userEntity = userEntity ?? throw new ArgumentNullException(nameof(userEntity));
            _tokenManager = tokenManager ?? throw new ArgumentNullException(nameof(tokenManager));
        }
        // GET: Authenticate
        [HttpGet]
        public async Task<HttpResponseMessage> AuthenticateUser(string userName, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Input is not valid");

                if (await _userEntity.Authenticate(userName, password))
                    return Request.CreateResponse(HttpStatusCode.OK, new { Token = await _tokenManager.GenerateToken() });

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not Found.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, ex.Message);
            }
        }
    }
}