using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.ListModes.Accounting.UserRoleModels;
using AUA.ProjectName.Services.ListService.Accounting.Contracts;
using AUA.ServiceInfrastructure.BaseSearchService;
using AutoMapper;

namespace AUA.ProjectName.Services.ListService.Accounting.Services
{
    public sealed class UserRoleListService : BaseListService<UserRole, UserRoleListVm, UserRoleSearchVm>, IUserRoleListService
    {
        public UserRoleListService(IUnitOfWork unitOfWork, IMapper mapperInstance) : base(unitOfWork, mapperInstance)
        {

        }

        public async Task<ListResultVm<UserRoleListVm>> ListAsync(UserRoleSearchVm userRoleSearchVm)
        {
            SetSearchVm(userRoleSearchVm);


            ApplyDefaultFilter();
            ApplyAppUserIdFilter();
            ApplyRoleIdFilter();

            return await CreateListVmResultAsync();
        }

        private void ApplyDefaultFilter()
        {
            //Query = Query.Where(p => p.IsActive);
        }

        private void ApplyAppUserIdFilter()
        {
            if (SearchVm.AppUserId == 0)
                return;

            Query = Query.Where(p => p.AppUserId == SearchVm.AppUserId);
        }

        private void ApplyRoleIdFilter()
        {
            if (SearchVm.RoleId == 0)
                return;

            Query = Query.Where(p => p.RoleId == SearchVm.RoleId);
        }

    }
}
