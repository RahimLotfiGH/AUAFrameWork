using System.Collections.Generic;
using System.ComponentModel;
using AUA.ProjectName.Common.Tools.Config.XmlSetting.BaseXmlPattern;

namespace AUA.ProjectName.Common.Tools.Config.XmlSetting
{
    public class ServerSetting : SystemSettingBase
    {
        private static string BranchName => nameof(ServerSetting);
        public static string ServerName => Settings.GetWithXmlPath<string>(BranchName, ESettings.ServerName.ToString());
        public static string ServerIp => Settings.GetWithXmlPath<string>(BranchName, ESettings.ServerIp.ToString());
        public static string ServerLocation => Settings.GetWithXmlPath<string>(BranchName, ESettings.ServerLocation.ToString());
        public static bool IsServerAvailable => Settings.GetWithXmlPath<bool>(BranchName, ESettings.IsServerAvailable.ToString());
        public static List<int> Ports => Settings.GetListWithXmlPath<int>(BranchName, ESettings.Ports.ToString());
        //public static List<int> Ports => Settings.GetList<int>(ESettings.Ports.ToString());
        private enum ESettings
        {
            [Description("Server Name")]
            ServerName,
            [Description("Server Ip")]
            ServerIp,
            [Description("Server Location")]
            ServerLocation,
            [Description("Is Server Available")]
            IsServerAvailable,
            [Description("Is Server Available")]
            Ports
        }
    }
}