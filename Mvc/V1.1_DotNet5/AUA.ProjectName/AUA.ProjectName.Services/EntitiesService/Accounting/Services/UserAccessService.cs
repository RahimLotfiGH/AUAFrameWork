using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.Mapping.Mapping;
using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ViewModels.Accounting.UserAccessModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ServiceInfrastructure.BaseServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Services
{
    public class UserAccessService : GenericEntityService<UserAccess, UserAccessDto>, IUserAccessService
    {
        public UserAccessService(IUnitOfWork unitOfWork, IMapper mapperInstance) : base(unitOfWork, mapperInstance)
        {

        }

        public async Task<IEnumerable<UserAccessVm>> GetUserAccessVmsAsync()
        {
            return await GetAll().AsNoTracking()
                                 .ConvertTo<UserAccessVm>(MapperInstance)
                                 .ToListAsync();
        }

     
    }
}
