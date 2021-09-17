using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Consts;
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
        private AppUserActionVm _appUserActionVm;
        private readonly IAppUserService _appUserService;

        public AppUserUpdateVmValidationService(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<ValidationResultVm> ValidationAsync(AppUserActionVm appUserVm)
        {
            _appUserActionVm = appUserVm;

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
            if (!IsEmpty(_appUserActionVm.AppUserDto.Phone) && _appUserActionVm.AppUserDto.Phone.Length == 10)
                _appUserActionVm.AppUserDto.Phone = "0" + _appUserActionVm.AppUserDto.Phone;
        }

        private void DefaultValidation()
        {
            if (IsEmpty(_appUserActionVm.AppUserDto.Id))
                AddError("Id", "Id is empty");

            if (IsEmpty(_appUserActionVm.AppUserDto.UserName))
                AddError("UserName", "UserName is empty");

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

        }

        private void SecurityValidation()
        {
            if (HasDangerCharacters(_appUserActionVm.AppUserDto.UserName))
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
                                .Where(p => p.Id == _appUserActionVm.AppUserDto.Id)
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
                .Where(p => p.Id != _appUserActionVm.AppUserDto.Id &&
                            p.UserName == _appUserActionVm.AppUserDto.UserName)
                .Select(p => p.Id)
                .ToListAsync();

        }

    }
}
