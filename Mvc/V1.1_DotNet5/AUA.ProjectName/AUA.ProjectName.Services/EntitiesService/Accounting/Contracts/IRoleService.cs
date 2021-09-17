using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ServiceInfrastructure.BaseServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.ProjectName.Models.ViewModels.Accounting.RoleModels;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Contracts
{
    public interface IRoleService : IGenericEntityService<Role, RoleDto>
    {
        Task RemoveAndAddRoleAccess(IEnumerable<int> newUserAccessIds, int roleId);

        Task RemoveAllRoleAccessAsync(int roleId);

        Task<IEnumerable<RoleVm>> GetRoleVmsAsync();
    }
}
