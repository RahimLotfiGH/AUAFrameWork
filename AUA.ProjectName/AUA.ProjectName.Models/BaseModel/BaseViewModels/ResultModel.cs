using System.Collections.Generic;
using System.Linq;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;

namespace AUA.ProjectName.Models.BaseModel.BaseViewModels
{
    public class ResultModel<TResult>
    {
        public ResultModel()
        {
            Errors = new List<ErrorVm>();
        }

        public bool IsSuccess => !Errors.Any();

        public IEnumerable<ErrorVm> Errors { get; set; }

        public TResult Result { get; set; }

    }

}
