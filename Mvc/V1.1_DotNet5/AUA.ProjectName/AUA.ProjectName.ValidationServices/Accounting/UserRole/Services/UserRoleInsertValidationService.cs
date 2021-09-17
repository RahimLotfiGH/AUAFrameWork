using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.ViewModels.Accounting.UserRoleModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.UserRole.Contracts;
using AUA.ProjectName.ValidationServices.BaseValidations;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.ValidationServices.Accounting.UserRole.Services
{
    public class UserRoleInsertValidationService : BaseValidationService, IUserRoleInsertValidationService
    {
        private UserRoleInsertVm _userRoleInsertVm;
        private readonly IUserRoleService _userRoleService;


        public UserRoleInsertValidationService(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        public async Task<ValidationResultVm> ValidationAsync(UserRoleInsertVm userRoleInsertVm)
        {
            _userRoleInsertVm = userRoleInsertVm;

            await DoValidationAsync();

            return ValidationResultVm;
        }

        private async Task DoValidationAsync()
        {

            DefaultValidation();

            if (HasError) return;

            await ValidationRoleAsync();
        }

        private void DefaultValidation()
        {

            if (_userRoleInsertVm.RoleId == 0)
                AddError("RoleId", "RoleId is empty");

        }

        private async Task ValidationRoleAsync()
        {
            var roleNames = await GetRoleIdAsync();

            if (roleNames.Any())
                AddError("roleId", "The user has this role");

        }

        private async Task<List<int>> GetRoleIdAsync()
        {
            return await _userRoleService
                           .GetAll()
                           .AsNoTracking()
                           .Where(p => p.AppUserId == _userRoleInsertVm.AppUserId &&
                                       p.RoleId == _userRoleInsertVm.RoleId)
                           .Select(p => p.RoleId)
                           .ToListAsync();
        }


    }
}
