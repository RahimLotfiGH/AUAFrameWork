using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Models.DataModels.General;
using AUA.ProjectName.Models.DataModels.LoginDataModels;
using AUA.ProjectName.Models.GeneralModels.LoginModels;
using AUA.ProjectName.Services.GeneralService.Login.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.LoginModelValidations.Contracts;
using AUA.ProjectName.WebUI.Controllers;
using AUA.ProjectName.WebUI.Utility.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AUA.ProjectName.WebUI.Areas.Accounting.Controllers
{
    [Area(AreasConsts.Accounting)]
    public class AccountController : BaseController
    {
        private readonly ILoginVmValidationService _loginVmValidationService;
        private readonly ILoginService _loginService;
        private readonly IAccessTokenService _accessTokenService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILoginVmValidationService loginVmValidationService
                                 , ILoginService loginService
                                 , IAccessTokenService accessTokenService
                                 , ILogger<AccountController> logger)
        {
            _loginVmValidationService = loginVmValidationService;
            _loginService = loginService;
            _accessTokenService = accessTokenService;
            _logger = logger;
        }

        public IActionResult LoginAsync()
        {

            return View(new LoginVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginVm loginVm)
        {
            ValidationLoginVm(loginVm);

            if (HasError)
                return View(loginVm);

            var loginDm = await DoLoginAsync(loginVm);

            if (!loginDm.IsAuthenticated)
                AddError(loginDm.ResultStatus);

            Log(loginDm, loginVm.UserName);

            if (HasError)
                return View(loginVm);

            var resultVm = await CreateLoginResultVmAsync(loginDm);

            await UserLoginSuccessAsync(resultVm, loginVm.RememberMe);

            return RedirectToAction("Index", "AdminDashboard", new { area = "Dashboard" });
        }

        private void ValidationLoginVm(LoginVm loginVm)
        {
            var resultVm = _loginVmValidationService.Validation(loginVm);

            AddErrors(resultVm);
        }

        private void Log(LoginDm loginDm, string userName)
        {
            var logMessage = CreateLogMessage(loginDm.ResultStatus.ToDescription(), 
                                              loginDm.ObjectSerialize(), 
                                              userName);

            _logger.LogInformation(logMessage);
          
        }

        private async Task<LoginDm> DoLoginAsync(LoginVm loginVm)
        {
            return await _loginService.LoginAsync(loginVm);
        }


        private async Task<UserLoggedInVm> CreateLoginResultVmAsync(LoginDm loginDm)
        {
            var accessTokenVm = await GetAccessTokenVmAsync(loginDm.UserId);

            return new UserLoggedInVm
            {
                UserId = loginDm.UserId,
                UserName = loginDm.UserName,
                FirstName = loginDm.FirstName,
                LastName = loginDm.LastName,
                RoleIds = accessTokenVm.UserRoleAccess.UserRoleIds.Distinct(),
                UserAccessIds = accessTokenVm.UserRoleAccess.UserAccessIds.Distinct(),
            };
        }
        private async Task<UserAccessSessionVm> GetAccessTokenVmAsync(long userId)
        {
            return await _accessTokenService
                                  .GetAccessTokenVmAsync(userId);
        }

        private async Task UserLoginSuccessAsync(UserLoggedInVm userLoggedInVm, bool rememberMe)
        {
            await SecurityHelper
                  .UserLoginSuccessAsync(HttpContext, userLoggedInVm, rememberMe);

        }

        public async Task<IActionResult> LogoutAsync()
        {
            await SecurityHelper
                          .LogoffAsync(HttpContext);

            return RedirectToAction("Login");
        }
    }
}
