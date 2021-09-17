using AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Services;
using AUA.ProjectName.ValidationServices.Accounting.LoginModelValidations.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.LoginModelValidations.Services;
using AUA.ProjectName.ValidationServices.Accounting.RoleValidation.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.RoleValidation.Services;
using AUA.ProjectName.ValidationServices.Accounting.UserAccessValidations.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.UserAccessValidations.Services;
using AUA.ProjectName.ValidationServices.Accounting.UserRole.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.UserRole.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AUA.ProjectName.WebUi.RegistrationServices
{
    public static class ValidationService
    {
        public static void RegistrationValidationService(this IServiceCollection services)
        {
            services.AccountingValidationService();
        }

        private static void AccountingValidationService(this IServiceCollection services)
        {
            services.AddScoped<ILoginVmValidationService, LoginVmValidationService>();

            services.AddScoped<IAppUserDtoInsertValidationService, AppUserDtoInsertValidationService>();
            services.AddScoped<IAppUserUpdateVmValidationService, AppUserUpdateVmValidationService>();
            services.AddScoped<IAppUserDeleteValidationService, AppUserDeleteValidationService>();

            services.AddScoped<IChangePasswordValidationService, ChangePasswordValidationService>();
            services.AddScoped<IUserIdValidationService, UserIdValidationService>();
            services.AddScoped<IRoleInsertValidationService, RoleInsertValidationService>();
            services.AddScoped<IRoleUpdateValidationService, RoleUpdateValidationService>();
            services.AddScoped<IRoleDeleteValidationService, RoleDeleteValidationService>();

            services.AddScoped<IUserRoleInsertValidationService, UserRoleInsertValidationService>();

            services.AddScoped<IUserAccessDtoInsertValidationService, UserAccessDtoInsertValidationService>();
            services.AddScoped<IUserAccessDtoUpdateValidationService, UserAccessDtoUpdateValidationService>();



        }


    }

}
