using System.Threading.Tasks;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.EntitiesDto.Accounting;

namespace AUA.ProjectName.ValidationServices.Accounting.UserAccessValidations.Contracts
{
    public interface IUserAccessDtoUpdateValidationService
    {
        Task<ValidationResultVm> ValidationAsync(UserAccessDto appUserVm);

    }
}
