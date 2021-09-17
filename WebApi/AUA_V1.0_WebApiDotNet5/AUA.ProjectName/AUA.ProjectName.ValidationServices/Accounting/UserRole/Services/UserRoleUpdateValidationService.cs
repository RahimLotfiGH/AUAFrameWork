using System.Threading.Tasks;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.ValidationServices.Accounting.UserRole.Contracts;
using AUA.ProjectName.ValidationServices.BaseValidations;

namespace AUA.ProjectName.ValidationServices.Accounting.UserRole.Services
{
    public class UserRoleUpdateValidationService : BaseValidationService, IUserRoleUpdateValidationService
    {

        public Task<ValidationResultVm> ValidationAsync(UserRoleDto userRoleDto)
        {
            throw new System.NotImplementedException();
        }
      

    }
}

