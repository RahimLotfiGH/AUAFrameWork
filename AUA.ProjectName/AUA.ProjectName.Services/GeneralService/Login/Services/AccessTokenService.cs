using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.InMemoryServices.Contracts;
using AUA.ProjectName.Models.DataModels.General;
using AUA.ProjectName.Models.GeneralModels.AccessTokenModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.Services.GeneralService.Login.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.Services.GeneralService.Login.Services
{
    public class AccessTokenService : IAccessTokenService
    {
        private readonly IAppUserService _appUserService;
        private readonly IActiveAccessTokenService _activeAccessTokenService;
        private readonly IInMemoryUserAccessService _inMemoryUserAccessService;

        public AccessTokenService(IAppUserService appUserService
                                  , IActiveAccessTokenService activeAccessTokenService
                                  , IInMemoryUserAccessService inMemoryUserAccessService)
        {
            _appUserService = appUserService;
            _activeAccessTokenService = activeAccessTokenService;
            _inMemoryUserAccessService = inMemoryUserAccessService;
        }


        public async Task<UserAccessTokenVm> GetAccessTokenVmAsync(long userId)
        {
            await DeleteAllUserTokensAsync(userId);

            var roleAccessVm = await GetRoleAccessVmAsync(userId);

            return new UserAccessTokenVm
            {
                UserId = userId,
                UserRoleAccess = roleAccessVm,
            };

        }

        private async Task DeleteAllUserTokensAsync(long userId)
        {
            await DeleteActiveAccessTokenAsync(userId);

            DeleteUserAccessInMemory(userId);

        }

        private async Task<UserRoleAccessVm> GetRoleAccessVmAsync(long userId)
        {
            return await _appUserService
                                  .GetUserRoleAccessVmAsync(userId);
        }

        public void DeleteUserAccessInMemory(long userId)
        {
            _inMemoryUserAccessService.Delete(userId);
        }

        public async Task DeleteActiveAccessTokenAsync(long userId)
        {
            var tokenIds = await _activeAccessTokenService
                                    .GetAll()
                                    .Where(p => p.UserId == userId)
                                    .ToListAsync();

            foreach (var id in tokenIds)
                await _activeAccessTokenService.DeleteAsync(id.Id);

        }

        public async Task InsertActiveAccessTokenAsync(ActiveAccessToken activeAccessToken)
        {
            await _activeAccessTokenService.InsertAsync(activeAccessToken);
        }

    }
}
