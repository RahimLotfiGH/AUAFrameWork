using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.WebApi.AppConfiguration;

namespace AUA.ProjectName.WebApi
{
    public class StartupStaging
    {
        public IConfiguration Configuration { get; }

        public StartupStaging(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configuration();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseExceptionHandler(AppConsts.ExceptionHandler);

            app.UseHsts();

            app.Configuration();

        }
    }
}
