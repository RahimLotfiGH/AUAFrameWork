using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ServiceInfrastructure.BaseServices;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.Mapping.Mapping;
using AUA.ProjectName.Models.ViewModels.Accounting.RoleModels;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Services
{
    public class RoleService : GenericEntityService<Role, RoleDto>, IRoleService
    {
        private readonly IUserRoleAccessService _userRoleAccessService;

        public RoleService(IUnitOfWork unitOfWork
                          , IMapper mapperInstance
                          , IUserRoleAccessService userRoleAccessService) : base(unitOfWork, mapperInstance)
        {
            _userRoleAccessService = userRoleAccessService;
        }


        public async Task RemoveAndAddRoleAccess(IEnumerable<int> userAccessIds, int roleId)
        {
            await RemoveAllRoleAccessAsync(roleId);

            if (userAccessIds is null) return;

            await _userRoleAccessService.InsertAsync(userAccessIds, roleId);

        }

        public async Task RemoveAllRoleAccessAsync(int roleId)
        {
            var userAccessIds = await _userRoleAccessService.GetUserRoleAccessIdByRoleId(roleId);

            await _userRoleAccessService.BatchDeleteAsync(userAccessIds);
        }

        public async Task<IEnumerable<RoleVm>> GetRoleVmsAsync()
        {
            return await GetAll().AsNoTracking()
                                 .ConvertTo<RoleVm>(MapperInstance)
                                 .ToListAsync();
        }
    }
}
