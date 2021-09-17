using AUA.ProjectName.Models.ViewModels.BaseViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AUA.ProjectName.WebUI.ViewComponents
{
    public class FilterViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke(FilterFormVm  filterFormVm)
        {

            return View("Index", filterFormVm);
        }
    }
}
