using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Travelling.FrameWork;
using Travelling.ViewModel.Travel;

namespace Travelling.Web.Helpers
{
    public class ApplicationSetting
    {
        /// <summary>
        /// 根据IP获取城市信息
        /// </summary>
        /// <returns></returns>
        public static JsonLocalIPInfo GetLocalInfo()
        {
            string clientIP = GetIP();
            string taobaoIPApiUrl = ConfigurationManager.AppSettings["TaoBaoIPApi"];
            if (clientIP == "::1")
            {
                clientIP = "120.27.42.39";
            }


            string requestUrl = string.Format("{0}{1}", taobaoIPApiUrl, clientIP);
            string repData = HttpHelper.PostDataToServer(requestUrl, "", "GET");
            JsonLocalIPInfo localInfo = new JsonLocalIPInfo() { data = new IPLocalDetailInfo() { city="济南" } };//JsonConvert.DeserializeObject<JsonLocalIPInfo>(repData);
            return localInfo;
        }

        /// <summary>
        /// 获取客户端请求ip
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"]))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            if (string.IsNullOrEmpty(ip))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            return ip;
        }


    }
}
