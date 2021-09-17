using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Tools.Security;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.ViewModels.Accounting.AppUserModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Contracts;
using AUA.ProjectName.ValidationServices.BaseValidations;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Services
{
    public class ChangePasswordValidationService : BaseValidationService, IChangePasswordValidationService
    {
        private ChangePasswordVm _changePasswordVm;
        private readonly IAppUserService _appUserService;

        public ChangePasswordValidationService(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<ValidationResultVm> ChangePasswordValidationAsync(ChangePasswordVm changePasswordVm, long userId)
        {
            _changePasswordVm = changePasswordVm;

            await DoValidationAsync(userId);

            return ValidationResultVm;
        }

        private async Task DoValidationAsync(long userId)
        {
            DefaultValidation();

            PasswordValidation();

            await OldPasswordValidationAsync(userId);
        }

        private void DefaultValidation()
        {
            if (IsEmpty(_changePasswordVm.ConfirmPassword))
                AddError("ConfirmPassword", "ConfirmPassword is empty");

            if (IsEmpty(_changePasswordVm.NewPassword))
                AddError("NewPassword", "NewPassword is empty");

            if (IsEmpty(_changePasswordVm.OldPassword))
                AddError("OldPassword", "OldPassword is empty");

        }

        private void PasswordValidation()
        {
            if (_changePasswordVm.NewPassword != _changePasswordVm.ConfirmPassword)
                AddError("ConfirmPassword", "NewPassword and ConfirmPassword are not equal ");
        }


        private async Task OldPasswordValidationAsync(long userId)
        {
            var oldPassword = await GetAppUserPasswordAsync(userId);

            if (oldPassword != EncryptionHelper.GetSha512Hash(_changePasswordVm.OldPassword))
                AddError("OldPassword", "The old password is incorrect");

        }

        private async Task<string> GetAppUserPasswordAsync(long userId)
        {
            return await _appUserService.GetAll()
                                        .Where(p => p.Id == userId)
                                        .AsNoTracking()
                                        .Select(p => p.Password)
                                        .FirstOrDefaultAsync();
        }


    }
}
