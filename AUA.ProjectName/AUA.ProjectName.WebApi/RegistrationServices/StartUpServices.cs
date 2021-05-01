using Microsoft.Extensions.DependencyInjection;

namespace AUA.ProjectName.WebApi.RegistrationServices
{
    public static class StartUpServices
    {
        public static void RegistrationServices(this IServiceCollection services)
        {
            services.RegistrationValidationService();

            services.RegistrationGeneralServices();

            services.RegistrationBusinessService();

            services.RegistrationEntitiesService();

            services.RegistrationExWebService();

            services.RegistrationToStaticIoc();

            services.RegistrationInMemoryService();

            services.RegistrationListService();

        }


        private static void RegistrationToStaticIoc(this IServiceCollection services)
        {
            // Inject in static class(Unrecommend)

            // ServiceFactory.ServiceProvider = services.BuildServiceProvider();
        }

    }
}
