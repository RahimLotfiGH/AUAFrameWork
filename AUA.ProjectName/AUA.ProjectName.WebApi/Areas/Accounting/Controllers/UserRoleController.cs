using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ListModes.Accounting.UserRoleModels;
using AUA.ProjectName.Models.ViewModels.Accounting.UserRoleModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.Services.ListService.Accounting.Contracts;
using AUA.ProjectName.WebApi.Controllers;
using AUA.ProjectName.WebApi.Utility.ApiAuthorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.WebApi.Areas.Accounting.Controllers
{
    [WebApiAuthorize(EUserAccess.UserRole)]
    public class UserRoleController : BaseApiController
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IUserRoleListService _userRoleListService;

        public UserRoleController(IUserRoleService userRoleService
                                , IUserRoleListService userRoleListService)
        {
            _userRoleService = userRoleService;
            _userRoleListService = userRoleListService;
        }

        [HttpPost]
        public async Task<ResultModel<ListResultVm<UserRoleListVm>>> ListAsync(UserRoleSearchVm userRoleSearchVm)
        {
            ValidationSearchVm(userRoleSearchVm);

            if (HasError)
                return CreateInvalidResult<ListResultVm<UserRoleListVm>>();

            var result = await _userRoleListService
                                        .ListAsync(userRoleSearchVm);


            return CreateSuccessResult(result);
        }



        [HttpGet]
        public async Task<ResultModel<List<UserRoleDto>>> ListAsync()
        {
            var result = await _userRoleService
                                       .GetAllDto()
                                       .AsNoTracking()
                                       .ToListAsync();


            return CreateSuccessResult(result);
        }

        [HttpGet]
        public async Task<ResultModel<List<UserRoleDto>>> GetUserRoles(long userId)
        {
            var result = await _userRoleService
                                        .GetAllDto()
                                        .Where(p => p.AppUserId == userId)
                                        .AsNoTracking()
                                        .ToListAsync();


            return CreateSuccessResult(result);
        }

        [HttpPost]
        public async Task<ResultModel<bool>> InsertManyAsync(IEnumerable<UserRoleInsertManyVm> userRoleVms)
        {

            await _userRoleService
                       .InsertUserRoleInsertManyVmsAsync(userRoleVms, UserId);


            return CreateSuccessResult(true);
        }

    }
}
