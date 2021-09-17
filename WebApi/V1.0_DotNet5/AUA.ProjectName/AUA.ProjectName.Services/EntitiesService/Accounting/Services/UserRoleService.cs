using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.ManualMapping.Accounting;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ViewModels.Accounting.UserRoleModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ServiceInfrastructure.BaseServices;
using AutoMapper;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Services
{
    public class UserRoleService : GenericEntityService<UserRole, UserRoleDto>, IUserRoleService
    {
        public UserRoleService(IUnitOfWork unitOfWork, IMapper mapperInstance) : base(unitOfWork, mapperInstance)
        {

        }

        public async Task InsertUserRoleInsertManyVmsAsync(IEnumerable<UserRoleInsertManyVm> userRoleVms, long userId)
        {
            var userRoles = userRoleVms.MapToUserRole(userId);


            await InsertManyAsync(userRoles);
        }


    }
}
