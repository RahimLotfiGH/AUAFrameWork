using AUA.ProjectName.Common.Enums;

namespace AUA.ProjectName.Models.BaseModel.BaseValidationModels
{
    public class ErrorVm
    {
        public string ErrorMessage { get; set; }

        public string ErrorIssuer { get; set; }

        public ELogType ErrorType { get; set; }

    }
}
