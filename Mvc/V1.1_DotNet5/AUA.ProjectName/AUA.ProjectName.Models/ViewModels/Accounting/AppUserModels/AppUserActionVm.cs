using System.Collections.Generic;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ViewModels.Accounting.RoleModels;

namespace AUA.ProjectName.Models.ViewModels.Accounting.AppUserModels
{
    public class AppUserActionVm
    {
        public AppUserDto AppUserDto { get; set; }

        public IEnumerable<int> RoleIds { get; set; }

        public IEnumerable<RoleVm> RoleVms { get; set; }
    }
}
