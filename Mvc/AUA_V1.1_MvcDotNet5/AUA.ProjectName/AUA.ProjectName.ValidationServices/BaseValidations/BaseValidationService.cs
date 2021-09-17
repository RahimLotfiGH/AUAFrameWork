using System.Linq;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ServiceInfrastructure.BaseServices;
using static System.String;

namespace AUA.ProjectName.ValidationServices.BaseValidations
{
    public abstract class BaseValidationService : InfraValidationService
    {
        protected static bool IsEmpty(string value) => IsNullOrWhiteSpace(value);

        protected static bool IsEmpty(long? value) => value == null ||
                                                      value == 0;

        protected static bool IsPhoneNumber(string phoneNumber)
        {
            return phoneNumber is null ||
                   ValidationConsts.PhoneNumberLength.Contains(phoneNumber.Length) &&
                   phoneNumber.All(char.IsDigit);
        }

        protected static bool IsDigit(string value)
        {
            return decimal.TryParse(value, out _);
        }

        public static bool HasDangerCharacterViewModel(BaseViewModel viewModel)
        {

            var properties = viewModel.GetType().GetProperties();


            return (from property in properties
                    let dataType = property.PropertyType.Name
                    where AppConsts.StringDataTypeName == dataType.ToLower()
                    select (string)property.GetValue(viewModel))
                .All(HasDangerCharacters);

        }

        protected static bool HasDangerCharacters(string input)
        {
            if (IsNullOrWhiteSpace(input)) return false;

            input = input.ToLower();

            string[] sqlCheckList =
            {
                "--", ";--", ";", "/*", "*/", "@@", "@", "char", "nchar", "varchar", "nvarchar", "alter", "begin",
                "cast", "create", "cursor", "declare", "delete", "drop", "end", "exec", "execute", "fetch", "insert",
                "kill", "select", "sys", "sysobjects", "syscolumns", "table", "update"
            };

            return sqlCheckList.Any(item => input.Contains(item.ToLower()));

        }
    }
}
