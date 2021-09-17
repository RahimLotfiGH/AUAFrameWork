using System.Collections.Generic;
using System.Threading.Tasks;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.EntitiesDto.Accounting;
using AUA.ProjectName.Models.ViewModels.Accounting.RoleModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.RoleValidation.Contracts;
using AUA.ServiceInfrastructure.BaseServices;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.ValidationServices.Accounting.RoleValidation.Services
{
    public class RoleInsertValidationService : InfraValidationService, IRoleInsertValidationService
    {
        private RoleActionVm _roleInsertVm;
        private readonly IRoleService _roleService;


        public RoleInsertValidationService(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<ValidationResultVm> ValidationAsync(RoleActionVm areaInsertVm)
        {
            _roleInsertVm = areaInsertVm;

            await DoValidationAsync();

            return ValidationResultVm;
        }

        private async Task DoValidationAsync()
        {

            DefaultValidation();

            if (HasError) return;

            await ValidationTitleAsync();

            if (HasError) return;

            SetUserAccess();
        }

        private void SetUserAccess()
        {
            if (_roleInsertVm.UserAccessIds is null) return;

            _roleInsertVm.RoleDto.UserRoleAccess = new List<UserRoleAccessDto>();

            foreach (var userAccessId in _roleInsertVm.UserAccessIds)
            {
                _roleInsertVm.RoleDto.UserRoleAccess.Add(new UserRoleAccessDto
                {
                    UserAccessId = userAccessId
                });
            }
        }

        private void DefaultValidation()
        {
            if (string.IsNullOrWhiteSpace(_roleInsertVm.RoleDto.Title))
                AddError("Title", "Title is empty !");

        }

        private async Task ValidationTitleAsync()
        {
            var isExistsRoleTitleAsync = await IsExistsRoleTitleAsync();

            if (isExistsRoleTitleAsync)
                AddError("Title", "Title is exists");

        }

        private async Task<bool> IsExistsRoleTitleAsync()
        {
            return await _roleService
                              .GetAll()
                              .AsNoTracking()
                              .AnyAsync(p => p.Title == _roleInsertVm.RoleDto.Title);

        }


    }
}
