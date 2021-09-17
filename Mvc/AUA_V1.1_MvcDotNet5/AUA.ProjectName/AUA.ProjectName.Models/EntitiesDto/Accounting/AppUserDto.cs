using System.Collections.Generic;
using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseDto;
using AutoMapper;

namespace AUA.ProjectName.Models.EntitiesDto.Accounting
{
    public sealed class AppUserDto : BaseEntityDto<long>, IHaveCustomMappings
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string FullName => $"{FirstName}  {LastName}";

        public ICollection<UserRoleDto> UserRoles { get; set; }

        public void ConfigureMapping(Profile configuration)
        {
            configuration.CreateMap<AppUser, AppUserDto>()
                .ForMember(p => p.UserRoles, p => p.MapFrom(q => q.UserRoles));

            configuration.CreateMap<AppUserDto, AppUser>();
        }
    }
}
