using System.Threading.Tasks;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.ValidationServices.Accounting.UserRole.Contracts;
using AUA.ProjectName.ValidationServices.BaseValidations;

namespace AUA.ProjectName.ValidationServices.Accounting.UserRole.Services
{
    public class UserRoleDeleteValidationService : BaseValidationService, IUserRoleDeleteValidationService
    {
        
        public Task<ValidationResultVm> ValidationAsync(long userRoleId)
        {
            throw new System.NotImplementedException();
        }
    }
}
