using System.Threading.Tasks;
using AUA.ProjectName.Models.DataModels.LoginDataModels;
using AUA.ProjectName.Models.GeneralModels.LoginModels;
using AUA.ProjectName.Services.BaseService.Contracts;

namespace AUA.ProjectName.Services.GeneralService.Login.Contracts
{
    public interface ILoginService : IBaseBusinessService
    {
        Task<LoginDm> LoginAsync(LoginVm loginVm);

    }
}
