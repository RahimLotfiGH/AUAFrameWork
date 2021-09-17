using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ViewModels.Accounting.RoleModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.RoleValidation.Contracts;
using Microsoft.AspNetCore.Mvc;
using AUA.ProjectName.WebUI.Controllers;
using AUA.ProjectName.WebUI.Utility.Authorizations;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.WebUI.Areas.Accounting.Controllers
{

    [Area(AreasConsts.Accounting)]
    [WebAuthorize(EUserAccess.Role)]
    public class RoleController : BaseController
    {
        private readonly IRoleInsertValidationService _roleInsertValidationService;
        private readonly IRoleUpdateValidationService _updateValidationService;
        private readonly IRoleService _roleService;
        private readonly IUserAccessService _userAccessService;

        public RoleController(IRoleService roleService
                              , IRoleUpdateValidationService updateValidationService
                              , IRoleInsertValidationService roleInsertValidationService
                              , IUserAccessService userAccessService)
        {
            _roleService = roleService;
            _updateValidationService = updateValidationService;
            _roleInsertValidationService = roleInsertValidationService;
            _userAccessService = userAccessService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var appUserDtos = await GetUserAccessDtosAsync();

            return View(appUserDtos);
        }

        private async Task<IEnumerable<RoleDto>> GetUserAccessDtosAsync()
        {
            return await _roleService
                             .GetAllDto()
                             .AsNoTracking()
                             .ToListAsync();
        }

        public async Task<IActionResult> _InsertAsync()
        {
            var roleActionVm = await GetUserAccessVmsAsync();

            return View(roleActionVm);
        }

        public async Task<RoleActionVm> GetUserAccessVmsAsync()
        {
            return new RoleActionVm
            {
                UserAccessVms = await _userAccessService
                                           .GetUserAccessVmsAsync()
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _InsertAsync(RoleActionVm roleActionVm)
        {
            await AppUserDtoInsertValidationAsync(roleActionVm);

            if (HasError)
                return RedirectToAction("Index");

            await _roleService.InsertAsync(roleActionVm.RoleDto);

            SuccessMessage("Insert UserRole is success");

            return RedirectToAction("Index");
        }

        private async Task AppUserDtoInsertValidationAsync(RoleActionVm userAccessDto)
        {
            var validationResultVm = await _roleInsertValidationService
                                                           .ValidationAsync(userAccessDto);

            AddErrors(validationResultVm);
        }

        public async Task<IActionResult> _UpdateAsync(int id)
        {
            var model = await GetUserAccessVmsAsync();

            model.RoleDto = await _roleService.GetDtoByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _Update(RoleActionVm roleActionVm)
        {
            await ValidationUpdateVmAsync(roleActionVm);

            if (HasError)
                return RedirectToAction("Index");

            await _roleService.UpdateAsync(roleActionVm.RoleDto);

            await _roleService.RemoveAndAddRoleAccess(roleActionVm.UserAccessIds,
                                                      roleActionVm.RoleDto.Id);

            return RedirectToAction("Index");
        }

        private async Task ValidationUpdateVmAsync(RoleActionVm roleActionVm)
        {
            var validationResultVm = await _updateValidationService
                                                           .ValidationAsync(roleActionVm);
            AddErrors(validationResultVm);
        }

        public async Task<bool> _Delete(int id)
        {
            await _roleService.RemoveAllRoleAccessAsync(id);

            var hasDeleted = await _roleService.TryDeleteAsync(id);


            return hasDeleted;
        }
    }
}
