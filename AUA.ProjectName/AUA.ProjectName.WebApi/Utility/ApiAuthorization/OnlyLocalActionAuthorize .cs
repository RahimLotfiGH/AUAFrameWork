using System;
using System.Net;
using System.Security.Authentication;
using AUA.ProjectName.Common.Consts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AUA.ProjectName.WebApi.Utility.ApiAuthorization
{
    public sealed class OnlyLocalActionAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!IsLocal(context.HttpContext))
                throw new AuthenticationException(MessageConsts.InvalidUserAccess);

        }

        private static bool IsLocal(HttpContext context)
        {
            return context.Connection.RemoteIpAddress.Equals(context.Connection.LocalIpAddress)

                   || IPAddress.IsLoopback(context.Connection.RemoteIpAddress)

                   || context.Request.Path.ToString().ToLower().StartsWith("https://localhost")

                   || context.Request.Path.ToString().ToLower().StartsWith("http://localhost");

        }




    }
}
