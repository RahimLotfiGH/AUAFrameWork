using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.ListModes.Accounting.UserRoleAccessModels
{
    public class UserRoleAccessSearchVm : BaseSearchVm
    {
        public int UserRoleId { get; set; }

        public int UserAccessId { get; set; }

        public bool IsActive { get; set; }

    }
}
