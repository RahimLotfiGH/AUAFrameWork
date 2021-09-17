using System.ComponentModel;
using AUA.ProjectName.Common.Tools.Config.XmlSetting.BaseXmlPattern;

namespace AUA.ProjectName.Common.Tools.Config.XmlSetting
{
    public class SystemSetting : SystemSettingBase
    {
        private static string BranchName => nameof(SystemSetting);
        public static string AppName => Settings.GetWithXmlPath<string>(BranchName, ESettings.AppName.ToString());
        public static string AppVersion => Settings.GetWithXmlPath<string>(BranchName, ESettings.AppVersion.ToString());
        public static string EfConnectionString => Settings.GetWithXmlPath<string>(BranchName, ESettings.EfConnectionString.ToString());
        public static string DapperConnectionString => Settings.GetWithXmlPath<string>(BranchName, ESettings.DapperConnectionString.ToString());

        private enum ESettings
        {
            [Description("App Name")]
            AppName,
            [Description("App Version")]
            AppVersion,
            [Description("Ef Connection String")]
            EfConnectionString,
            [Description("Dapper Connection String")]
            DapperConnectionString
        }
    }
}
