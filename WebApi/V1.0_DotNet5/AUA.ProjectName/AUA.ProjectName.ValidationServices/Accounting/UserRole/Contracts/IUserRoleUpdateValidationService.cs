using System.Threading.Tasks;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.EntitiesDto.Accounting;

namespace AUA.ProjectName.ValidationServices.Accounting.UserRole.Contracts
{
   public interface IUserRoleUpdateValidationService
    {
        Task<ValidationResultVm> ValidationAsync(UserRoleDto userRoleDto);

    }
}
