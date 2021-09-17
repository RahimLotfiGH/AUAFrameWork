using System.Threading.Tasks;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.ViewModels.Accounting.AppUserModels;

namespace AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Contracts
{
    public interface IAppUserUpdateVmValidationService
    {
        Task<ValidationResultVm> ValidationAsync(AppUserActionVm appUserVm);

    }
}
