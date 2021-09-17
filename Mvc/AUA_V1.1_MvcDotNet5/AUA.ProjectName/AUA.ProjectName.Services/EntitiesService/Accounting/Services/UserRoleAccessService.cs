using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
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

        public async Task<IEnumerable<int>> GetUserRoleAccessIdByRoleId(int roleId)
        {
            return await GetAll()
                        .Where(p => p.RoleId == roleId)
                        .Select(p => p.Id)
                        .ToListAsync();

        }

        public async Task BatchDeleteAsync(IEnumerable<int> userAccessIds)
        {
            foreach (var userAccessId in userAccessIds)
                await TryDeleteAsync(userAccessId);

        }

        public async Task InsertAsync(IEnumerable<int> userAccessIds, int roleId)
        {
            foreach (var userAccessId in userAccessIds)
                await InsertAsync(new UserRoleAccess
                {
                    RoleId = roleId,
                    UserAccessId = userAccessId
                });

        }

    }
}
