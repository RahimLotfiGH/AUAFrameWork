using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Tools.Config.JsonSetting;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ListModes.Accounting.AppUserModels;
using AUA.ProjectName.Models.ViewModels.Accounting.AppUserModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.Services.ListService.Accounting.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Contracts;
using AUA.ProjectName.WebApi.Controllers;
using AUA.ProjectName.WebApi.Utility.ApiAuthorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.WebApi.Areas.Accounting.Controllers
{

    [WebApiAuthorize(EUserAccess.AppUser)]
    public class AppUserController : BaseApiController
    {
        private readonly IAppUserService _appUserService;
        private readonly IAppUserInsertVmValidationService _appUserInsertVmValidationService;
        private readonly IAppUserUpdateVmValidationService _appUserUpdateVmValidationService;
        private readonly IAppUserDeleteValidationService _appUserDeleteValidationService;
        private readonly IChangePasswordValidationService _appUserChangePasswordValidationService;
        private readonly IUserIdValidationService _userIdValidationService;
        private readonly IAppUserListService _appUserListService;

        public AppUserController(IAppUserService appUserService
                                 , IAppUserInsertVmValidationService appUserVmValidationService
                                 , IAppUserUpdateVmValidationService appUserUpdateVmValidationService
                                 , IAppUserDeleteValidationService appUserDeleteValidationService
                                 , IChangePasswordValidationService appUserChangePasswordValidationService
                                 , IUserIdValidationService userIdValidationService
                                 , IAppUserListService appUserListService)
        {
            _appUserService = appUserService;
            _appUserInsertVmValidationService = appUserVmValidationService;
            _appUserUpdateVmValidationService = appUserUpdateVmValidationService;
            _appUserDeleteValidationService = appUserDeleteValidationService;
            _appUserChangePasswordValidationService = appUserChangePasswordValidationService;
            _userIdValidationService = userIdValidationService;
            _appUserListService = appUserListService;
        }

        [HttpPost]
        public async Task<ResultModel<ListResultVm<AppUserListDto>>> ListAsync(AppUserSearchVm appUserSearchVm)
        {
            ValidationSearchVm(appUserSearchVm);

            if (HasError)
                return CreateInvalidResult<ListResultVm<AppUserListDto>>();

            var result = await _appUserListService
                                        .ListAsync(appUserSearchVm);

            return CreateSuccessResult(result);
        }

        [HttpGet]
        public async Task<ResultModel<List<AppUserDto>>> ListAsync()
        {
            var result = await _appUserService.GetAllDto()
                                              .AsNoTracking()
                                              .ToListAsync();

            return CreateSuccessResult(result);
        }

        [HttpPost]
        public async Task<ResultModel<long>> InsertAsync(AppUserInsertVm appUserVm)
        {
            await ValidationInsertVm(appUserVm);

            if (HasError)
                return CreateInvalidResult<long>();

            appUserVm.CreatorUserId = UserId;

            var id = await _appUserService.InsertCustomVmAsync(appUserVm);

            return id == 0 ?
                   CreateInvalidResult<long>(EResultStatus.ErrorOperations) :
                   CreateSuccessResult(id);
        }

        private async Task ValidationInsertVm(AppUserInsertVm appUserVm)
        {
            ValidationResultVm = await _appUserInsertVmValidationService
                                                      .ValidationAsync(appUserVm);
        }

        [HttpPost]
        public async Task<ResultModel<bool>> UpdateAsync(AppUserUpdateVm appUserVm)
        {
            await ValidationUpdateVmAsync(appUserVm);

            if (HasError)
                return CreateInvalidResult<bool>();

            var result = await _appUserService.UpdateCustomVmAsync(appUserVm);

            return result ?
                   CreateSuccessResult(true) :
                   CreateInvalidResult<bool>();
        }

        private async Task ValidationUpdateVmAsync(AppUserUpdateVm userUpdateVm)
        {
            ValidationResultVm = await _appUserUpdateVmValidationService
                                                      .ValidationAsync(userUpdateVm);
        }

        [HttpPost]
        public async Task<ResultModel<EResultStatus>> ChangePasswordAsync(ChangePasswordVm appUserChangePasswordVm)
        {
            await ValidationChangePasswordAsync(appUserChangePasswordVm);

            if (HasError)
                return CreateInvalidResult<EResultStatus>();

            var result = await _appUserService
                                      .ChangePasswordAsync(appUserChangePasswordVm.NewPassword, UserId);

            return CreateResult(result);

        }

        private async Task ValidationChangePasswordAsync(ChangePasswordVm appUserChangePasswordVm)
        {
            ValidationResultVm = await _appUserChangePasswordValidationService
                                                    .ChangePasswordValidationAsync(appUserChangePasswordVm, UserId);
        }

        [HttpDelete]
        public async Task<ResultModel<bool>> DeleteAsync(long userId)
        {
            await ValidateDeleteUserIdAsync(userId);

            if (HasError)
                return CreateInvalidResult<bool>();

            var isDeleted = await _appUserService.TryDeleteAsync(userId);

            return isDeleted ?
                   CreateSuccessResult(true) :
                   CreateInvalidResult<bool>(EResultStatus.ErrorOperations);
        }

        private async Task ValidateDeleteUserIdAsync(long userId)
        {
            ValidationResultVm = await _appUserDeleteValidationService
                                                    .ValidationAsync(userId);
        }

        [HttpPost]
        public async Task<ResultModel<EResultStatus>> ActiveUserAsync(long userId)
        {
            await UserIdValidationAsync(userId);

            if (HasError)
                return CreateInvalidResult<EResultStatus>();

            var result = await _appUserService.ActiveUserAsync(userId);

            return CreateResult(result);
        }

        private async Task UserIdValidationAsync(long userId)
        {
            ValidationResultVm = await _userIdValidationService
                                               .ValidationAsync(userId);
        }

        [HttpPost]
        public async Task<ResultModel<EResultStatus>> DeActiveUserAsync(long userId)
        {
            await UserIdValidationAsync(userId);

            if (HasError)
                return CreateInvalidResult<EResultStatus>();

            var result = await _appUserService.DeActiveUserAsync(userId);

            return CreateResult(result);
        }

        [HttpGet]
        [WebApiAuthorize(EUserAccess.ResetPassword)]
        public async Task<ResultModel<EResultStatus>> ResetPasswordAsync(long userId)
        {
            var result = await _appUserService
                                .ChangePasswordAsync(AppSetting.DefaultPassword, userId);


            return CreateResult(result);
        }

      
    }
}
