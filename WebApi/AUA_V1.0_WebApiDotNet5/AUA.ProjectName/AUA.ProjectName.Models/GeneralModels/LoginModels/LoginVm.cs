using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.GeneralModels.LoginModels
{
    public class LoginVm : GeneralBaseVm

    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string CaptchaCode { get; set; }

    }
}
