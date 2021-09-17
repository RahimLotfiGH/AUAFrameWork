using System;
using System.Linq;
using AUA.ProjectName.Common.BaseUtility;
using AUA.ProjectName.Common.Consts;

namespace AUA.ProjectName.Common.Extensions
{
    public static class PersianExtension
    {
        public static void ApplyCorrectYeKe(this object entity)
        {
            if (entity == null) return;

            var properties = entity
                              .GetType()
                              .GetProperties()
                              .Where(p => string.Equals(p.PropertyType.Name, AppConsts.StringDataTypeName, StringComparison.CurrentCultureIgnoreCase))
                              .ToList();

            var propertyReflector = new PropertyReflector();

            foreach (var memberInfo in properties)
            {
                var name = memberInfo.Name;
                var targetObjectValue = propertyReflector.GetValue(entity, name);

                if (targetObjectValue != null)
                    propertyReflector
                        .SetValue(entity, name, targetObjectValue.ToString().ApplyUnifiedYeKe());

            }

        }

        public static string ApplyUnifiedYeKe(this string data)
        {
            return string.IsNullOrEmpty(data) ? 
                data : 
                data.Replace("ي", "ی")
                    .Replace("ك", "ک")
                    .Replace('\x200C'.ToString(), "")
                    .ReplacePersianNumbers()
                    .ReplaceArabicNumbers();
        }

        public static string ReplacePersianNumbers(this string data)
        {
            if (string.IsNullOrEmpty(data))
                return data;

            for (var index = 48; index < 58; ++index)
                data = data
                    .Replace(Convert.ToChar(1728 + index), Convert.ToChar(index));

            return data;
        }

        public static string ReplaceArabicNumbers(this string data)
        {
            return string.IsNullOrEmpty(data) ? 
                data : 
                data
                    .Replace("٠", "۰")
                    .Replace("١", "۱")
                    .Replace("٢", "۲")
                    .Replace("٣", "۳")
                    .Replace("٤", "۴")
                    .Replace("٥", "۵")
                    .Replace("٦", "۶")
                    .Replace("٧", "۷")
                    .Replace("٨", "۸")
                    .Replace("٩", "۹");
        }
    }
}
