using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseDto;

namespace AUA.ProjectName.Models.EntitiesDto.Accounting
{
    public class UserRoleDto : BaseEntityDto, IMapFrom<UserRole>
    {
        public long AppUserId { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public AppUser AppUser { get; set; }

    }
}
