using System;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.WebApi.RegistrationServices;
using AUA.ProjectName.WebApi.Utility;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AUA.ProjectName.WebApi.AppConfiguration
{
    public static class StartupConfigExtension
    {
        public static void Configuration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.RegistrationServices();

            services.CookieConfig();

            //services.SessionConfig(); //Not recommend

            services.MvcConfig();

            services.SwaggerConfig();

            services.AddCors();
        }


        private static void CookieConfig(this IServiceCollection services)
        {
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

        }

        private static void SessionConfig(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.Cookie.Name = AppConsts.CookieName;
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.IsEssential = true;
            });
        }

        private static void MvcConfig(this IServiceCollection services)
        {
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options => options
                            .SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        }

        private static void SwaggerConfig(this IServiceCollection services)
        {
            
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(SwaggerConsts.VersionV1,
                                   new OpenApiInfo
                                   {
                                       Title = SwaggerConsts.Title,
                                       Version = SwaggerConsts.VersionV1
                                   });

                options.OperationFilter<SwaggerRequiredParameters>();

            });
        }
    }
}

