using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.ListModes.Accounting.UserRoleModels
{
    public class UserRoleSearchVm : BaseSearchVm
    {
        public int AppUserId { get; set; }

        public int RoleId { get; set; }

    }
}
