using System.Threading.Tasks;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Tools.Security;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.DataModels.AccessTokenDataModels;
using AUA.ProjectName.Models.GeneralModels.AccessTokenModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.Services.GeneralService.Login.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.Services.GeneralService.Login.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IActiveAccessTokenService _activeAccessTokenService;

        private ActiveAccessToken _activeAccessToken;

        public RefreshTokenService(IActiveAccessTokenService activeAccessTokenService)
        {
            _activeAccessTokenService = activeAccessTokenService;
        }

        public async Task<RefreshTokenDm> RefreshAsync(RefreshTokenVm refreshTokenVm)
        {
            await SetActiveAccessTokenAsync(refreshTokenVm.RefreshToken);

            if (_activeAccessToken is null)
                return CreateInvalidResult(EResultStatus.InvalidRefreshToken);

            if (!_activeAccessToken.IsActive)
                return CreateInvalidResult(EResultStatus.InvalidRefreshToken);

            if (!IsValidationAccessToken(refreshTokenVm.AccessToken))
                return CreateInvalidResult(EResultStatus.InvalidRefreshToken);

            if (!AccessTokenHelper.IsValidationExpirationDate(_activeAccessToken.ExpirationDate))
                return CreateInvalidResult(EResultStatus.RefreshTokenExpired);


            return CreateSuccessResult();
        }

        private async Task SetActiveAccessTokenAsync(string refreshToken)
        {
            _activeAccessToken = await _activeAccessTokenService
                                       .GetAll()
                                       .FirstOrDefaultAsync(token => token.RefreshToken == refreshToken);


        }
        private bool IsValidationAccessToken(string accessToken)
        {
            return _activeAccessToken.AccessToken == accessToken;
        }

        private RefreshTokenDm CreateSuccessResult()
        {
            return new()
            {
                ResultStatus = EResultStatus.Success,
                IsAuthenticated = true,
                UserId = _activeAccessToken.UserId
            };
        }

        private static RefreshTokenDm CreateInvalidResult(EResultStatus eResultStatus)
        {
            return new()
            {
                IsAuthenticated = false,
                ResultStatus = eResultStatus,
                UserId = 0
            };
        }

    }
}
