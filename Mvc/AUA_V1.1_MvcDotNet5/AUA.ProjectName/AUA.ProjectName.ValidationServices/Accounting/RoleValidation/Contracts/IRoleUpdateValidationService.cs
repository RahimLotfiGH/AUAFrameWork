using System.Threading.Tasks;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.ViewModels.Accounting.RoleModels;

namespace AUA.ProjectName.ValidationServices.Accounting.RoleValidation.Contracts
{
    public interface IRoleUpdateValidationService
    {
        Task<ValidationResultVm> ValidationAsync(RoleActionVm roleUpdateVm);

    }
}
