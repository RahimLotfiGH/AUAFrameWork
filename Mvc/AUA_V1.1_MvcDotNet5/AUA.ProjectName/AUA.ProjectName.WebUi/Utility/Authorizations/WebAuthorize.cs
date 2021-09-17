using System;
using System.Collections.Generic;
using System.Linq;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.InMemoryServices.Contracts;
using AUA.ProjectName.WebUi.Utility;
using AUA.ProjectName.WebUI.Utility.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace AUA.ProjectName.WebUI.Utility.Authorizations
{
    public sealed class WebAuthorize : Attribute, IAuthorizationFilter
    {
        private readonly EUserAccess[] _userAccesses;

        public WebAuthorize(params EUserAccess[] userAccesses)
        {
            _userAccesses = userAccesses;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!SecurityHelper.IsLoggedIn(context.HttpContext))
            {
                context.Result = CreateResult(EResultStatus.YouHaveNotLoggedIn);
                return;
            }

            var loggedInVm = SecurityHelper.GetUserLoggedInVm(context.HttpContext);

            if (loggedInVm.UserId == 0)
            {
                context.Result = CreateResult(EResultStatus.YouHaveNotLoggedIn);
                return;
            }

            var lockedUsersService = context.HttpContext.RequestServices.GetService<IInMemoryLockedUsersService>();

            if (lockedUsersService != null && lockedUsersService.IsExists(loggedInVm.UserId))
            {
                context.Result = CreateResult(EResultStatus.LockedUser);
                return;
            }

            var hasAccess = HasUserAccess(loggedInVm.UserAccessIds);

            if (!hasAccess)
                context.Result = CreateResult(EResultStatus.AccessDenied);

        }

        private bool HasUserAccess(IEnumerable<EUserAccess> accesses)
        {
            return accesses.Any(x => _userAccesses.Any(y => y == x));
        }

        private static IActionResult CreateResult(EResultStatus resultStatus)
        {
            return ApplicationHelper.CreateResult( resultStatus);
        }
    }
}
