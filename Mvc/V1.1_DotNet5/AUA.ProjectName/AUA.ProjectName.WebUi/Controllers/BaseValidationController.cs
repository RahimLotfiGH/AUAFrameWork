using System.Collections.Generic;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AUA.ProjectName.WebUI.Controllers
{
    public class BaseValidationController : Controller
    {
        protected bool HasError { get; set; }

        private readonly IList<MessageProviderVm> _messageProviderVms;

        public BaseValidationController()
        {
            _messageProviderVms = new List<MessageProviderVm>();

        }

        protected void ErrorMessage(string message)
        {
            AddMessage(MessageTypeConsts.Error, message);

            HasError = true;

        }

        private void AddMessage(string messageType, string message)
        {
            _messageProviderVms.Add(new MessageProviderVm
            {
                MessageType = messageType,
                Message = message
            });

            TempData[MessageTypeConsts.MessageProvider] = _messageProviderVms.ObjectSerialize();
        }

        protected void SuccessMessage(string message)
        {
            AddMessage(MessageTypeConsts.Success, message);
        }

        protected void SuccessMessage(EResultStatus eResultStatus)
        {
            SuccessMessage(eResultStatus.ToDescription());
        }

        protected void NotifyMessage(string message)
        {
            AddMessage(MessageTypeConsts.Notify, message);
        }

        protected void NotifyMessage(EResultStatus eResultStatus)
        {
            NotifyMessage(eResultStatus.ToDescription());
        }

        protected void Message(string message)
        {
            AddMessage(MessageTypeConsts.Message, message);
        }

        protected void Message(EResultStatus eResultStatus)
        {
            Message(eResultStatus.ToDescription());
        }

        protected void WarningMessage(string message)
        {
            AddMessage(MessageTypeConsts.Warning, message);
        }

        protected void WarningMessage(EResultStatus eResultStatus)
        {
            WarningMessage(eResultStatus.ToDescription());
        }

        protected void AddErrors(ValidationResultVm resultVm)
        {
            foreach (var errorVm in resultVm.ErrorVms)
                ErrorMessage(errorVm.ErrorMessage);
        }

        protected void AddError(EResultStatus eResultStatus)
        {
            ErrorMessage(eResultStatus.ToDescription());
        }

        protected void AddError(string errorMessage)
        {
            ErrorMessage(errorMessage);
        }

        protected void Log(string message)
        {
            //ToDo:
        }


    }
}