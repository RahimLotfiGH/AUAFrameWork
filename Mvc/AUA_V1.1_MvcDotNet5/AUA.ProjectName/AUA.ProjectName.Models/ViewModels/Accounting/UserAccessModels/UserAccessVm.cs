using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.ViewModels.Accounting.UserAccessModels
{
    public class UserAccessVm : BaseVm, IMapFrom<UserAccess>
    {
        public string Title { get; set; }

        public int AccessCode { get; set; }

      
    }
}
