using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.EntitiesDto.Accounting;

namespace AUA.ProjectName.Models.ViewModels.Accounting.AppUserModels
{
    public class AppUserUpdateVm : GeneralVm<long>, IMapFrom<AppUserDto>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

    }
}
