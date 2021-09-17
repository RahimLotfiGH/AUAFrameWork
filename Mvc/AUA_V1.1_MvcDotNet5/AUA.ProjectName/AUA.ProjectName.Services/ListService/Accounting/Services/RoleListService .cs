using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.ListModes.Accounting.RoleModels;
using AUA.ProjectName.Services.ListService.Accounting.Contracts;
using AUA.ServiceInfrastructure.BaseSearchService;
using AutoMapper;

namespace AUA.ProjectName.Services.ListService.Accounting.Services
{
    public sealed class RoleListService : BaseListService<Role, RoleListDto, RoleSearchVm>, IRoleListService
    {
        public RoleListService(IUnitOfWork unitOfWork, IMapper mapperInstance) : base(unitOfWork, mapperInstance)
        {

        }

        public async Task<ListResultVm<RoleListDto>> ListAsync(RoleSearchVm roleSearchVm)
        {
            SetSearchVm(roleSearchVm);

            ApplyTitleFilter();
            ApplyDescriptionFilter();
            ApplyIsActiveFilters();


            return await CreateListVmResultAsync();
        }

        private void ApplyTitleFilter()
        {
            if (string.IsNullOrWhiteSpace(SearchVm.Title))
                return;

            Query = Query.Where(p => p.Title.Contains(SearchVm.Title));
        }

        private void ApplyDescriptionFilter()
        {
            if (string.IsNullOrWhiteSpace(SearchVm.Description))
                return;

            Query = Query.Where(p => p.Description.Contains(SearchVm.Description));
        }

        private void ApplyIsActiveFilters()
        {
            if (!SearchVm.IsActive.HasValue)
                return;

            Query = Query.Where(p => p.IsActive == SearchVm.IsActive);

        }


    }
}
