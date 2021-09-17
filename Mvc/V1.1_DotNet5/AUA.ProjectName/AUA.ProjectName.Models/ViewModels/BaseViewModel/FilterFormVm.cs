using System;

namespace AUA.ProjectName.Models.ViewModels.BaseViewModel
{
    public class FilterFormVm
    {
        public string ActionName { get; set; }

        public string Title { get; set; }

        public string BtnTitle { get; set; }

        public  Func<object, object> ViewContent { get; set; }

    }
}
