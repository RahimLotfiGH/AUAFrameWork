using System;
using System.Globalization;
using AUA.ProjectName.Common.Consts;

namespace AUA.ProjectName.Common.Extensions
{
    public static class DateTimeExtension
    {

        public static string ToPersianDate(this DateTime date)
        {
            if (date == DateTime.MinValue || date == DateTime.MaxValue)
                return "";
            var persianCalendar = new PersianCalendar();
            return ToPersianDate(persianCalendar.GetYear(date), persianCalendar.GetMonth(date), persianCalendar.GetDayOfMonth(date));
        }

      public static DateTime ToDateTime(this string persianDate)
        {
            var persianCalendar = new PersianCalendar();
            var strArray = persianDate.Split(AppConsts.SplitDateTimeChar, StringSplitOptions.RemoveEmptyEntries);
            var year = int.Parse(strArray[0]);
            var month = int.Parse(strArray[1]);
            var day = int.Parse(strArray[2]);


            return persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
        }


        
        public static string ToPersianDate(int persianYear, int persianMonth, int persianDay)
        {
            return $"{(object) persianYear:d2}/{(object) persianMonth:d2}/{(object) persianDay:d2}";
        }


    }
}
