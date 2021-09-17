using System.Collections.Generic;
using System.Linq;
using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AutoMapper;

namespace AUA.ProjectName.Models.DataModels.Accounting.AppUserDataModels
{

    public class AppUserRoleNamesDm : IHaveCustomMappings
    {
        public long Id { get; set; }

        public ICollection<string> UserRolesNames { get; set; }


        public void ConfigureMapping(Profile configuration)
        {
            configuration.CreateMap<AppUser, AppUserRoleNamesDm>()
                         .ForMember(p => p.UserRolesNames, p => p.MapFrom(q => 
                                    q.UserRoles.Select(userRole => userRole.Role.Title)));

        }

    }
}
