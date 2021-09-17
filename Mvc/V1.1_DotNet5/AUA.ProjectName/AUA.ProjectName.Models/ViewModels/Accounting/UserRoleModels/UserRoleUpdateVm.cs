using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.ViewModels.Accounting.UserRoleModels
{
    public class UserRoleUpdateVm : BaseVm
    {
        public int AppUserId { get; set; }

        public int RoleId { get; set; }

    }
}
