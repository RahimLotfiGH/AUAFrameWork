using System.Threading.Tasks;
using AUA.ProjectName.Models.DataModels.General;
using AUA.ProjectName.Models.GeneralModels.AccessModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.Services.GeneralService.Login.Contracts;

namespace AUA.ProjectName.Services.GeneralService.Login.Services
{
    public class AccessTokenService : IAccessTokenService
    {
        private readonly IAppUserService _appUserService;

        public AccessTokenService(IAppUserService appUserService)
        {
            _appUserService = appUserService;

        }
        
        public async Task<UserAccessSessionVm> GetAccessTokenVmAsync(long userId)
        {
            var roleAccessVm = await GetRoleAccessVmAsync(userId);

            return new UserAccessSessionVm
            {
                UserId = userId,
                UserRoleAccess = roleAccessVm,
            };

        }

        private async Task<UserRoleAccessVm> GetRoleAccessVmAsync(long userId)
        {
            return await _appUserService
                                  .GetUserRoleAccessVmAsync(userId);
        }



    }
}
