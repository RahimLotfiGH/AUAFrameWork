using System;
using System.Collections.Generic;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.GeneralModels.LoginModels
{
    public class UserLoggedInVm : BaseViewModel
    {
        public long UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<int> RoleIds { get; set; }

        public IEnumerable<EUserAccess> UserAccessIds { get; set; }

        public string RefreshToken { get; set; }

        public DateTime ExpiresIn { get; set; }

        public string AccessToken { get; set; }

    }
}
