using System;
using System.Globalization;

namespace AUA.ProjectName.Common.Tools.Security
{
  public sealed  class TimeStampHelper
    {
        public static string GetTimeStamp()
        {

            var dateInNumberFormat = GetDateInNumberFormat();

            var timeInNumberFormat = GetTimeInNumberFormat();

            return dateInNumberFormat + timeInNumberFormat;
        }

        private static string GetDateInNumberFormat()
        {
            var persianCalendar = new PersianCalendar();
            var date = DateTime
                .Parse(DateTime.UtcNow.ToShortDateString());

            var year = persianCalendar.GetYear(date).ToString();

            var month = persianCalendar.GetMonth(date) < 10 ? "0" +
                                                              persianCalendar.GetMonth(date) :
                persianCalendar.GetMonth(date).ToString();

            var day = persianCalendar.GetDayOfMonth(date) < 10 ? "0" +
                                                                 persianCalendar.GetDayOfMonth(date) :
                persianCalendar.GetDayOfMonth(date).ToString();

            var dateStamp = $"{year}{month}{day}";

            return dateStamp;
        }

        private static string GetTimeInNumberFormat()
        {

            var time = DateTime
                .UtcNow
                .ToShortTimeString()
                .Substring(0, 5)
                .Replace(":", "");

            if (time.Trim().Length < 4)
                time = "0" + time;

            return time;

        }

        public static bool ValidationTimeStamp(string inputTimeStamp, int minutes)
        {
            var timeStamp = long.Parse(inputTimeStamp);
            var newTimeStamp = long.Parse(GetTimeStamp());

            return newTimeStamp - timeStamp <= minutes;

        }

        public static string GetPersianDate()
        {
            var persianCalendar = new PersianCalendar();
            var date = DateTime
                .Parse(DateTime.UtcNow.ToShortDateString());

            return
                $"{persianCalendar.GetYear(date)}-" +
                $"{persianCalendar.GetMonth(date)}-" +
                $"{persianCalendar.GetDayOfMonth(date)}";

        }

        public static string GetPersianTime()
        {

            var persianCalendar = new PersianCalendar();
            var date = DateTime
                .Parse(DateTime.Now.ToLongTimeString());

            return
                $"{persianCalendar.GetHour(date)}-" +
                $"{persianCalendar.GetMinute(date)}-" +
                $"{persianCalendar.GetSecond(date)}";


        }

    }
}
