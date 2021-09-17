using AUA.ProjectName.Models.GeneralModels.AccessTokenModels;

namespace AUA.ProjectName.Models.DataModels.General
{
    public class UserAccessTokenVm
    {
        public long UserId { get; set; }

        public UserRoleAccessVm UserRoleAccess { get; set; }
        
    }

}
