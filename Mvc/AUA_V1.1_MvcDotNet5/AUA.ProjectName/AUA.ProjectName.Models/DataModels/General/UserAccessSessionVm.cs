using AUA.ProjectName.Models.GeneralModels.AccessModels;

namespace AUA.ProjectName.Models.DataModels.General
{
    public class UserAccessSessionVm
    {
        public long UserId { get; set; }

        public UserRoleAccessVm UserRoleAccess { get; set; }
        
    }

}
