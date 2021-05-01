using System;
using System.Linq;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Common.Tools.Security;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.InMemoryServices.Contracts;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.DataModels.General;
using AUA.ProjectName.Models.DataModels.LoginDataModels;
using AUA.ProjectName.Models.GeneralModels.AccessTokenModels;
using AUA.ProjectName.Models.GeneralModels.LoginModels;
using AUA.ProjectName.Models.InMemoryModels.General;
using AUA.ProjectName.Services.GeneralService.Login.Contracts;
using AUA.ProjectName.ValidationServices.Accounting.LoginModelValidations.Contracts;
using AUA.ProjectName.WebApi.Controllers;
using AUA.ProjectName.WebApi.Utility.ApiAuthorization;
using Microsoft.AspNetCore.Mvc;

namespace AUA.ProjectName.WebApi.Areas.Accounting.Controllers
{

    public class UserAccountController : BaseApiController
    {
        private readonly ILoginVmValidationService _loginVmValidationService;
        private readonly ILoginService _loginService;
        private readonly IAccessTokenService _accessTokenService;
        private readonly IInMemoryUserAccessService _inMemoryUserAccessService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly ILogoutService _logoutService;


        public UserAccountController(ILoginVmValidationService loginVmValidationService
                                 , ILoginService loginService
                                 , IAccessTokenService accessTokenService
                                 , IInMemoryUserAccessService inMemoryUserAccessService
                                 , IRefreshTokenService refreshTokenService
                                 , ILogoutService logoutService)
        {
            _loginVmValidationService = loginVmValidationService;
            _loginService = loginService;
            _accessTokenService = accessTokenService;
            _inMemoryUserAccessService = inMemoryUserAccessService;
            _refreshTokenService = refreshTokenService;
            _logoutService = logoutService;

        }


        [AllowAnonymousAuthorize]
        [HttpPost]
        public async Task<ResultModel<LoginResultVm>> LoginAsync(LoginVm loginVm)
        {
            ValidationLoginVm(loginVm);

            if (HasError)
                return CreateInvalidResult<LoginResultVm>();

            var loginDm = await DoLoginAsync(loginVm);

            if (!loginDm.IsAuthenticated)
                return CreateInvalidResult<LoginResultVm>(loginDm.ResultStatus);

            var loginResultVm = await CreateSuccessLoginVm(loginDm);


            return CreateSuccessResult(loginResultVm);
        }

        private async Task<LoginResultVm> CreateSuccessLoginVm(LoginDm loginDm)
        {
            var expirationDate = AccessTokenHelper.ExpirationDate;
            var accessToken = CreateJwtToken(loginDm.UserId, expirationDate);
            var refreshToken = GetGuid();
            var accessTokenVm = await GetAccessTokenVmAsync(loginDm.UserId);

            AddUserAccessInMemory(accessTokenVm);

            await InsertActiveAccessTokenAsync(accessToken,
                                               refreshToken,
                                               loginDm.UserId);

            return new LoginResultVm
            {
                UserName = loginDm.UserName,
                FirstName = loginDm.FirstName,
                LastName = loginDm.LastName,
                RoleIds = accessTokenVm.UserRoleAccess.UserRoleIds.Distinct(),
                UserAccessIds = accessTokenVm.UserRoleAccess.UserAccessIds.Distinct(),
                AccessToken = accessToken,
                ExpiresIn = expirationDate,
                RefreshToken = refreshToken
            };
        }

        private async Task<UserAccessTokenVm> GetAccessTokenVmAsync(long userId)
        {
            return await _accessTokenService
                               .GetAccessTokenVmAsync(userId);
        }

        private async Task InsertActiveAccessTokenAsync(string accessToken, string refreshToken, long userId)
        {
            await _accessTokenService.InsertActiveAccessTokenAsync(new ActiveAccessToken
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                IsActive = true,
                ExpirationDate = AccessTokenHelper.ExpirationRefreshTokenDate,
                UserId = userId
            });

        }

        private static string CreateJwtToken(long userId, DateTime expirationDate)
        {
            var jwtDataVm = new AccessTokenDataVm
            {
                UserId = userId,
                ExpirationDate = expirationDate,
            };

            var jwtDataVmSerialize = jwtDataVm.ObjectSerialize();

            return EncryptionHelper.AesEncryptString(jwtDataVmSerialize);
        }

        private void AddUserAccessInMemory(UserAccessTokenVm accessTokenVm)
        {
            _inMemoryUserAccessService.Delete(accessTokenVm.UserId);

            _inMemoryUserAccessService.Add(accessTokenVm.UserId,
                new UserAccessInMemoryVm
                {
                    RoleIds = accessTokenVm.UserRoleAccess.UserRoleIds,
                    UserAccessIds = accessTokenVm.UserRoleAccess.UserAccessIds,
                    UserId = accessTokenVm.UserId,
                });
        }

        private void ValidationLoginVm(LoginVm loginVm)
        {
            ValidationResultVm = _loginVmValidationService
                                                   .Validation(loginVm);
        }

        private async Task<LoginDm> DoLoginAsync(LoginVm loginVm)
        {
            return await _loginService.LoginAsync(loginVm);
        }

        [AllowAnonymousAuthorize]
        [HttpPost]
        public async Task<ResultModel<RefreshTokenResultVm>> RefreshTokenAsync(RefreshTokenVm refreshTokenVm)
        {
            if (!IsValidationRefreshTokenVm(refreshTokenVm))
                return CreateInvalidResult<RefreshTokenResultVm>(EResultStatus.InvalidData);

            var result = await _refreshTokenService.RefreshAsync(refreshTokenVm);

            if (!result.IsAuthenticated)
                return CreateInvalidResult<RefreshTokenResultVm>(result.ResultStatus);

            var resultVm = await CreateRefreshTokenAsync(result.UserId);

            return CreateSuccessResult(resultVm);
        }

        private async Task<RefreshTokenResultVm> CreateRefreshTokenAsync(long userId)
        {
            var expirationDate = AccessTokenHelper.ExpirationDate;
            var accessToken = CreateJwtToken(userId, expirationDate);
            var refreshToken = GetGuid();

            await _accessTokenService.DeleteActiveAccessTokenAsync(userId);

            await InsertActiveAccessTokenAsync(accessToken, refreshToken, userId);


            return new RefreshTokenResultVm
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresIn = expirationDate
            };
        }

        [OnlyHasAccessTokenAuthorization]
        [HttpPost]
        public async Task<ResultModel<bool>> LogoutAsync()
        {
            await _logoutService.LogoutAsync(UserId);

            return CreateSuccessResult(true);
        }


        private static bool IsValidationRefreshTokenVm(RefreshTokenVm refreshTokenVm)
        {
            var hasError = refreshTokenVm.AccessToken is null ||
                           refreshTokenVm.RefreshToken is null ||
                           refreshTokenVm.AccessToken.Length <=
                           AppConsts.MinimumAccessTokenLength ||
                           refreshTokenVm.AccessToken.Length <=
                           AppConsts.MinimumRefreshTokenLength;


            return hasError;
        }

        private static string GetGuid()
        {
            return SecurityHelper.GetHashGuid();
        }


    }
}
