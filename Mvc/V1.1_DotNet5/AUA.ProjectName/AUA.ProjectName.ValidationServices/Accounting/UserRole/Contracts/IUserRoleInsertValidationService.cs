using System.Threading.Tasks;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.ViewModels.Accounting.UserRoleModels;

namespace AUA.ProjectName.ValidationServices.Accounting.UserRole.Contracts
{
    public interface IUserRoleInsertValidationService
    {
        Task<ValidationResultVm> ValidationAsync(UserRoleInsertVm userRoleInsertDto);

    }
}
