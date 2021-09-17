using System.Collections.Generic;
using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseDto;
using AutoMapper;

namespace AUA.ProjectName.Models.EntitiesDto.Accounting
{
    public class RoleDto : BaseEntityDto, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IList<UserRoleAccessDto> UserRoleAccess { get; set; }

        public void ConfigureMapping(Profile configuration)
        {
            configuration.CreateMap<Role, RoleDto>()
                .ForMember(p => p.UserRoleAccess, p => p.MapFrom(q => q.UserRoleAccess));

            configuration.CreateMap<RoleDto, Role>();
        }
    }


}

