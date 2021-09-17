using System.Threading.Tasks;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.ListModes.Accounting.UserRoleAccessModels;
using AUA.ServiceInfrastructure.BaseSearchService;

namespace AUA.ProjectName.Services.ListService.Accounting.Contracts
{
    public interface IUserRoleAccessListService : IBaseListService<UserRoleAccess, UserRoleAccessListDto>
    {

        Task<ListResultVm<UserRoleAccessListDto>> ListAsync(UserRoleAccessSearchVm userRoleAccessSearchVm);

    }
}
