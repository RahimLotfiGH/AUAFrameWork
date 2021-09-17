using System.Threading.Tasks;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.ListModes.Accounting.AppUserModels;
using AUA.ProjectName.Models.ViewModels.Accounting.AppUserModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.Services.ListService.Accounting.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Contracts;
using Microsoft.AspNetCore.Mvc;
using AUA.ProjectName.WebUI.Controllers;
using AUA.ProjectName.WebUI.Utility.Authorizations;


namespace AUA.ProjectName.WebUI.Areas.Accounting.Controllers
{

    [Area(AreasConsts.Accounting)]
    [WebAuthorize(EUserAccess.AppUser)]
    public class AppUserController : BaseController
    {
        private readonly IAppUserDtoInsertValidationService _appUserDtoInsertValidationService;
        private readonly IAppUserService _appUserService;
        private readonly IAppUserUpdateVmValidationService _appUserUpdateVmValidationService;
        private readonly IRoleService _roleService;
        private readonly IAppUserListService _appUserListService;

        public AppUserController(IAppUserDtoInsertValidationService appUserDtoInsertValidationService
                                 , IAppUserService appUserService
                                 , IAppUserUpdateVmValidationService appUserUpdateVmValidationService
                                 , IRoleService roleService
                                 , IAppUserListService appUserListService)
        {
            _appUserDtoInsertValidationService = appUserDtoInsertValidationService;
            _appUserService = appUserService;
            _appUserUpdateVmValidationService = appUserUpdateVmValidationService;
            _roleService = roleService;
            _appUserListService = appUserListService;
        }

        public async Task<IActionResult> IndexAsync(AppUserSearchVm appUserSearchVm)
        {
            FixSearchVm(appUserSearchVm);
          
            var result = await _appUserListService.ListAsync(appUserSearchVm);

            return View(result);
        }

        public async Task<IActionResult> _InsertAsync()
        {
            var model = await CreateAppUserInsertVmAsync();


            return View(model);
        }

        public async Task<AppUserActionVm> CreateAppUserInsertVmAsync()
        {
            return new AppUserActionVm
            {
                RoleVms = await _roleService.GetRoleVmsAsync()
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _InsertAsync(AppUserActionVm actionVm)
        {
            await AppUserDtoInsertValidationAsync(actionVm);

            if (HasError)
                return RedirectToAction("Index");

            await _appUserService.InsertAsync(actionVm.AppUserDto);

            SuccessMessage("Insert user is success");

            return RedirectToAction("Index");
        }

        private async Task AppUserDtoInsertValidationAsync(AppUserActionVm actionVm)
        {
            actionVm.AppUserDto.CreatorUserId = CurrentUserId;

            var validationResultVm = await _appUserDtoInsertValidationService
                                                           .ValidationAsync(actionVm);

            AddErrors(validationResultVm);
        }

        public async Task<IActionResult> _UpdateAsync(long id)
        {
            var model = await CreateAppUserInsertVmAsync();

            model.AppUserDto = await _appUserService.GetDtoByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _Update(AppUserActionVm appUserUpdateVm)
        {
            await ValidationUpdateVmAsync(appUserUpdateVm);

            if (HasError)
                return RedirectToAction("Index");

            await _appUserService.UpdateWithoutPasswordAsync(appUserUpdateVm);

            await _appUserService.RemoveAndAddRoleAccess(appUserUpdateVm.RoleIds,
                                                         appUserUpdateVm.AppUserDto.Id);

            return RedirectToAction("Index");
        }

        private async Task ValidationUpdateVmAsync(AppUserActionVm userUpdateVm)
        {
            var validationResultVm = await _appUserUpdateVmValidationService
                                                          .ValidationAsync(userUpdateVm);
            AddErrors(validationResultVm);
        }

        public async Task<bool> _Delete(long id)
        {
            var hasDeleted = await _appUserService.TryDeleteAsync(id);

            return hasDeleted;
        }

      
    }
}
