using System.Collections.Generic;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.EntitiesDto.Accounting;

namespace AUA.ProjectName.Models.ViewModels.Accounting.UserRoleModels
{
    public class UserRoleIndexVm : BaseVm<int>
    {
        public IEnumerable<UserRoleVm> UserRoleVms { get; set; }

        public AppUserDto AppUserDto { get; set; }

    }
}
