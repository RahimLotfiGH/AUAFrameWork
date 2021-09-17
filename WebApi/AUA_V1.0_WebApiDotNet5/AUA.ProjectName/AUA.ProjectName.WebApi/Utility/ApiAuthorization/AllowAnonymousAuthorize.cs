using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AUA.ProjectName.WebApi.Utility.ApiAuthorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class AllowAnonymousAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
        }

    }
}
