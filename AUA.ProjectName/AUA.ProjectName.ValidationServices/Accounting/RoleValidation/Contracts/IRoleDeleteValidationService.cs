using System.Threading.Tasks;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;

namespace AUA.ProjectName.ValidationServices.Accounting.RoleValidation.Contracts
{
    public interface IRoleDeleteValidationService
    {
        Task<ValidationResultVm> ValidationAsync(int roleId);

    }
}
