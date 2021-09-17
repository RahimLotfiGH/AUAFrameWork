using System;
using AUA.ProjectName.Common.Enums;

namespace AUA.ProjectName.Models.ViewModels.BaseViewModel
{
    public class ModalFormVm
    {
        public string ModalFormId { get; set; }

        public string ActionName { get; set; }

        public EModalDialogSizeType ModalSizeType { get; set; }

        public string ModalSize { get; set; }

        public string Title { get; set; }

        public string BtnTitle { get; set; }

        public bool HiddenSubmitButton { get; set; }

        public bool HiddenCancelButton { get; set; }

        public bool HiddenButtons => HiddenSubmitButton && HiddenCancelButton;

        public  Func<object, object> ViewContent { get; set; }

    }
}
