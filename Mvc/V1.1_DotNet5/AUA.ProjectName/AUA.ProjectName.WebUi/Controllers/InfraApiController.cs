using System;
using System.Collections.Generic;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.GeneralModels.LoginModels;
using AUA.ProjectName.WebUI.Utility.Security;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUA.ProjectName.WebUI.Controllers
{


    public class InfraController : BaseValidationController
    {
        protected ValidationResultVm ValidationResultVm;
        private UserLoggedInVm _accessTokenDataVm;

        protected InfraController()
        {
            ValidationResultVm ??= new ValidationResultVm();
        }

        protected JsonResult CreateResult(object data)
        {
            return new(data);
        }


        private UserLoggedInVm GetAccessTokenDataVm()
        {
            return _accessTokenDataVm ??= SecurityHelper.GetUserLoggedInVm(HttpContext); ;
        }


        protected static Exception GetException(HttpContext context)
        {
            var exHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            var exception = exHandlerFeature?.Error;

            return exception;
        }

        protected long CurrentUserId => GetAccessTokenDataVm() is null ?
                                 AppConsts.SystemUserId :
                                 GetAccessTokenDataVm().UserId;

        protected string CurrentUserName => GetAccessTokenDataVm() is null ?
                                            string.Empty :
                                            GetAccessTokenDataVm().UserName;

        protected IEnumerable<EUserAccess> CurrentUserAccessIds => GetAccessTokenDataVm() is null ?
                                            new List<EUserAccess>() :
                                            GetAccessTokenDataVm().UserAccessIds;

        protected IEnumerable<int> CurrentUserRoleIds => GetAccessTokenDataVm() is null ?
                                                         new List<int>() :
                                                         GetAccessTokenDataVm().RoleIds;

        protected string CurrentUserFirstName => GetAccessTokenDataVm() is null ?
                                                 string.Empty :
                                                  GetAccessTokenDataVm().FirstName;

        protected string CurrentUserLastName => GetAccessTokenDataVm() is null ?
                                                string.Empty :
                                                 GetAccessTokenDataVm().LastName;

        protected string CurrentUserFullName => CurrentUserFirstName + " " + CurrentUserLastName;


        //protected FileResult ExportExcelFile(MemoryStream fileStream, string fileName = FileInfoConsts.DefaultExcelFileName)
        //{
        //    if (NoExtension(fileName))
        //        fileName += FileInfoConsts.ExcelExtension;

        //    return File(fileStream, FileInfoConsts.ExcelContent, fileName);
        //}

        //private static bool NoExtension(string fileName) => string.IsNullOrWhiteSpace(Path.GetExtension(fileName));

    }
}
