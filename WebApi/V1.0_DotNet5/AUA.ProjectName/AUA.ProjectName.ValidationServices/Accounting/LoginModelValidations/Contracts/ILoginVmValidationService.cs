using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.GeneralModels.LoginModels;

namespace AUA.ProjectName.ValidationServices.Accounting.LoginModelValidations.Contracts
{
    public interface ILoginVmValidationService
    {

        ValidationResultVm Validation(LoginVm loginVm);


    }
}
