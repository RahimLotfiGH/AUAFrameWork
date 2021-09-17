using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseDto;

namespace AUA.ProjectName.Models.EntitiesDto.Accounting
{
    public class UserAccessDto : BaseEntityDto, IMapFrom<UserAccess>
    {
        public string PageTitle { get; set; }

        public string Title { get; set; }

        public int ParentId { get; set; }

        public EUserAccess AccessCode { get; set; }

        public string Url { get; set; }

        public bool IsIndirect { get; set; }

        public string PageDescription { get; set; }

    }
}
