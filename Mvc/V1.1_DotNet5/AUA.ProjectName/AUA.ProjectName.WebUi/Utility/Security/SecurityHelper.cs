using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Common.Tools.Security;
using AUA.ProjectName.Models.GeneralModels.LoginModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using static System.String;

namespace AUA.ProjectName.WebUI.Utility.Security
{
    public static class SecurityHelper
    {
        public static bool IsLoggedIn(HttpContext context) => IsAuthenticated(context);

        private static bool IsAuthenticated(HttpContext context) => context.User.Identity != null &&
                                                                    context.User.Identity.IsAuthenticated;


        public static async Task UserLoginSuccessAsync(HttpContext context, UserLoggedInVm userLoggedInVm, bool rememberMe)
        {
            var userData = userLoggedInVm.ObjectSerialize();

            userData = EncryptionHelper.AesEncryptString(userData);
          
            await CreateFormsAuthenticationTicketAsync(rememberMe, userData, context);

        }
        
        public static UserLoggedInVm GetUserLoggedInVm(HttpContext context)
        {
            if (!IsLoggedIn(context))
                return new UserLoggedInVm();

            var userData = GetClimesData(context);

            if (IsNullOrWhiteSpace(userData))
                userData = GetUserDataFromContext(context);

            if (userData != Empty)
                userData = DecryptString(userData);


            return IsNullOrWhiteSpace(userData) ?
                   new UserLoggedInVm() :
                   userData.ObjectDeserialize<UserLoggedInVm>();

        }

        private static string DecryptString(string value)
        {
            return EncryptionHelper.AesDecryptString(value);
        }

        private static string GetUserDataFromContext(HttpContext context)
        {
            return context
                      .Items[AppConsts.UserDataClimeName]
                      ?.ToString();
        }

        public static string GetSha512Hash(string value)
        {
            return EncryptionHelper.GetSha512Hash(value);
        }

        private static string GetClimesData(HttpContext context)
        {
            return (from c in context.User.Claims
                    where c.Type == AppConsts.UserDataClimeName
                    select c.Value)
                    .FirstOrDefault();
        }

        private static async Task CreateFormsAuthenticationTicketAsync(bool rememberMe, string userData, HttpContext context)
        {
            var expireDate = GetExpireDate(rememberMe);

            var claimsIdentity = GetClaimsIdentity(userData);

                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = expireDate
                    });                   

        }

        private static ClaimsIdentity GetClaimsIdentity(string userData)
        {
            var claims = GetClaims(userData);

            return new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
           
        }

        private static IEnumerable<Claim> GetClaims(string userData)
        {
            return new List<Claim>
            {
                new Claim(AppConsts.UserDataClimeName,userData )
            };
        }

        private static DateTime GetExpireDate(bool rememberMe)
        {
            return rememberMe ? DateTime.UtcNow.AddDays(30) :
                                DateTime.UtcNow.AddDays(1);
        }


        public static async Task LogoffAsync(HttpContext context)
        {
            context.Session.Clear();

            await context
                     .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public static Guid CreateCryptographicallySecureGuid()
        {
            var rand = RandomNumberGenerator.Create();

            var bytes = new byte[16];
            rand.GetBytes(bytes);
            return new Guid(bytes);
        }

        public static string GetHashGuid()
        {
            return EncryptionHelper
                .GetSha256Hash(CreateCryptographicallySecureGuid().ToString());
        }
    }
}