using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseDto;

namespace AUA.ProjectName.Models.EntitiesDto.Accounting
{
    public class UserRoleAccessDto : BaseEntityDto, IMapFrom<UserRoleAccess>
    {
        public int RoleId { get; set; }

        public int UserAccessId { get; set; }

        public virtual Role UserRole { get; set; }

        public virtual UserAccess UserAccessDto { get; set; }
    }
}
