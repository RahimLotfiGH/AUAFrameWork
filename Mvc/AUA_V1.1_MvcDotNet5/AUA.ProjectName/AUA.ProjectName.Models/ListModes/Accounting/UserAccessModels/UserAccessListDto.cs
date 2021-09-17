using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting;

namespace AUA.ProjectName.Models.ListModes.Accounting.UserAccessModels
{
    public class UserAccessListDto : IMapFrom<UserAccess>
    {
        public string Title { get; set; }

        public int AccessCode { get; set; }

        public string Url { get; set; }

        public string PageDescription { get; set; }

        public bool IsIndirect { get; set; }

        public int? ParentId { get; set; }
    }
}
