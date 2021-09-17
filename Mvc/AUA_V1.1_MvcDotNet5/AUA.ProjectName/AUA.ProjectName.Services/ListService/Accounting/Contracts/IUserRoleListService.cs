using System.Threading.Tasks;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.ListModes.Accounting.UserRoleModels;
using AUA.ServiceInfrastructure.BaseSearchService;

namespace AUA.ProjectName.Services.ListService.Accounting.Contracts
{
    public interface IUserRoleListService : IBaseListService<UserRole, UserRoleListVm>
    {

        Task<ListResultVm<UserRoleListVm>> ListAsync(UserRoleSearchVm userRoleSearchVm);

    }
}
