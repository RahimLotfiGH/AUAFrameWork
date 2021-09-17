using System;
using AUA.ProjectName.Common.Tools.Config.JsonSetting;

namespace AUA.ProjectName.Common.Tools.Security
{
    public static class AccessTokenHelper
    {
        public static DateTime ExpirationDate => DateTime
                                                .UtcNow
                                                .AddMinutes(double.Parse(AccessTokenSetting.AccessTokenExpirationMinutes));


        public static DateTime ExpirationRefreshTokenDate => DateTime
                                                                .UtcNow
                                                                .AddMinutes(double.Parse(AccessTokenSetting.RefreshTokenExpirationMinutes));


        public static bool IsValidationExpirationDate(DateTime? expirationDate) => !(expirationDate is null) &&
                                                                                    DateTime.UtcNow <= expirationDate;





    }
}
