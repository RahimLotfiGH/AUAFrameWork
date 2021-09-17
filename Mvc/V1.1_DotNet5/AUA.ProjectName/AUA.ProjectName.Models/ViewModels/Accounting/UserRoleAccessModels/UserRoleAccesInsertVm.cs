using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.ViewModels.Accounting.UserRoleAccessModels
{
    public class UserRoleAccessInsertVm : BaseVm, IMapFrom<UserRoleAccess>
    {
        public int RoleId { get; set; }

        public int UserAccessId { get; set; }

    }
}
