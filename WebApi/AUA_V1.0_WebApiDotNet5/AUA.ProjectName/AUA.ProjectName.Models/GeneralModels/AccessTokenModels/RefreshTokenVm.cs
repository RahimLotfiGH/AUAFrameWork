using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.GeneralModels.AccessTokenModels
{
    public class RefreshTokenVm: GeneralBaseVm
    {

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

    }
}
