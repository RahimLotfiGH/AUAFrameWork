using Microsoft.AspNetCore.Builder;

namespace AUA.ProjectName.WebUi.AppConfiguration
{
    public static class AppConfigExtension
    {
        public static void Configuration(this IApplicationBuilder app)
        {
            app.UseCors();

            app.DefaultConfiguration();

            app.MvcConfiguration();
        }

        private static void DefaultConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();

            app.UseSession();

            app.UseAuthorization();

            app.UseAuthentication();

        }

        private static void MvcConfiguration(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


            });

        }

    }
}
