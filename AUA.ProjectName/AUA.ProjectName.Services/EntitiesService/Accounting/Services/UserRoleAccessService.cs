using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.ManualMapping.Accounting;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ViewModels.Accounting.UserRoleAccessModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ServiceInfrastructure.BaseServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Services
{
    public class UserRoleAccessService : GenericEntityService<UserRoleAccess, UserRoleAccessDto>, IUserRoleAccessService
    {
        public UserRoleAccessService(IUnitOfWork unitOfWork, IMapper mapperInstance) : base(unitOfWork, mapperInstance)
        {

        }

        public async Task<IEnumerable<UserRoleAccessDto>> GetUserAccessRoleByRoleId(int roleId)
        {
            return await GetAllDto()
                                  .Where(x => x.RoleId == roleId)
                                  .ToListAsync();
        }


        public async Task InsertVms(IEnumerable<UserRoleAccessInsertVm> userRoleAccessInsertVm, long userId)
        {
            var userRoleAccesses = userRoleAccessInsertVm.MapToUserRoleAccessDtos(userId);

            await InsertManyAsync(userRoleAccesses);
        }

       

    }
}
