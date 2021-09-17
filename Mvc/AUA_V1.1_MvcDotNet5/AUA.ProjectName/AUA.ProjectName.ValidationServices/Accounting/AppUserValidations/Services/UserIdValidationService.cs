using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Contracts;
using AUA.ProjectName.ValidationServices.BaseValidations;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Services
{
    public class UserIdValidationService : BaseValidationService, IUserIdValidationService
    {
        private long _userId;

        private readonly IAppUserService _appUserService;

        public UserIdValidationService(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<ValidationResultVm> ValidationAsync(long userId)
        {
            _userId = userId;

            await DoValidationAsync();

            return ValidationResultVm;
        }

        private async Task DoValidationAsync()
        {
            DefaultValidation();

            if (HasError) return;

            await ValidationUserIdAsync();
        }

        private void DefaultValidation()
        {
            if (IsEmpty(_userId))
                AddError("UserId", "UserId is empty");
        }

        private async Task ValidationUserIdAsync()
        {
            var appUser = await GetAppUserIdsAsync();

            if (appUser is null)
                AddError("Id", "user does not exist");

        }

        private async Task<long?> GetAppUserIdsAsync()
        {
            return await _appUserService
                                .GetAll()
                                .AsNoTracking()
                                .Select(p => p.Id)
                                .FirstOrDefaultAsync(p => p == _userId);

        }

    }
}
