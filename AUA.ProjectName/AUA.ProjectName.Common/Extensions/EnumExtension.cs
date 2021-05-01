using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AUA.ProjectName.Common.Extensions
{
    public static class EnumExtension
    {

        public static string ToDescription<TEnum>(this TEnum val)
        {
            if (val == null)
            {
                return "";
            }

            var enumName = val.ToString();

            try
            {
                var field = val.GetType().GetField(enumName ?? string.Empty);

                #region Get By Description Attribute
                var descriptionAttr = field.GetCustomAttribute<DescriptionAttribute>(false);

                if (descriptionAttr != null)
                    return descriptionAttr.Description;

                #endregion

                #region Get By Display Attribute
                var displayAttr = field.GetCustomAttribute<DisplayAttribute>(inherit: false);
                if (displayAttr != null)
                {
                    var name = displayAttr.GetName();
                    if (!string.IsNullOrEmpty(name))
                    {
                        return name;
                    }
                }
                #endregion

                return enumName;
            }
            catch (Exception)
            {
                return enumName;
            }
        }

        public static string ToDescription<TEnum>(this TEnum val,string message)
        {
            return message + val.ToDescription();
        }

        public static int GetId<TEnum>(this TEnum currentKey) where TEnum : struct
        {
            return Convert.ToInt32(currentKey);
        }
        public static string GetStringId<TEnum>(this TEnum currentKey) where TEnum : struct
        {
            return Convert.ToInt32(currentKey).ToString();
        }


    }
}