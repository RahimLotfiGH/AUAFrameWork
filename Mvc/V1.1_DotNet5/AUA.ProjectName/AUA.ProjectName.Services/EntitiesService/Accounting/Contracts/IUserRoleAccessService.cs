using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ServiceInfrastructure.BaseServices;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Contracts
{
    public interface IUserRoleAccessService : IGenericEntityService<UserRoleAccess, UserRoleAccessDto>
    {
        Task<IEnumerable<int>> GetUserRoleAccessIdByRoleId(int roleId);

        Task BatchDeleteAsync(IEnumerable<int> userAccessIds);

        Task InsertAsync(IEnumerable<int> userAccessIds, int roleId);


    }
}
