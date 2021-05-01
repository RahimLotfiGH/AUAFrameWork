using AUA.ProjectName.Common.Consts;

namespace AUA.ProjectName.Common.Tools.Config.XmlSetting.BaseXmlPattern
{
    public class SystemSettingBase
    {

        protected static readonly XmlReader Settings =
            new XmlReader(AppSettingConsts.XmlSettingFilePath);

    }

}