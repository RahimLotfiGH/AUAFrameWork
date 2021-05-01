using System.Threading.Tasks;

namespace AUA.ProjectName.Services.GeneralService.Login.Contracts
{
    public interface ILogoutService
    {

        Task LogoutAsync(long userId);

    }
}
