using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.ViewModels.Accounting.RoleModels
{
    public class RoleVm : BaseVm, IMapFrom<Role>
    {
        public string Title { get; set; }

        public string Description { get; set; }

    }
}
