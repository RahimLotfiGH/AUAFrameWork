using System;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.WebUi.RegistrationServices;
using AUA.ProjectName.WebUi.Utility;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AUA.ProjectName.WebUi.AppConfiguration
{
    public static class StartupConfigExtension
    {
        public static void Configuration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.RegistrationServices();

            services.CookieConfig();

            services.SessionConfig();

            services.MvcConfig();

            services.AddCors();

        }

        private static void CookieConfig(this IServiceCollection services)
        {
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(config =>
                {
                    config.Cookie.HttpOnly = true;
                    config.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    config.Cookie.SameSite = SameSiteMode.Lax;
                    config.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
                });

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
            services.AddControllersWithViews();

        }

    }
}

