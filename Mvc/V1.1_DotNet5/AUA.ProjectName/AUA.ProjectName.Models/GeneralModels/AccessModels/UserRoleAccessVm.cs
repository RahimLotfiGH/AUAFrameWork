using System.Collections.Generic;
using System.Linq;
using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AutoMapper;

namespace AUA.ProjectName.Models.GeneralModels.AccessModels
{
    public class UserRoleAccessVm : IHaveCustomMappings
    {
        public IEnumerable<int> UserRoleIds { get; set; }

        public IEnumerable<EUserAccess> UserAccessIds => AccessIds.Distinct();

        public IEnumerable<EUserAccess> AccessIds { get; set; }

        public void ConfigureMapping(Profile configuration)
        {
            configuration.CreateMap<AppUser, UserRoleAccessVm>()
                .ForMember(p => p.UserRoleIds, p => p.MapFrom(q => q.UserRoles.Select(r => r.RoleId)))
                .ForMember(p => p.AccessIds, p => p.MapFrom(q =>
                           q.UserRoles.SelectMany(t => t.Role.UserRoleAccess.Select(m => m.UserAccess.AccessCode))));

            configuration.CreateMap<UserRoleAccessVm, AppUser>();

        }

    }
}
