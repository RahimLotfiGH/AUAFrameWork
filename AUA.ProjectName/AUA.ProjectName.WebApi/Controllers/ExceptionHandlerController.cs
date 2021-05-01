using System.Collections.Generic;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUA.ProjectName.WebApi.Controllers
{

    public class ExceptionHandlerController : BaseApiController
    {
        [ApiExplorerSettings(IgnoreApi = true), HttpGet, HttpPost, HttpDelete, HttpPatch, HttpPut, HttpHead,
         HttpOptions, ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ResultModel<BaseViewModel> Index()
        {
            var message = CreateExceptionMessage(HttpContext);
            var errorIssuer = GetErrorIssuerExceptionMessage(HttpContext);

            //This feature is not free 
            //SaveExceptionMessage(message);

            return CreateExceptionMessage(message, errorIssuer);
        }

        private static string CreateExceptionMessage(HttpContext context)
        {
            var exHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            var error = exHandlerFeature?.Error;

            return error?.Message;
        }

        private static string GetErrorIssuerExceptionMessage(HttpContext context)
        {
            var exHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

            var urlError = GetUrlError(exHandlerFeature);

            return urlError;
        }


        private static ResultModel<BaseViewModel> CreateExceptionMessage(string message, string errorIssuer)
        {
            return new ResultModel<BaseViewModel>
            {
                Errors = new List<ErrorVm>
                {
                    new ErrorVm
                    {
                        ErrorType =ELogType.Exception,
                        ErrorMessage =  GetExceptionMessage(message),
                        ErrorIssuer =errorIssuer,

                    }
                }

            };
        }

        private static string GetExceptionMessage(string message)
        {
            return message ?? MessageConsts.ExceptionMessage;
        }

        private static string GetUrlError(IExceptionHandlerFeature src)
        {
            return src is null ?
                   string.Empty : 
                   (string) src.GetType().GetProperty("Path")?.GetValue(src, null);
        }

        private string GetReferer()
        {
            var userUrl = Request.Headers["Referer"].ToString();

            return string.IsNullOrWhiteSpace(userUrl) ?
                AppConsts.ErrorUrl :
                userUrl;
        }


    }
}
