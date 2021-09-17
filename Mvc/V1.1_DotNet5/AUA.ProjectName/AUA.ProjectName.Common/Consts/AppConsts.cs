using System;
using System.Collections.Generic;

namespace AUA.ProjectName.Common.Consts
{
    public static class AppConsts
    {
        public const string AppName = "AUA Frameworke";

        public const long SystemUserId = 1;

        public const string ConnectionStrings = "ConnectionStrings";

        public const string EfDbConnection = "EntityFrameWorkConnection";
        
        public static string AppSettingsFilePath => $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json";

        public const string StringDataTypeName = "string";

        public const string CookieName = ".AUA.Session";

        public const string ShowErrorPageStatusUrl = "/Home/ErrorPage?resultStatus=";

        public const int DefaultPageSize = 10;

        public const int DefaultPageNumber = 0;

        public static IEnumerable<int> NationCodeLength => new[] { 10, 11 };
        
        public static string[] SplitDateTimeChar => new[] { "/", "\\", ":", "-", " " };

        public static string UserDataClimeName = "_UserDataClime_";

        public static string LogSplitter = " >> ";

        public static int UnlimitedPageSize = 10000;

    }
}
