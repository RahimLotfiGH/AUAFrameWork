using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseDto;

namespace AUA.ProjectName.Models.EntitiesDto.Accounting
{
    public class RoleDto : BaseEntityDto, IMapFrom<Role>
    {
        public string Title { get; set; }

        public string Description { get; set; }

    }
}
