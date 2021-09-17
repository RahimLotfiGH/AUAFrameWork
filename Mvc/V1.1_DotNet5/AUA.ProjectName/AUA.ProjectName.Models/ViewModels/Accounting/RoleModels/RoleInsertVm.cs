using System.Collections.Generic;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ViewModels.Accounting.UserAccessModels;

namespace AUA.ProjectName.Models.ViewModels.Accounting.RoleModels
{
    public class RoleActionVm 
    {
        public RoleDto RoleDto { get; set; }

        public IEnumerable<int> UserAccessIds { get; set; }

        public IEnumerable<UserAccessVm> UserAccessVms { get; set; }

       
    }
}
