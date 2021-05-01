using System.Collections.Generic;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.InMemoryServices.Contracts;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.GeneralModels.AccessTokenModels;
using AUA.ProjectName.Models.GeneralModels.GeneralVm;
using AUA.ProjectName.Models.InMemoryModels.General;
using AUA.ProjectName.WebApi.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AUA.ProjectName.WebApi.Controllers
{
    [Route(AreasConsts.ApiRoute)]
    [ApiController]
    public class InfraApiController : ControllerBase
    {
        protected ValidationResultVm ValidationResultVm;
        private AccessTokenDataVm _accessTokenDataVm;
        private UserAccessInMemoryVm _accessInMemoryVm;


        protected InfraApiController()
        {
            ValidationResultVm ??= new ValidationResultVm();
        }

        protected static ResultModel<TResultModel> CreateInvalidResult<TResultModel>(EResultStatus eResultStatus)
        {
            return new()
            {
                Errors = new List<ErrorVm>
                {
                    new()
                    {
                        ErrorType = ELogType.Danger,
                        ErrorMessage =  eResultStatus.ToDescription(),
                        ErrorIssuer = string.Empty,
                    }
                }

            };
        }

        protected ResultModel<TResultModel> CreateInvalidResult<TResultModel>()
        {
            return new()
            {
                Errors = ValidationResultVm.ErrorVms,
            };
        }

        protected JsonResult CreateInvalidResult()
        {
            var result = new ResultModel<NullObjectPattern>
            {
                Errors = ValidationResultVm.ErrorVms,
            };

            return new JsonResult(result);
        }

        protected static JsonResult CreateInvalidResult(EResultStatus eResultStatus)
        {
            var result = new ResultModel<NullObjectPattern>
            {
                Errors = new List<ErrorVm>
                {
                    new()
                    {
                        ErrorType = ELogType.Danger,
                        ErrorMessage =  eResultStatus.ToDescription(),
                        ErrorIssuer = string.Empty,
                    }
                }

            };

            return new JsonResult(result);
        }

        protected JsonResult CreateResult(object data)
        {
            return new(data);
        }

        private UserAccessInMemoryVm GetAccessInMemoryVm()
        {
            var inMemoryUserAccessService = HttpContext.RequestServices.GetService<IInMemoryUserAccessService>();

            return _accessInMemoryVm ??= inMemoryUserAccessService.Get(UserId);
        }

        protected void AddError(string errorIssuer, string message)
        {
            ValidationResultVm.ErrorVms.Add(new ErrorVm
            {
                ErrorMessage = message,
                ErrorIssuer = errorIssuer
            });
        }

        protected void AddError(string message)
        {
            AddError(string.Empty, message);
            Log(message);
        }

        protected static ResultModel<TResultModel> CreateSuccessResult<TResultModel>(TResultModel resultModel)
        {
            return new ResultModel<TResultModel>
            {
                Result = resultModel,
            };
        }

        protected void Log(string message)
        {
            //ToDo:
        }

        private AccessTokenDataVm GetAccessTokenDataVm()
        {
            return _accessTokenDataVm ??= ApplicationHelper.GetCurrentUserDataVm(HttpContext);
        }

        protected ResultModel<EResultStatus> CreateResult(EResultStatus result)
        {
            return IsSuccess(result) ?
                   CreateSuccessResult(result) :
                   CreateInvalidResult<EResultStatus>(result);
        }
        protected bool IsSuccess(EResultStatus status)
        {
            return status == EResultStatus.Success;
        }
        protected void ValidationSearchVm(BaseSearchVm searchVm)
        {
            if (searchVm.PageSize <= 0)
                AddError("PageSize", " PageSize can not be less than zero or zero");

            if (searchVm.TotalSize < 0)
                AddError("TotalSize", " TotalSize can not be less than zero ");

            if (searchVm.PageNumber <= 0)
                AddError("PageNumber", " PageNumber can not be less than zero or zero");

            if (!Enum<EAppType>.IsExistValue(searchVm.AppTypeCode.GetId()))
                AddError("AppType", "Invalid AppType code");

        }

        protected void SetAuditInfo<T>(BaseVm<T> baseVm)
        {
            baseVm.CreatorUserId = UserId;
        }


        protected long UserId => GetAccessTokenDataVm() is null ?
                                AppConsts.SystemUserId :
                                GetAccessTokenDataVm().UserId;


        protected bool HasError => ValidationResultVm.HasError;

      

    }
}
