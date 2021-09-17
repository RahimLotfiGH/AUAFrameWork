using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.ListModes.Accounting.UserRoleAccessModels
{
    public class UserRoleAccessListDto : BaseSearchVm, IMapFrom<UserRoleAccess>
    {
        public int UserRoleId { get; set; }

        public int UserAccessId { get; set; }

        public bool IsActive { get; set; }

    }
}
