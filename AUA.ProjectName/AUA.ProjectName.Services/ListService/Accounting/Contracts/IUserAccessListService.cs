using System.Threading.Tasks;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.ListModes.Accounting.UserAccessModels;
using AUA.ServiceInfrastructure.BaseSearchService;

namespace AUA.ProjectName.Services.ListService.Accounting.Contracts
{
    public interface IUserAccessListService : IBaseListService<UserAccess, UserAccessListDto>
    {

        Task<ListResultVm<UserAccessListDto>> ListAsync(UserAccessSearchVm userAccessSearchVm);

    }
}
