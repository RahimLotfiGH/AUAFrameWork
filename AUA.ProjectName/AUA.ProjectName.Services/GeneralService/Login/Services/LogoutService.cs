using System.Threading.Tasks;
using AUA.ProjectName.Services.GeneralService.Login.Contracts;

namespace AUA.ProjectName.Services.GeneralService.Login.Services
{
    public class LogoutService : ILogoutService
    {
        private readonly IAccessTokenService _accessTokenService;

        public LogoutService(IAccessTokenService accessTokenService)
        {
            _accessTokenService = accessTokenService;
        }


        public async Task LogoutAsync(long userId)
        {
            _accessTokenService.DeleteUserAccessInMemory(userId);

            await _accessTokenService.DeleteActiveAccessTokenAsync(userId);

        }



    }
}
