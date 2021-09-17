using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.ViewModels.Accounting.AppUserModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Contracts;
using AUA.ProjectName.ValidationServices.BaseValidations;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Services
{
    public class AppUserUpdateVmValidationService : BaseValidationService, IAppUserUpdateVmValidationService
    {
        private AppUserUpdateVm _appUserVm;
        private readonly IAppUserService _appUserService;

        public AppUserUpdateVmValidationService(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<ValidationResultVm> ValidationAsync(AppUserUpdateVm appUserVm)
        {
            _appUserVm = appUserVm;

            await DoValidationAsync();

            return ValidationResultVm;
        }

        private async Task DoValidationAsync()
        {
            FixValues();

            DefaultValidation();

            if (HasError) return;

            ValueValidation();

            if (HasError) return;

            SecurityValidation();

            if (HasError) return;

            await ValidationUserIdAsync();

            if (HasError) return;

            await ValidationUserNameAsync();
        }


        private void FixValues()
        {
            if (!IsEmpty(_appUserVm.Phone) && _appUserVm.Phone.Length == 10)
                _appUserVm.Phone = "0" + _appUserVm.Phone;
        }

        private void DefaultValidation()
        {
            if (!Enum<EAppType>.IsExistValue(_appUserVm.AppTypeCode.GetId()))
                AddError("AppType", "Invalid AppType code");

            if (IsEmpty(_appUserVm.Id))
                AddError("Id", "Id is empty");

            if (IsEmpty(_appUserVm.UserName))
                AddError("UserName", "UserName is empty");

            if (IsEmpty(_appUserVm.FirstName))
                AddError("FirstName", "FirstName is empty");

            if (IsEmpty(_appUserVm.LastName))
                AddError("LastName", "LastName is empty");

            if (IsEmpty(_appUserVm.Email))
                AddError("Email", "Email is empty");

            if (IsEmpty(_appUserVm.Phone))
                AddError("Phone", "Phone is empty");

            if (!IsPhoneNumber(_appUserVm.Phone))
                AddError("Phone", "Phone is not valid");

        }

        private void ValueValidation()
        {
            if (_appUserVm.UserName.Length > LengthConsts.MaxStringLen50)
                AddError("UserName", "UserName length is longer than allowed");

        }

        private void SecurityValidation()
        {
            if (HasDangerCharacters(_appUserVm.UserName))
                AddError("UserName", "Username contains unauthorized characters");


        }

        private async Task ValidationUserIdAsync()
        {
            var userId = await GetAppUserIdAsync();

            if (userId is null)
                AddError("Id", "User not find");

        }

        private async Task<long?> GetAppUserIdAsync()
        {
            return await _appUserService
                                .GetAll()
                                .AsNoTracking()
                                .Where(p => p.Id == _appUserVm.Id)
                                .Select(p => p.Id)
                                .FirstOrDefaultAsync();

        }
        private async Task ValidationUserNameAsync()
        {
            var userIds = await GetUserNameAsync();

            if (userIds.Any())
                AddError("Id", "UserName is exists");

        }

        private async Task<List<long>> GetUserNameAsync()
        {
            return await _appUserService
                .GetAll()
                .AsNoTracking()
                .Where(p => p.Id != _appUserVm.Id &&
                            p.UserName == _appUserVm.UserName)
                .Select(p => p.Id)
                .ToListAsync();

        }

    }
}
