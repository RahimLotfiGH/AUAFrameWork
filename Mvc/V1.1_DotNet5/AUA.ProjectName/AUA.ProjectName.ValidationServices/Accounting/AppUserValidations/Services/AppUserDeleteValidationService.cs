using System.Threading.Tasks;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.DataModels.Accounting.AppUserDataModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Contracts;
using AUA.ProjectName.ValidationServices.BaseValidations;

namespace AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Services
{
    public class AppUserDeleteValidationService : BaseValidationService, IAppUserDeleteValidationService
    {
        private long _userId;
        private readonly IAppUserService _appUserService;
        private AppUserRoleNamesDm _appUserRoleNamesDm;

        public AppUserDeleteValidationService(IAppUserService appUserService)
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

            await GetAppUserRoleNamesDmAsync();

            ValidationUserId();

            if (HasError) return;

            ValidationAdminRoleName();

        }

        private void DefaultValidation()
        {
            if (IsEmpty(_userId))
                AddError("UserId", "UserId is empty");

        }

        private async Task GetAppUserRoleNamesDmAsync()
        {
            _appUserRoleNamesDm = await _appUserService
                                        .GetAppUserRoleNamesDmAsync(_userId);

        }

        private void ValidationUserId()
        {
            if (_appUserRoleNamesDm is null)
                AddError("Id", "user does not exist");
        }

        private void ValidationAdminRoleName()
        {
            if (_appUserRoleNamesDm.UserRolesNames.Contains(DbConsts.AdminRoleName))
                AddError("Id", "Can not delete the admin user");
        }

    }
}
