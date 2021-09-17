using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ViewModels.Accounting.UserRoleModels;
using AUA.ServiceInfrastructure.BaseServices;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Contracts
{
    public interface IUserRoleService : IGenericEntityService<UserRole, UserRoleDto>
    {
        Task InsertUserRoleInsertManyVmsAsync(IEnumerable<UserRoleInsertManyVm> userRoleVms, long userId);

        Task<IEnumerable<int>> GetUserRoleIdByUserId(long userId);

        Task BatchDeleteAsync(IEnumerable<int> userAccessIds);

        Task InsertAsync(IEnumerable<int> roleIds, long userId);
    }
}
