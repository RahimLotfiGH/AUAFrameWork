using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ListModes.Accounting.RoleModels;
using AUA.ProjectName.Models.ViewModels.Accounting.RoleModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.Services.ListService.Accounting.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.RoleValidation.Contracts;
using AUA.ProjectName.WebApi.Controllers;
using AUA.ProjectName.WebApi.Utility.ApiAuthorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.WebApi.Areas.Accounting.Controllers
{
    [WebApiAuthorize(EUserAccess.UserRole)]
    public class RoleController : BaseApiController
    {
        private readonly IRoleService _roleService;
        private readonly IRoleInsertValidationService _roleInsertValidationService;
        private readonly IRoleUpdateValidationService _roleUpdateValidationService;
        private readonly IRoleDeleteValidationService _roleDeleteValidationService;
        private readonly IRoleListService _roleListService;

        public RoleController(IRoleService roleService
                                 , IRoleInsertValidationService roleValidationService
                                 , IRoleUpdateValidationService roleUpdateValidationService
                                 , IRoleDeleteValidationService roleDeleteValidationService
                                 , IRoleListService roleListService)
        {
            _roleService = roleService;
            _roleInsertValidationService = roleValidationService;
            _roleUpdateValidationService = roleUpdateValidationService;
            _roleDeleteValidationService = roleDeleteValidationService;
            _roleListService = roleListService;
        }

        [HttpPost]
        public async Task<ResultModel<ListResultVm<RoleListDto>>> ListAsync(RoleSearchVm roleSearchVm)
        {
            ValidationSearchVm(roleSearchVm);

            if (HasError)
                return CreateInvalidResult<ListResultVm<RoleListDto>>();

            var result = await _roleListService
                                        .ListAsync(roleSearchVm);


            return CreateSuccessResult(result);
        }

        [HttpGet]
        public async Task<ResultModel<List<RoleDto>>> ListAsync()
        {
            var result = await _roleService.GetAllDto()
                                           .AsNoTracking()
                                           .ToListAsync();

            return CreateSuccessResult(result);
        }


        [HttpPost]
        public async Task<ResultModel<int>> InsertAsync(RoleInsertVm roleVm)
        {
            await ValidationInsertVm(roleVm);

            if (HasError)
                return CreateInvalidResult<int>();

            var id = await InsertCustomVmAsync(roleVm);

            return id == 0 ?
                   CreateInvalidResult<int>(EResultStatus.Success) :
                   CreateSuccessResult(id);
        }

        private async Task ValidationInsertVm(RoleInsertVm roleVm)
        {
            ValidationResultVm = await _roleInsertValidationService
                                                      .ValidationAsync(roleVm);
        }

        private async Task<int> InsertCustomVmAsync(RoleInsertVm roleVm)
        {
            roleVm.CreatorUserId = UserId;

            return await _roleService.InsertCustomVmAsync(roleVm);
        }

        [HttpPost]
        public async Task<ResultModel<bool>> UpdateAsync(RoleUpdateVm roleUpdateVm)
        {
            await ValidationUpdateVmAsync(roleUpdateVm);

            if (HasError)
                return CreateInvalidResult<bool>();

            var result = await _roleService.UpdateCustomVmAsync(roleUpdateVm);

            return result ?
                   CreateSuccessResult(true) :
                   CreateInvalidResult<bool>();
        }

        private async Task ValidationUpdateVmAsync(RoleUpdateVm roleUpdateDto)
        {
            ValidationResultVm = await _roleUpdateValidationService
                                                      .ValidationAsync(roleUpdateDto);
        }

        [HttpDelete]
        public async Task<ResultModel<bool>> DeleteAsync(int roleId)
        {
            await ValidateDeleteRoleIdAsync(roleId);

            if (HasError)
                return CreateInvalidResult<bool>();

            var isDeleted = await _roleService.TryDeleteAsync(roleId);

            return isDeleted ?
                   CreateSuccessResult(true) :
                   CreateInvalidResult<bool>(EResultStatus.ErrorOperations);
        }

        private async Task ValidateDeleteRoleIdAsync(int roleId)
        {
            ValidationResultVm = await _roleDeleteValidationService
                                               .ValidationAsync(roleId);
        }


    }
}
