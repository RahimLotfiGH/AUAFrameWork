using System.Text.Encodings.Web;
using System.Text.Unicode;
using AUA.ProjectName.Services.GeneralService.Login.Contracts;
using AUA.ProjectName.Services.GeneralService.Login.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AUA.ProjectName.WebUi.RegistrationServices
{
    public static class GeneralService
    {
        public static void RegistrationGeneralServices(this IServiceCollection services)
        {

            services.RegistrationAccessServices();

        }

        private static void RegistrationAccessServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IAccessTokenService, AccessTokenService>();
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
            
        }



    }
}
