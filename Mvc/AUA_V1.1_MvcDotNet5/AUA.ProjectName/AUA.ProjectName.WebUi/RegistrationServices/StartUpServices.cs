using Microsoft.Extensions.DependencyInjection;

namespace AUA.ProjectName.WebUi.RegistrationServices
{
    public static class StartUpServices
    {
        public static void RegistrationServices(this IServiceCollection services)
        {
            services.RegistrationValidationService();

            services.RegistrationBusinessService();

            services.RegistrationEntitiesService();

            services.RegistrationGeneralServices();

            services.RegistrationToStaticIoc();

            services.RegistrationInMemoryService();

            services.RegistrationListService();
            
        }


        private static void RegistrationToStaticIoc(this IServiceCollection services)
        {
            //Not recommend
            // ServiceFactory.ServiceProvider = services.BuildServiceProvider();
        }

    }
}
