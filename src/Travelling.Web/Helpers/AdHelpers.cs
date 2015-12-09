using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Travelling.Web.Helpers
{
    public class AdHelpers
    {
        public static string SevenDayAd()
        {
            string zhuna_refId = ConfigurationManager.AppSettings["Zhuna_agent_id"];
            return string.Format("http://union.zhuna.cn/7days.asp?agent_id={0}", zhuna_refId);
        }
    }
}
