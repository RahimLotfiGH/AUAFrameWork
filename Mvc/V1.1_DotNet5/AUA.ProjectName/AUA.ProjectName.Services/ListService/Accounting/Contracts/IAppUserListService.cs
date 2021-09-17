using System.Threading.Tasks;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.ListModes.Accounting.AppUserModels;
using AUA.ServiceInfrastructure.BaseSearchService;

namespace AUA.ProjectName.Services.ListService.Accounting.Contracts
{
    public interface IAppUserListService : IBaseListService<AppUser, AppUserListDto>
    {

        Task<ListResultVm<AppUserListDto>> ListAsync(AppUserSearchVm appUserSearchVm);

    }
}
