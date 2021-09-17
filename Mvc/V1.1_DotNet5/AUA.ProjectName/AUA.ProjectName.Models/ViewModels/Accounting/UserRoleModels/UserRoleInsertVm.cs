using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.ViewModels.Accounting.UserRoleModels
{
    public class UserRoleInsertVm : BaseVm, IMapFrom<UserRole>
    {
        public int AppUserId { get; set; }

        public int RoleId { get; set; }

    }
}
