using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.ManualMapping.Accounting;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ViewModels.Accounting.UserRoleModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ServiceInfrastructure.BaseServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<int>> GetUserRoleIdByUserId(long appUserId)
        {
            return await GetAll().Where(p => p.AppUserId == appUserId)
                                 .Select(p => p.Id)
                                 .ToListAsync();

        }
        public async Task BatchDeleteAsync(IEnumerable<int> userAccessIds)
        {
            foreach (var userAccessId in userAccessIds)
                await TryDeleteAsync(userAccessId);

        }

        public async Task InsertAsync(IEnumerable<int> roleIds, long userId)
        {
            foreach (var roleId in roleIds)
                await InsertAsync(new UserRole
                {
                     AppUserId= userId,
                    RoleId = roleId
                });

        }
    }
}
