using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.GeneralModels.LoginModels;
using AUA.ProjectName.ValidationServices.Accounting.LoginModelValidations.Contracts;
using AUA.ProjectName.ValidationServices.BaseValidations;

namespace AUA.ProjectName.ValidationServices.Accounting.LoginModelValidations.Services
{
    public class LoginVmValidationService : BaseValidationService, ILoginVmValidationService
    {
        private LoginVm _loginVm;

        public ValidationResultVm Validation(LoginVm loginVm)
        {
            _loginVm = loginVm;

            DoValidation();

            return ValidationResultVm;
        }

        private void DoValidation()
        {
            FixValues();

            DefaultValidation();

            if (HasError) return;

            ValueValidation();

        }

        private void FixValues()
        {
            //todo: if need write code
        }

        private void DefaultValidation()
        {
            if (IsEmpty( _loginVm.UserName))
                AddError("UserName", "UserName is empty");

            if (IsEmpty(_loginVm.Password ))
                AddError("Password", "Password is empty");
        }

        private void ValueValidation()
        {

            if (_loginVm.UserName.Length > LengthConsts.MaxStringLen50)
                AddError("UserName", "Username length is longer than allowed");

            if (IsEmpty(_loginVm.Password))
                AddError("Password", "Password is empty");

            if (_loginVm.Password.Length > LengthConsts.MaxStringLen50)
                AddError("Password", "Password length is longer than allowed");

        }

    }
}
