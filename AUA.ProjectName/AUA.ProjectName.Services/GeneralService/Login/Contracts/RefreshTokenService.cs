using System.Threading.Tasks;
using AUA.ProjectName.Models.DataModels.AccessTokenDataModels;
using AUA.ProjectName.Models.GeneralModels.AccessTokenModels;

namespace AUA.ProjectName.Services.GeneralService.Login.Contracts
{
    public interface IRefreshTokenService
    {
        Task<RefreshTokenDm> RefreshAsync(RefreshTokenVm refreshTokenVm);
    }
}
