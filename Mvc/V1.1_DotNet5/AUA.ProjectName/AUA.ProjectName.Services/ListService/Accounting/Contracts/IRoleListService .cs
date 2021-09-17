using System.Threading.Tasks;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.ListModes.Accounting.RoleModels;
using AUA.ServiceInfrastructure.BaseSearchService;

namespace AUA.ProjectName.Services.ListService.Accounting.Contracts
{
    public interface IRoleListService : IBaseListService<Role, RoleListDto>
    {

        Task<ListResultVm<RoleListDto>> ListAsync(RoleSearchVm appUserSearchVm);

    }
}
