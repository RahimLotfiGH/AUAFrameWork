using System;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.GeneralModels.AccessTokenModels
{
    public class RefreshTokenResultVm: BaseViewModel
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime ExpiresIn { get; set; }

    }
}
