using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ViewModels.Accounting.UserRoleAccessModels;
using AUA.ServiceInfrastructure.BaseServices;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Contracts
{
    public interface IUserRoleAccessService : IGenericEntityService<UserRoleAccess, UserRoleAccessDto>
    {
        Task<IEnumerable<UserRoleAccessDto>> GetUserAccessRoleByRoleId(int roleId);

        Task InsertVms(IEnumerable<UserRoleAccessInsertVm> userRoleAccessInsertVm, long userId);


    }
}
