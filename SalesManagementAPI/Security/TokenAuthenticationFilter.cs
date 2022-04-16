using SalesAPI.Domain.Abstract;
using SalesManagementAPI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SalesManagementAPI.Security
{
    public class TokenAuthenticationFilter : AuthorizationFilterAttribute
    {
        public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (actionContext.Request.Headers.Authorization == null)
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "You are Un-Authorized.");

            else
            {
                string token = actionContext.Request.Headers.Authorization.Parameter;
                var tokenManager = NinjectWebCommon._Kernal.GetService(typeof(ITokenManager)) as ITokenManager;

                if (!await tokenManager.VerifyToken(token))
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                                                                    "Token seems expired/You are not authorized");
            }
        }
    }
}