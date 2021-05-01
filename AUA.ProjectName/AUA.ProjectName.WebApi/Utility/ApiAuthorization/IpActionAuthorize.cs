using System;
using System.Linq;
using System.Security.Authentication;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Tools.Config.JsonSetting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AUA.ProjectName.WebApi.Utility.ApiAuthorization
{
    public sealed class IpActionAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!HasAccess(context.HttpContext))
                throw new AuthenticationException(MessageConsts.InvalidUserAccess);

        }

        private static bool HasAccess(HttpContext context)
        {
            var ipAddrss = context
                              .Connection
                              .RemoteIpAddress
                              .ToString();


            return AppSetting.AuthorizedIPs
                             .Contains(ipAddrss);                          
        }

  

    }
}
