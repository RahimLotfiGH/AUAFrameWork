using System.Threading.Tasks;
using AUA.ProjectName.DomainEntities.Entities.Accounting;
using AUA.ProjectName.Models.DataModels.General;

namespace AUA.ProjectName.Services.GeneralService.Login.Contracts
{
    public interface IAccessTokenService
    {
        Task<UserAccessTokenVm> GetAccessTokenVmAsync(long userId);

        Task InsertActiveAccessTokenAsync(ActiveAccessToken activeAccessToken);

        Task DeleteActiveAccessTokenAsync(long userId);
        void DeleteUserAccessInMemory(long userId);
    }
}
