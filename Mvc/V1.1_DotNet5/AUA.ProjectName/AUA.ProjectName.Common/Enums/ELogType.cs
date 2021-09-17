using System.ComponentModel;

namespace AUA.ProjectName.Common.Enums
{
    public enum ELogType
    {
        [Description("Information")]
        Information = 1,

        [Description("Warning")]
        Warning = 2,

        [Description("Error")]
        Error = 3,

        [Description("Danger")]
        Danger = 4,

        [Description("Exception")]
        Exception =5

    }
}