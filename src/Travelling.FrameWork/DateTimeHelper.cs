using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.FrameWork
{
    /// <summary>
    /// 日期扩展
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// 获取日期是星期几
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="prefix">前缀</param>
        /// <returns></returns>
        public static string GetChineseWeekName(this DateTime date,string prefix="星期")
        {
            string weekName = "";
            switch(date.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    weekName = string.Format("{0}{1}",prefix,"五");
                    break;
                case DayOfWeek.Monday:
                     weekName = string.Format("{0}{1}",prefix,"一");
                    break;
                case DayOfWeek.Saturday:
                    weekName = string.Format("{0}{1}", prefix, "六");
                    break;
                case DayOfWeek.Sunday:
                    weekName = string.Format("{0}{1}", prefix, "日");
                    break;
                case DayOfWeek.Thursday:
                    weekName = string.Format("{0}{1}", prefix, "四");
                    break;
                case DayOfWeek.Tuesday:
                    weekName = string.Format("{0}{1}", prefix, "二");
                    break;
                case DayOfWeek.Wednesday:
                    weekName = string.Format("{0}{1}", prefix, "三");
                    break;
            }
            return weekName;
        }

        /// <summary>
        /// 携程接口对应的时间格式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToCtripDateFormat(this DateTime dt)
        {
            return string.Format("{0}.000+08:00", dt.GetDateTimeFormats('s')[0].ToString());
        }

        public static DateTime JsonToDateTime(string jsonDate)
        {
            string value = jsonDate.Substring(6, jsonDate.Length - 8);
            DateTimeKind kind = DateTimeKind.Utc;
            int index = value.IndexOf('+', 1);
            if (index == -1)
                index = value.IndexOf('-', 1);
            if (index != -1)
            {
                kind = DateTimeKind.Local;
                value = value.Substring(0, index);
            }
            long javaScriptTicks = long.Parse(value, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture);
            long InitialJavaScriptDateTicks = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks;
            DateTime utcDateTime = new DateTime((javaScriptTicks * 10000) + InitialJavaScriptDateTicks, DateTimeKind.Utc);
            DateTime dateTime;
            switch (kind)
            {
                case DateTimeKind.Unspecified:
                    dateTime = DateTime.SpecifyKind(utcDateTime.ToLocalTime(), DateTimeKind.Unspecified);
                    break;
                case DateTimeKind.Local:
                    dateTime = utcDateTime.ToLocalTime();
                    break;
                default:
                    dateTime = utcDateTime;
                    break;
            }
            return dateTime;
        }
    }


}
