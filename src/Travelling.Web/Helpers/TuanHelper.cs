using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Travelling.Web.Helpers
{
    /// <summary>
    /// 团购相关功能
    /// </summary>
    public class TuanHelper
    {
        /// <summary>
        /// 团购产品携程页面
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static string CtripTuanUrl(int productId)
        {
            string allianceId = ConfigurationManager.AppSettings["C_ALLIANCEID"];
            string sid = ConfigurationManager.AppSettings["C_SID"];

            string url = string.Format("http://u.ctrip.com/union/CtripRedirect.aspx?TypeID=70&AllianceID={1}&SID={2}&Ouid=777&GroupID={0}", productId, allianceId, sid);
            return url;
        }

        /// <summary>
        /// 酒店星级
        /// </summary>
        /// <param name="star"></param>
        /// <returns></returns>
        public static string GetHotelStarName(int star)
        {
            string starName = "{0}星";
            switch(star)
            {
                case 1:
                    return string.Format(starName,"一");
                case 2:
                    return string.Format(starName, "二");
                case 3:
                    return string.Format(starName, "三");
                case 4:
                    return string.Format(starName, "四");
                case 5:
                    return string.Format(starName, "五");
            }
            return "";
        }

        /// <summary>
        /// 酒店团购剩余时间
        /// </summary>
        /// <param name="endDateString"></param>
        /// <returns></returns>
        public static string GetTuanLeftTime(string endDateString)
        {
            DateTime endDate = DateTime.Parse(endDateString);
            int totalMinutes = (int)(endDate - DateTime.Now).TotalMinutes;

            return string.Format("{0}天{1}小时{2}分钟", totalMinutes / 1440, (totalMinutes % 1440) / 60, (totalMinutes % 1440) % 60);
        }
    }
}
