using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;

namespace LuceneSite
{
    public partial class CachePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dtString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            object cacheResult = Cache.Add("dtcache", dtString, null, DateTime.Now.AddMinutes(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
            Cache.Insert("dtCache2", dtString, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(1), System.Web.Caching.CacheItemPriority.Normal, null);
            dtString = Cache.Get("dtcache") as string;
            object dt2 = Cache.Get("dtcache");
            Response.Write(dtString);
        }
    }
}