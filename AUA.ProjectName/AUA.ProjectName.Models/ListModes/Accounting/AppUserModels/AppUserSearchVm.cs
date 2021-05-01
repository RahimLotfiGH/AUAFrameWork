using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.ListModes.Accounting.AppUserModels
{
    public class AppUserSearchVm : BaseSearchVm
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public bool? IsActive { get; set; }

    }
}
