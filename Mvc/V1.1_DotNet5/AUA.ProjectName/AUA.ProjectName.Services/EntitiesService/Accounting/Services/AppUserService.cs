using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUA.Mapping.Mapping;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Tools.Security;
using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.DataModels.Accounting.AppUserDataModels;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.GeneralModels.AccessModels;
using AUA.ProjectName.Models.ViewModels.Accounting.AppUserModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ServiceInfrastructure.BaseServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Services
{
    public class AppUserService : GenericEntityService<AppUser, AppUserDto, long>, IAppUserService
    {
        private readonly IUserRoleService _userRoleService;

        public AppUserService(IUnitOfWork unitOfWork
                              , IMapper mapperInstance
                              , IUserRoleService userRoleService) : base(unitOfWork, mapperInstance)
        {
            _userRoleService = userRoleService;
        }

        public async Task<UserRoleAccessVm> GetUserRoleAccessVmAsync(long userId)
        {
            return await GetAll()
                          .Where(p => p.Id == userId)
                          .AsNoTracking()
                          .ConvertTo<UserRoleAccessVm>(MapperInstance)
                          .FirstOrDefaultAsync();

        }

        public async Task<AppUserRoleNamesDm> GetAppUserRoleNamesDmAsync(long userId)
        {
            return await GetAll()
                        .Where(p => p.Id == userId)
                        .AsNoTracking()
                        .ConvertTo<AppUserRoleNamesDm>(MapperInstance)
                        .FirstOrDefaultAsync();
        }

        public async Task<EResultStatus> ActiveUserAsync(long userId)
        {
            var appUser = await GetByIdAsync(userId);

            if (appUser.IsActive)
                return EResultStatus.UserIsActive;

            appUser.IsActive = true;

            await UpdateAsync(appUser);

            return EResultStatus.Success;
        }

        public async Task<EResultStatus> DeActiveUserAsync(long userId)
        {
            var appUser = await GetByIdAsync(userId);

            if (!appUser.IsActive)
                return EResultStatus.UserNotActive;

            appUser.IsActive = false;

            await UpdateAsync(appUser);

            return EResultStatus.Success;
        }

        public async Task<EResultStatus> ChangePasswordAsync(string newPassword, long userId)
        {
            var appUser = await GetByIdAsync(userId);

            if (appUser is null)
                return EResultStatus.UserNotFind;

            appUser.Password = EncryptionHelper.GetSha512Hash(newPassword);

            await UpdateAsync(appUser);

            return EResultStatus.Success;
        }

        public async Task<AppUserUpdateVm> GetAppUserUpdateVmAsync(long userId)
        {
            return await GetAll()
                        .Where(p => p.Id == userId)
                        .AsNoTracking()
                        .ConvertTo<AppUserUpdateVm>(MapperInstance)
                        .FirstOrDefaultAsync();
        }

        public async Task UpdateWithoutPasswordAsync(AppUserActionVm userActionVm)
        {
            var appUserUpdateVm = MapperInstance.Map<AppUserUpdateVm>(userActionVm.AppUserDto);

            await UpdateCustomVmAsync(appUserUpdateVm);
        }

        public async Task RemoveAndAddRoleAccess(IEnumerable<int> userAccessIds, long appUserId)
        {
            await RemoveAllRoleAccessAsync(appUserId);

            if (userAccessIds is null) return;

            await _userRoleService.InsertAsync(userAccessIds, appUserId);

        }


        public async Task RemoveAllRoleAccessAsync(long appUserId)
        {
            var userAccessIds = await _userRoleService.GetUserRoleIdByUserId(appUserId);

            await _userRoleService.BatchDeleteAsync(userAccessIds);
        }


    }
}
