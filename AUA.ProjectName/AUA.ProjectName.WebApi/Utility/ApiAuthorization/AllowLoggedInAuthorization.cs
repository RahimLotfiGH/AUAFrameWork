using System;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Common.Tools.Security;
using AUA.ProjectName.Models.GeneralModels.AccessTokenModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static System.String;

namespace AUA.ProjectName.WebApi.Utility.ApiAuthorization
{

    public sealed class AllowLoggedInAuthorization : Attribute, IAuthorizationFilter
    {
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
                context.Result = CreateResult(EResultStatus.AccessTokenExpired);
        }


        private static IActionResult CreateResult(EResultStatus resultStatus)
        {
            return ApplicationHelper.CreateResult(resultStatus);
        }

        

    }


}