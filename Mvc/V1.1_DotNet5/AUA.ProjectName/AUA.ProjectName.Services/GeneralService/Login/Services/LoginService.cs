using System.Threading.Tasks;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Tools.Security;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.DataModels.LoginDataModels;
using AUA.ProjectName.Models.GeneralModels.LoginModels;
using AUA.ProjectName.Services.BaseService.Services;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.Services.GeneralService.Login.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.Services.GeneralService.Login.Services
{
    public class LoginService : BaseBusinessService, ILoginService
    {
        private readonly IAppUserService _appUserService;

        public LoginService(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<LoginDm> LoginAsync(LoginVm loginVm)
        {
            var appUser = await GetUserByUserNameAsync(loginVm.UserName);

            if (appUser is null)
                return CreateInvalidResult(EResultStatus.InValidUserNameOrPassword);

            if (!appUser.IsActive)
                return CreateInvalidResult(EResultStatus.UserNotActive);

            return IsValidatePassword(appUser.Password, loginVm.Password) ?
                   CreateSuccessResult(appUser) :
                   CreateInvalidResult(EResultStatus.InValidUserNameOrPassword);
        }

        private static LoginDm CreateSuccessResult(AppUser appUser)
        {
            return new LoginDm
            {
                ResultStatus = EResultStatus.Success,
                IsAuthenticated = true,
                UserId = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                UserName = appUser.UserName
            };
        }

        private static bool IsValidatePassword(string password, string userPassword)
        {
            return password == EncryptionHelper.GetSha512Hash(userPassword);
        }

        private async Task<AppUser> GetUserByUserNameAsync(string userName)
        {
            return await _appUserService
                             .GetAll()
                             .FirstOrDefaultAsync(p => p.UserName == userName);
        }

        private static LoginDm CreateInvalidResult(EResultStatus eResultStatus)
        {
            return new LoginDm
            {
                IsAuthenticated = false,
                ResultStatus = eResultStatus
            };
        }
    }
}
