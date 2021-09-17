using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.UserAccessValidations.Contracts;
using Microsoft.AspNetCore.Mvc;
using AUA.ProjectName.WebUI.Controllers;
using AUA.ProjectName.WebUI.Utility.Authorizations;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.WebUI.Areas.Accounting.Controllers
{

    [Area(AreasConsts.Accounting)]
    [WebAuthorize(EUserAccess.UserAccess)]
    public class UserAccessController : BaseController
    {
        private readonly IUserAccessDtoInsertValidationService _userAccessDtoInsertValidationService;
        private readonly IUserAccessDtoUpdateValidationService _userAccessDtoUpdateValidationService;
        private readonly IUserAccessService _userAccessService;

        public UserAccessController(IUserAccessDtoInsertValidationService appUserDtoInsertValidationService
                                 , IUserAccessService userAccessService
                                 , IUserAccessDtoUpdateValidationService userAccessDtoUpdateValidationService)
        {
            _userAccessDtoInsertValidationService = appUserDtoInsertValidationService;
            _userAccessService = userAccessService;
            _userAccessDtoUpdateValidationService = userAccessDtoUpdateValidationService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var appUserDtos = await GetUserAccessDtosAsync();

            return View(appUserDtos);
        }

        private async Task<IEnumerable<UserAccessDto>> GetUserAccessDtosAsync()
        {
            return await _userAccessService
                             .GetAllDto()
                             .AsNoTracking()
                             .ToListAsync();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _InsertAsync(UserAccessDto userAccessDto)
        {
            await AppUserDtoInsertValidationAsync(userAccessDto);

            if (HasError)
                return RedirectToAction("Index");

            await _userAccessService.InsertAsync(userAccessDto);

            SuccessMessage("UserAccess user is success");

            return RedirectToAction("Index");
        }

        private async Task AppUserDtoInsertValidationAsync(UserAccessDto userAccessDto)
        {
            var validationResultVm = await _userAccessDtoInsertValidationService
                                                           .ValidationAsync(userAccessDto);

            AddErrors(validationResultVm);
        }

        public async Task<IActionResult> _UpdateAsync(int id)
        {
            var model = await _userAccessService.GetDtoByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _Update(UserAccessDto userAccessDto)
        {

            await ValidationUpdateVmAsync(userAccessDto);

            if (HasError)
                return RedirectToAction("Index");

            await _userAccessService.UpdateAsync(userAccessDto);

            return RedirectToAction("Index");
        }

        private async Task ValidationUpdateVmAsync(UserAccessDto userAccessDto)
        {
            var validationResultVm = await _userAccessDtoUpdateValidationService
                                                           .ValidationAsync(userAccessDto);
            AddErrors(validationResultVm);
        }

        public async Task<bool> _Delete(int id)
        {
            var hasDeleted = await _userAccessService.TryDeleteAsync(id);

            return hasDeleted;
        }
    }
}
