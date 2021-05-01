using System.Linq;
using System.Threading.Tasks;
using AUA.Mapping.Mapping;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Tools.Security;
using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.DataModels.Accounting.AppUserDataModels;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.GeneralModels.AccessTokenModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ServiceInfrastructure.BaseServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Services
{
    public class AppUserService : GenericEntityService<AppUser, AppUserDto, long>, IAppUserService
    {
        public AppUserService(IUnitOfWork unitOfWork, IMapper mapperInstance) : base(unitOfWork, mapperInstance)
        {

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


    }
}
