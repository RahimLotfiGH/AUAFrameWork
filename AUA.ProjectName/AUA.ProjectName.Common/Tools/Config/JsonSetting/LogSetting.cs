using AUA.ProjectName.Common.Consts;

namespace AUA.ProjectName.Common.Tools.Config.JsonSetting
{
    public static class LogSetting
    {

        public static string SqlLogConnection => AppConfiguration.GetConfigurationRoot()
                                                                 .GetSection(LogSettingConsts.LogSetting)
                                                                 .GetSection(LogSettingConsts.SqlLogConnection)
                                                                 .Value;

        public static bool IsEnableSqlServerLog => bool.Parse(AppConfiguration.GetConfigurationRoot()
                                                                              .GetSection(LogSettingConsts.LogSetting)
                                                                              .GetSection(LogSettingConsts.IsEnableSqlServerLog)
                                                                              .Value);



    }
}
