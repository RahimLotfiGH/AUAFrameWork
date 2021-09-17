using System.Collections.Generic;
using System.Linq;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ViewModels.Accounting.UserRoleAccessModels;
using AUA.ProjectName.Models.ViewModels.Accounting.UserRoleModels;

namespace AUA.ProjectName.ManualMapping.Accounting
{
    public static class UserRoleMapping
    {
        public static IEnumerable<UserRoleAccessDto> MapToUserRoleAccessDtos(
            this IEnumerable<UserRoleAccessInsertVm> userRoleAccessInsertVm, long userId)
        {
            return userRoleAccessInsertVm?.Select(item => new UserRoleAccessDto
            {
                RoleId = item.RoleId,
                CreatorUserId = userId,
                IsActive = item.IsActive,
                UserAccessId = item.UserAccessId,
            })
                .ToList();

        }


        public static IEnumerable<UserRole> MapToUserRole(this IEnumerable<UserRoleInsertManyVm> userRoleVms, long userId)
        {
            return userRoleVms?.Select(p => new UserRole
                   {
                       AppUserId = p.AppUserId,
                       CreatorUserId = userId,
                       RoleId = p.RoleId
                   });
        }

    }
}
