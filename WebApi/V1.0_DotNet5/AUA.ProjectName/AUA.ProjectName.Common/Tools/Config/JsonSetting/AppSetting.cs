using AUA.ProjectName.Common.Consts;
using System.Linq;

namespace AUA.ProjectName.Common.Tools.Config.JsonSetting
{
    public static class AppSetting
    {

   
    public static string DefaultPassword => AppConfiguration
                                               .GetConfigurationRoot()
                                               .GetSection(AppSettingConsts.AppSetting)
                                               .GetSection(AppSettingConsts.DefaultPassword)
                                               .Value;


        public static string DataEncryptionKey => AppConfiguration
                                                  .GetConfigurationRoot()
                                                  .GetSection(AppSettingConsts.AppSetting)
                                                  .GetSection(AppSettingConsts.DataEncryptionKey)
                                                  .Value;


        public static string BaseEncryptionKeyId => AppConfiguration
                                                    .GetConfigurationRoot()
                                                    .GetSection(AppSettingConsts.AppSetting)
                                                    .GetSection(AppSettingConsts.DataEncryptionKey)
                                                    .Value;


        public static string AppEnvironment => AppConfiguration
                                               .GetConfigurationRoot()
                                               .GetSection(AppSettingConsts.AppSetting)
                                               .GetSection(AppSettingConsts.AppEnvironment)
                                               .Value;

        public static string ClientBaseUrlAddress => AppConfiguration
                                                     .GetConfigurationRoot()
                                                     .GetSection(AppSettingConsts.AppSetting)
                                                     .GetSection(AppSettingConsts.ClientBaseUrlAddress)
                                                     .Value;

        public static string[] AuthorizedIPs => AppConfiguration
                                                     .GetConfigurationRoot()
                                                     .GetSection(AppSettingConsts.AppSetting)
                                                     .GetSection(AppSettingConsts.AuthorizedIPs)
                                                     .Value.Split(",")
                                                     .Select(p => p.Trim())
                                                     .ToArray();
    }
}
