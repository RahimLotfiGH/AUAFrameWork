using System;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.WebUI.Controllers;
using AUA.ProjectName.WebUI.Utility.Authorizations;
using Microsoft.AspNetCore.Mvc;

namespace AUA.ProjectName.WebUI.Areas.Dashboard.Controllers
{

    [Area(AreasConsts.Dashboard)]
    [WebAuthorize(EUserAccess.Dashboard)]
    public class AdminDashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
