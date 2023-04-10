using System;
using System.Globalization;

namespace Shared
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime dateTime)
        {
            var persianCalendar = new PersianCalendar();

            var persianDateString =
                persianCalendar.GetYear(dateTime) + "/" +
                persianCalendar.GetMonth(dateTime).ToString("00") + "/" +
                persianCalendar.GetDayOfMonth(dateTime).ToString("00") + " " +
                persianCalendar.GetHour(dateTime).ToString("00") + ":" +
                persianCalendar.GetMinute(dateTime).ToString("00") + ":" +
                persianCalendar.GetMinute(dateTime).ToString("00")
                ;

            return persianDateString;
        }

        public static string ToShamsiWithoutTime(this DateTime dateTime)
        {
            var persianCalendar = new PersianCalendar();

            var persianDateString =
                persianCalendar.GetYear(dateTime) + "/" +
                persianCalendar.GetMonth(dateTime).ToString("00") + "/" +
                persianCalendar.GetDayOfMonth(dateTime).ToString("00")
                ;

            return persianDateString;
        }

        public static string GetShamsiYear(this DateTime dateTime)
        {
            var persianCalendar = new PersianCalendar();

            var persianDateString =
                persianCalendar.GetYear(time: dateTime).ToString()
                ;

            persianDateString = 
                persianDateString.Substring(startIndex: 2, length: 2);

            return persianDateString;
        }

        public static DateTime ToMiladi(this string dateTime)
        {
            var getPartsPersianDate = dateTime.Split('/');

            var pc = new PersianCalendar();

            var dt = new DateTime
                (
                    year: Convert.ToInt32(value: getPartsPersianDate[0]),
                    month: Convert.ToInt32(value: getPartsPersianDate[1]),
                    day: Convert.ToInt32(value: getPartsPersianDate[2]),
                    calendar: pc
                );

            return dt;
        }
    }
}
