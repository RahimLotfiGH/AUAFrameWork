using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.DataModels.Accounting.AppUserDataModels;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.GeneralModels.AccessModels;
using AUA.ProjectName.Models.ViewModels.Accounting.AppUserModels;
using AUA.ServiceInfrastructure.BaseServices;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Contracts
{
    public interface IAppUserService : IGenericEntityService<AppUser, AppUserDto, long>
    {
        Task<UserRoleAccessVm> GetUserRoleAccessVmAsync(long userId);

        Task<AppUserRoleNamesDm> GetAppUserRoleNamesDmAsync(long userId);

        Task<EResultStatus> ActiveUserAsync(long userId);

        Task<EResultStatus> DeActiveUserAsync(long userId);

        Task<EResultStatus> ChangePasswordAsync(string newPassword, long userId);

        Task<AppUserUpdateVm> GetAppUserUpdateVmAsync(long userId);

        Task UpdateWithoutPasswordAsync(AppUserActionVm userActionVm);

        Task RemoveAndAddRoleAccess(IEnumerable<int> userAccessIds, long appUserId);
    }
}
