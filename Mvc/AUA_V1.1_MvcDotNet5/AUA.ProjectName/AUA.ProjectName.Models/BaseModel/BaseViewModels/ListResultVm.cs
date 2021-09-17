using System.Collections.Generic;

namespace AUA.ProjectName.Models.BaseModel.BaseViewModels
{
    public class ListResultVm<TResultVm>
    {
        public int TotalCount { get; set; }

        public IEnumerable<TResultVm> ResultVms { get; set; }

    }
}
