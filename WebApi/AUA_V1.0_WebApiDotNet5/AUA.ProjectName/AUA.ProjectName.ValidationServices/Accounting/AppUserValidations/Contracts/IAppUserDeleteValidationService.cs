using System.Threading.Tasks;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;

namespace AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Contracts
{
    public interface IAppUserDeleteValidationService
    {
        Task<ValidationResultVm> ValidationAsync(long userId);

    }
}
