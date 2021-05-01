using System;
using Microsoft.Extensions.DependencyInjection;

namespace AUA.ProjectName.WebApi.Utility
{
    public static class ServiceFactory
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static T GetService<T>()
        {

            return ServiceProvider.GetService<T>();

        }
    }
}
