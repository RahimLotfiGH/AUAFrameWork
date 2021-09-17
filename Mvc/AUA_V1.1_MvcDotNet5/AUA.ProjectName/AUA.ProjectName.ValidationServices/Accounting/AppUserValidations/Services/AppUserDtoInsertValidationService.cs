using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Tools.Security;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ViewModels.Accounting.AppUserModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Contracts;
using AUA.ProjectName.ValidationServices.BaseValidations;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Services
{
    public class AppUserDtoInsertValidationService : BaseValidationService, IAppUserDtoInsertValidationService
    {
        private AppUserActionVm _appUserActionVm;
        private readonly IAppUserService _appUserService;


        public AppUserDtoInsertValidationService(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<ValidationResultVm> ValidationAsync(AppUserActionVm appUserInsertVm)
        {
            _appUserActionVm = appUserInsertVm;

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

            SetUserRole();
        }

        private void FixValues()
        {

            if (_appUserActionVm.AppUserDto.Phone != null && _appUserActionVm.AppUserDto.Phone.Length == 10)
                _appUserActionVm.AppUserDto.Phone = "0" + _appUserActionVm.AppUserDto.Phone;

        }

        private void DefaultValidation()
        {

            if (IsEmpty(_appUserActionVm.AppUserDto.UserName))
                AddError("UserName", "UserName is empty");

            if (IsEmpty(_appUserActionVm.AppUserDto.Password))
                AddError("Password", "Password is empty");

            if (IsEmpty(_appUserActionVm.AppUserDto.FirstName))
                AddError("FirstName", "FirstName is empty");

            if (IsEmpty(_appUserActionVm.AppUserDto.LastName))
                AddError("LastName", "LastName is empty");

            if (IsEmpty(_appUserActionVm.AppUserDto.Email))
                AddError("Email", "Email is empty");

            if (IsEmpty(_appUserActionVm.AppUserDto.Phone))
                AddError("Phone", "Phone is empty");

            if (!IsPhoneNumber(_appUserActionVm.AppUserDto.Phone))
                AddError("Phone", "Phone is not valid");

        }

        private void ValueValidation()
        {

            if (_appUserActionVm.AppUserDto.UserName.Length > LengthConsts.MaxStringLen50)
                AddError("UserName", "UserName length is longer than allowed");

            if (_appUserActionVm.AppUserDto.Password.Length > LengthConsts.MaxStringLen50)
                AddError("Password", "Password length is longer than allowed");

        }

        private void SecurityValidation()
        {
            if (HasDangerCharacters(_appUserActionVm.AppUserDto.UserName))
                AddError("UserName", "Username contains unauthorized characters");


            if (HasDangerCharacters(_appUserActionVm.AppUserDto.Password))
                AddError("Password", "Password contains unauthorized characters ");

        }

        private void SetHashPasswordValue()
        {
            if (string.IsNullOrWhiteSpace(_appUserActionVm.AppUserDto.Password))
                return;

            _appUserActionVm.AppUserDto.Password = EncryptionHelper.GetSha512Hash(_appUserActionVm.AppUserDto.Password);
        }

        private async Task ValidationUserNameAsync()
        {
            var isExistUserNames = await IsExistUserNamesAsync();

            if (isExistUserNames)
                AddError("UserName", "Username is a duplicate");

        }

        private async Task<bool> IsExistUserNamesAsync()
        {
            return await _appUserService.GetAll()
                                        .AsNoTracking()
                                        .AnyAsync(p => p.UserName == _appUserActionVm.AppUserDto.UserName);

        }

        private void SetUserRole()
        {
            if (_appUserActionVm.RoleIds is null) return;
            
            _appUserActionVm.AppUserDto.UserRoles = new List<UserRoleDto>();

            foreach (var roleId in _appUserActionVm.RoleIds)
                AddRole(roleId);
        }

        private void AddRole(int roleId)
        {
            _appUserActionVm.AppUserDto
                            .UserRoles
                            .Add(new UserRoleDto { RoleId = roleId });
        }
    }
}
