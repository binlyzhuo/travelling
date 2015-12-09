using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Travelling.Web.Helpers
{
    public class ZhunaHotelHelper
    {
        public static string ZhunaHotelOrderPage(int hotelid,int roomid,int planid,string start,string end,string webpath="")
        {
            string ageng_id = ConfigurationManager.AppSettings["Zhuna_agent_id"];
            string agent_md = ConfigurationManager.AppSettings["Zhuna_agent_md"];
            return string.Format("http://www.api.zhuna.cn/e/b.php?agent_id={0}&agent_md={1}&hid={2}&rid={3}&pid={4}&tm1={5}&tm2={6}&webpath={7}", ageng_id, agent_md, hotelid, roomid, planid, start, end,webpath);
        }
    }
}
