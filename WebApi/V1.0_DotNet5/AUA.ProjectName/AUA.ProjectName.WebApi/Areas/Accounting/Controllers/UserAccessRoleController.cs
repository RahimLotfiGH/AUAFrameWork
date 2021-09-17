using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ViewModels.Accounting.UserRoleAccessModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.WebApi.Controllers;
using AUA.ProjectName.WebApi.Utility.ApiAuthorization;
using Microsoft.AspNetCore.Mvc;

namespace AUA.ProjectName.WebApi.Areas.Accounting.Controllers
{
    [WebApiAuthorize(EUserAccess.UserRoleAccess)]
    public class UserRoleAccessController : BaseApiController
    {
        private readonly IUserRoleAccessService _userRoleAccessService;

        public UserRoleAccessController(IUserRoleAccessService userRoleAccessService)
        {
            _userRoleAccessService = userRoleAccessService;
        }

        [HttpPost]
        public async Task<ResultModel<IEnumerable<UserRoleAccessDto>>> GetUserAccessRoleByRoleIdAsync(int roleId)
        {
            var result = await _userRoleAccessService.GetUserAccessRoleByRoleId(roleId);

          return  CreateSuccessResult(result);
        }

        [HttpPost]
        public async Task<ResultModel<bool>> InsertManyUserRoleAccessAsync(IEnumerable<UserRoleAccessInsertVm> userRoleAccessInsertVm)
        {

            await _userRoleAccessService.InsertVms(userRoleAccessInsertVm, UserId);

            return CreateSuccessResult(true);
        }

    }
}