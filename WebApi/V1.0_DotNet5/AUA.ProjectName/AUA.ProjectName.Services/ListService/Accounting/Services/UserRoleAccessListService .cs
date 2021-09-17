using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.ListModes.Accounting.UserRoleAccessModels;
using AUA.ProjectName.Services.ListService.Accounting.Contracts;
using AUA.ServiceInfrastructure.BaseSearchService;
using AutoMapper;

namespace AUA.ProjectName.Services.ListService.Accounting.Services
{
    public sealed class UserRoleAccessListService : BaseListService<UserRoleAccess, UserRoleAccessListDto, UserRoleAccessSearchVm>, IUserRoleAccessListService
    {
        public UserRoleAccessListService(IUnitOfWork unitOfWork, IMapper mapperInstance) : base(unitOfWork, mapperInstance)
        {

        }

        public async Task<ListResultVm<UserRoleAccessListDto>> ListAsync(UserRoleAccessSearchVm userRoleAccessSearchVm)
        {
            SetSearchVm(userRoleAccessSearchVm);

            ApplyDefaultFilter();
         
            return await CreateListVmResultAsync();
        }

        private void ApplyDefaultFilter()
        {
            Query = Query.Where(p => p.IsActive);
        }


    }
}
