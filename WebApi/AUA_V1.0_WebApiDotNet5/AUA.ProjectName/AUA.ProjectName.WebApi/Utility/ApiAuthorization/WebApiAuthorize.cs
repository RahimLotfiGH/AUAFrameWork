using System;
using System.Collections.Generic;
using System.Linq;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Common.Tools.Security;
using AUA.ProjectName.InMemoryServices.Contracts;
using AUA.ProjectName.Models.GeneralModels.AccessTokenModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using static System.String;

namespace AUA.ProjectName.WebApi.Utility.ApiAuthorization
{
    public sealed class WebApiAuthorize : Attribute, IAuthorizationFilter
    {
        private readonly EUserAccess[] _userAccesses;

        public WebApiAuthorize(params EUserAccess[] userAccesses)
        {
            _userAccesses = userAccesses;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var guidAccessToken = ApplicationHelper.GetAuthorizationToken(context.HttpContext);

            if (IsNullOrWhiteSpace(guidAccessToken))
            {
                context.Result = CreateResult(EResultStatus.InvalidToken);
                return;
            }

            var jsonAccessToken = EncryptionHelper.AesDecryptString(guidAccessToken);

            if (IsNullOrEmpty(jsonAccessToken))
            {
                context.Result = CreateResult(EResultStatus.InvalidToken);
                return;
            }

            var accessTokenDataVm = jsonAccessToken.ObjectDeserialize<AccessTokenDataVm>();

            if (accessTokenDataVm is null)
            {
                context.Result = CreateResult(EResultStatus.InvalidToken);
                return;
            }

            if (!AccessTokenHelper.IsValidationExpirationDate(accessTokenDataVm.ExpirationDate))
            {
                context.Result = CreateResult(EResultStatus.AccessTokenExpired);
                return;
            }

            var service = context.HttpContext.RequestServices.GetService<IInMemoryUserAccessService>();


            var userAccessInMemoryVm = service.Get(accessTokenDataVm.UserId);

            if (userAccessInMemoryVm is null)
            {
                context.Result = CreateResult(EResultStatus.InvalidToken);
                return;
            }

            var hasAccess = HasUserAccess(userAccessInMemoryVm.UserAccessIds);

            if (!hasAccess)
                context.Result = CreateResult(EResultStatus.AccessDenied);
        }

        private static IActionResult CreateResult(EResultStatus resultStatus)
        {
            return ApplicationHelper.CreateResult(resultStatus);
        }

        private bool HasUserAccess(IEnumerable<EUserAccess> accesses)
        {
            return accesses.Any(x => _userAccesses.Any(y => y == x));
        }

    }
}
