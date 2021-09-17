using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AUA.ProjectName.WebUi.Utility
{
    public static class ApplicationHelper
    {
        public static IActionResult CreateResult(EResultStatus resultStatus)
        {
            return new RedirectResult(AppConsts.ShowErrorPageStatusUrl + resultStatus);
        }
    }
}
