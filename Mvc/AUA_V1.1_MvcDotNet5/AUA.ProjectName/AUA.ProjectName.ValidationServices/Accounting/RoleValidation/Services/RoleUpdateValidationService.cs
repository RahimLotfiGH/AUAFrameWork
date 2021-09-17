using System.Threading.Tasks;
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
        private RoleActionVm _roleActionVm;
        private readonly IRoleService _roleService;

        public RoleUpdateValidationService(IRoleService roleService)
        {
            _roleService = roleService;

        }

        public async Task<ValidationResultVm> ValidationAsync(RoleActionVm roleUpdateVm)
        {
            _roleActionVm = roleUpdateVm;

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
            if (IsEmpty(_roleActionVm.RoleDto.Title))
                AddError("Title", "Title is empty");

        }

        private async Task ValidationUserNameAsync()
        {
            var isExists = await IsExistsRoleTitleAsync();

            if (isExists)
                AddError("Title", "Title is exists");

        }

        private async Task<bool> IsExistsRoleTitleAsync()
        {
            return await _roleService
                               .GetAll()
                               .AsNoTracking()
                               .AnyAsync(p => p.Title == _roleActionVm.RoleDto.Title &&
                                              p.Id != _roleActionVm.RoleDto.Id);


        }


    }
}

