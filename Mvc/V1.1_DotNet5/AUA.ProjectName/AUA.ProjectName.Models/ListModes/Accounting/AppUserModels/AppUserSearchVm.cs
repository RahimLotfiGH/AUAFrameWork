using System.ComponentModel.DataAnnotations;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.Models.ListModes.Accounting.AppUserModels
{
    public class AppUserSearchVm : BaseSearchVm
    {
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "IsActive")]
        public bool? IsActive { get; set; }

    }
}
