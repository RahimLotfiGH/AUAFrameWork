using AUA.ProjectName.InMemoryServices.Contracts;
using AUA.ProjectName.InMemoryServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AUA.ProjectName.WebUi.RegistrationServices
{
    public static class InMemoryService
    {
        public static void RegistrationInMemoryService(this IServiceCollection services)
        {
            services.AddSingleton<IInMemoryLockedUsersService>(new InMemoryLockedUsersService());

        }
    }
}
