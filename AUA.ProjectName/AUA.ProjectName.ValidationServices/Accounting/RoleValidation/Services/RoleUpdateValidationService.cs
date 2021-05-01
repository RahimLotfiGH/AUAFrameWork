using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.ViewModels.Accounting.RoleModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.RoleValidation.Contracts;
using AUA.ProjectName.ValidationServices.BaseValidations;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.ValidationServices.Accounting.RoleValidation.Services
{
    public class RoleUpdateValidationService : BaseValidationService, IRoleUpdateValidationService
    {
        private RoleUpdateVm _roleVm;
        private readonly IRoleService _roleService;

        public RoleUpdateValidationService(IRoleService roleService)
        {
            _roleService = roleService;

        }

        public async Task<ValidationResultVm> ValidationAsync(RoleUpdateVm roleUpdateVm)
        {
            _roleVm = roleUpdateVm;

            await DoValidationAsync();

            return ValidationResultVm;
        }

        private async Task DoValidationAsync()
        {

            DefaultValidation();

            if (HasError) return;

            await ValidationUserNameAsync();

        }

        private void DefaultValidation()
        {
            if (!Enum<EAppType>.IsExistValue(_roleVm.AppTypeCode.GetId()))
                AddError("AppType", "Invalid AppType code");

            if (IsEmpty(_roleVm.Title))
                AddError("Title", "Title is empty");

        }

        private async Task ValidationUserNameAsync()
        {
            var roles = await GetRoleTitleAsync();

            if (roles.Any(p => p.Id != _roleVm.Id))
                AddError("Title", "Title is exists");

        }

        private async Task<List<Role>> GetRoleTitleAsync()
        {
            return await _roleService
                               .GetAll()
                               .AsNoTracking()
                               .Where(p => p.Title == _roleVm.Title)
                               .ToListAsync();

        }


    }
}

