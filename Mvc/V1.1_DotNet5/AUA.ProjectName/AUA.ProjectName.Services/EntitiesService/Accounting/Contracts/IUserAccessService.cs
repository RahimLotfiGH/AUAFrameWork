using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ViewModels.Accounting.UserAccessModels;
using AUA.ServiceInfrastructure.BaseServices;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Contracts
{
    public interface IUserAccessService : IGenericEntityService<UserAccess, UserAccessDto>
    {
        Task<IEnumerable<UserAccessVm>> GetUserAccessVmsAsync();
    }
}
