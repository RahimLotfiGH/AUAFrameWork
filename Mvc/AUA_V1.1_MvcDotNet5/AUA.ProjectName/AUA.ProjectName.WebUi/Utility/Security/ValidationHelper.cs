using System.Linq;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;

namespace AUA.ProjectName.WebUi.Utility.Security
{
    public class ValidationHelper
    {
        public static bool IsValidationVm(BaseVm viewModel)
        {

            var properties = viewModel.GetType().GetProperties();


            return (from property in properties
                    let dataType = property.PropertyType.Name
                    where AppConsts.StringDataTypeName == dataType.ToLower()
                    select (string)property.GetValue(viewModel))
                .All(IsValidationInput);

        }

        public static bool IsValidationInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return true;

            input = input.ToLower();

            string[] sqlCheckList =
            {
                "--", ";--", ";", "/*", "*/", "@@", "@", "char", "nchar", "varchar", "nvarchar", "alter", "begin",
                "cast", "create", "cursor", "declare", "delete", "drop", "end", "exec", "execute", "fetch", "insert",
                "kill", "select", "sys", "sysobjects", "syscolumns", "table", "update"
            };

            return sqlCheckList.All(item => !input.Contains(item.ToLower()));

        }





    }
}