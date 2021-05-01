using System.Collections.Generic;

namespace AUA.ProjectName.Models.BaseModel.BaseValidationModels
{
    public class ValidationResultVm
    {
        public ValidationResultVm()
        {
            ErrorVms = new List<ErrorVm>();
        }

        public IList<ErrorVm> ErrorVms { get; set; }

        public bool HasError => ErrorVms.Count > 0;

    }
}
