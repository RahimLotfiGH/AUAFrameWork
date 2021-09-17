using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.ListModes.Accounting.UserRoleModels
{
    public class UserRoleListVm : BaseVm,IMapFrom<UserRole>
    {
        public long AppUserId { get; set; }

        public int RoleId { get; set; }

     
    }
}
