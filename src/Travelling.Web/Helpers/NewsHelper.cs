using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Web.Helpers
{
    public class NewsHelper
    {
        public static string GetNewsHref(int newsid)
        {
            return string.Format("/newsinfo_{0}.html", newsid);
        }
    }
}
