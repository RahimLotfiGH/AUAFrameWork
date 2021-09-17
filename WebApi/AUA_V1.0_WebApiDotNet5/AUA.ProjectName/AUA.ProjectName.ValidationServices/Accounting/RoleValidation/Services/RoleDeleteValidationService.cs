using System.Threading.Tasks;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.RoleValidation.Contracts;
using AUA.ProjectName.ValidationServices.BaseValidations;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.ValidationServices.Accounting.RoleValidation.Services
{
    public class RoleDeleteValidationService : BaseValidationService, IRoleDeleteValidationService
    {
        private int _roleId;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;

        public RoleDeleteValidationService(IRoleService roleService,
                                            IUserRoleService userRoleService
        )
        {
            _roleService = roleService;
            _userRoleService = userRoleService;
        }

        public async Task<ValidationResultVm> ValidationAsync(int roleId)
        {
            _roleId = roleId;

            await DoValidationAsync();

            return ValidationResultVm;
        }

        private async Task DoValidationAsync()
        {
            DefaultValidation();

            if (HasError) return;

            await ValidationUserIdAsync();

            await ValidationRelationRoleAsync();
        }

        private void DefaultValidation()
        {
            if (IsEmpty(_roleId))
                AddError("Code", "Code is empty");
             
        }

        private async Task ValidationUserIdAsync()
        {
            var role = await _roleService.GetByIdAsync(_roleId);

            if (role is null)
                AddError("Id", "Id is empty");
             
        }

        private async Task ValidationRelationRoleAsync()
        {
            var role = await _userRoleService
                            .GetAllDto()
                            .FirstOrDefaultAsync(x => x.RoleId == _roleId);

            if (role != null)
                AddError("RoleId", "This role has relation");
            
        }


    }
}
