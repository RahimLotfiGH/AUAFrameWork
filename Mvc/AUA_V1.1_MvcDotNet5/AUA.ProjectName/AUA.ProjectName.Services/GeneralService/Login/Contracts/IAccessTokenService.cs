using System.Threading.Tasks;
using AUA.ProjectName.Models.DataModels.General;

namespace AUA.ProjectName.Services.GeneralService.Login.Contracts
{
    public interface IAccessTokenService
    {
        Task<UserAccessSessionVm> GetAccessTokenVmAsync(long userId);
    }
}
