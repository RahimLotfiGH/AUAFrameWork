using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Common.Tools.Security;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.ViewModels.Accounting.AppUserModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Contracts;
using AUA.ProjectName.ValidationServices.BaseValidations;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Services
{
    public class AppUserInsertVmValidationService : BaseValidationService, IAppUserInsertVmValidationService
    {
        private AppUserInsertVm _appUserVm;
        private readonly IAppUserService _appUserService;


        public AppUserInsertVmValidationService(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<ValidationResultVm> ValidationAsync(AppUserInsertVm appUserVm)
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

            await ValidationUserNameAsync();

            if (HasError) return;

            SetHashPasswordValue();
        }

        private void FixValues()
        {

            if (_appUserVm.Phone != null && _appUserVm.Phone.Length == 10)
                _appUserVm.Phone = "0" + _appUserVm.Phone;

        }

        private void DefaultValidation()
        {
            if (!Enum<EAppType>.IsExistValue(_appUserVm.AppTypeCode.GetId()))
                AddError("AppType", "Invalid AppType code");

            if (IsEmpty(_appUserVm.UserName))
                AddError("UserName", "UserName is empty");

            if (IsEmpty(_appUserVm.Password))
                AddError("Password", "Password is empty");

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

            if (_appUserVm.Password.Length > LengthConsts.MaxStringLen50)
                AddError("Password", "Password length is longer than allowed");

        }

        private void SecurityValidation()
        {
            if (HasDangerCharacters(_appUserVm.UserName))
                AddError("UserName", "Username contains unauthorized characters");


            if (HasDangerCharacters(_appUserVm.Password))
                AddError("Password", "Password contains unauthorized characters ");

        }

        private void SetHashPasswordValue()
        {
            if (string.IsNullOrWhiteSpace(_appUserVm.Password))
                return;

            _appUserVm.Password = EncryptionHelper.GetSha512Hash(_appUserVm.Password);
        }

        private async Task ValidationUserNameAsync()
        {
            var userNames = await GetAppUserNamesAsync();

            if (userNames.Any())
                AddError("UserName", "Username is a duplicate");

        }

        private async Task<List<string>> GetAppUserNamesAsync()
        {
            return await _appUserService
                            .GetAll()
                            .AsNoTracking()
                            .Where(p => p.UserName == _appUserVm.UserName)
                            .Select(p => p.UserName)
                            .ToListAsync();
        }
    }
}
