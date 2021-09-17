using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Models.ViewModels.BaseViewModel;

namespace AUA.ProjectName.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult ErrorPage(EResultStatus resultStatus)
        {
            _logger.LogError(resultStatus.ToDescription());

            var errorPageVm = CreateErrorPageVm(resultStatus);

            return View(errorPageVm);
        }

        private static ErrorPageVm CreateErrorPageVm(EResultStatus resultStatus)
        {
            return new ErrorPageVm
            {
                Message = resultStatus.ToDescription(),
                ErrorCode = resultStatus.GetId()
            };
        }

    }
}
