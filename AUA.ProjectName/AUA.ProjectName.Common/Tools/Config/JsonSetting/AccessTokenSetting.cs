using AUA.ProjectName.Common.Consts;

namespace AUA.ProjectName.Common.Tools.Config.JsonSetting
{
    public class AccessTokenSetting
    {
        public static string Issuer => AppConfiguration
                                       .GetConfigurationRoot()
                                       .GetSection(AppSettingConsts.BearerTokensOptions)
                                       .GetSection(AppSettingConsts.Issuer)
                                       .Value;

        public static string Audience => AppConfiguration
                                        .GetConfigurationRoot()
                                        .GetSection(AppSettingConsts.BearerTokensOptions)
                                        .GetSection(AppSettingConsts.Audience)
                                        .Value;

        public static string EncryptionKey => AppConfiguration
                                              .GetConfigurationRoot()
                                              .GetSection(AppSettingConsts.BearerTokensOptions)
                                              .GetSection(AppSettingConsts.EncryptionKey)
                                              .Value;

        public static string AccessTokenExpirationMinutes => AppConfiguration
                                                            .GetConfigurationRoot()
                                                            .GetSection(AppSettingConsts.BearerTokensOptions)
                                                            .GetSection(AppSettingConsts.AccessTokenExpirationMinutes)
                                                            .Value;

        public static string RefreshTokenExpirationMinutes => AppConfiguration
                                                             .GetConfigurationRoot()
                                                             .GetSection(AppSettingConsts.BearerTokensOptions)
                                                             .GetSection(AppSettingConsts.RefreshTokenExpirationMinutes)
                                                             .Value;


    }
}
