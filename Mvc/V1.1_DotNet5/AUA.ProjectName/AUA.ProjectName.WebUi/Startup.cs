using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AUA.ProjectName.WebUi.AppConfiguration;

namespace AUA.ProjectName.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.Configuration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //In AUA Framework ExceptionHandler not free 

            app.UseDeveloperExceptionPage();


            app.Configuration();
        }
    }
}
