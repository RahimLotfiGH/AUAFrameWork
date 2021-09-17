using AUA.ProjectName.Models.ViewModels.BaseViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AUA.ProjectName.WebUI.ViewComponents
{
    public class ModalFormViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke(ModalFormVm  modalFormVm)
        {

            return View("Index", modalFormVm);
        }
    }
}
