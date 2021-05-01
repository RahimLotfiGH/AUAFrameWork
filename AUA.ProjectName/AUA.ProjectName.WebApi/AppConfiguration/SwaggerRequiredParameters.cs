using System.Collections.Generic;
using System.Linq;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.WebApi.Utility.ApiAuthorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AUA.ProjectName.WebApi.AppConfiguration
{
    public sealed class SwaggerRequiredParameters : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            if (!HaveWebApiAuthorizeFilter(context)) return;

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = AppConsts.AuthorizationAccessTokenName,
                Required = true,
                In = ParameterLocation.Header,
            });

        }

        private static bool HaveWebApiAuthorizeFilter(OperationFilterContext context)
        {
            var authorizeNames = GetApiAuthorizeNames();

            return context
                    .ApiDescription
                    .ActionDescriptor
                    .FilterDescriptors
                    .Any(item => authorizeNames.Any(p => p == item.Filter.GetType().Name));

        }

        private static IEnumerable<string> GetApiAuthorizeNames()
        {
            return new List<string>
            {
                nameof(WebApiAuthorize),
                nameof(AllowLoggedInAuthorization), 
                nameof(OnlyHasAccessTokenAuthorization),
            };
        }
    }

  
}
