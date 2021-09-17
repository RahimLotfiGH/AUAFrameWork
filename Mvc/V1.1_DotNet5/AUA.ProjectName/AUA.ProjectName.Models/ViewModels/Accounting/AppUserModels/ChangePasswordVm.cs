using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.ViewModels.Accounting.AppUserModels
{
    public class ChangePasswordVm : GeneralBaseVm
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
