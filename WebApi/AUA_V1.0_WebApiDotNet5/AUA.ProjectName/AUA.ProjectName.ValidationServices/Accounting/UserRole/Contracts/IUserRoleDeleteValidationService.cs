using System.Threading.Tasks;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;

namespace AUA.ProjectName.ValidationServices.Accounting.UserRole.Contracts
{
    public interface IUserRoleDeleteValidationService
    {
        Task<ValidationResultVm> ValidationAsync(long userRoleId);

    }
}
