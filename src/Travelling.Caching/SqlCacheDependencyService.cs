using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace Travelling.Caching
{
    public class SqlCacheDependencyService
    {
        
        public static SqlCacheDependencyService Instance
        {
            get
            {
                return new SqlCacheDependencyService();
            }
        }

        void InsertCacheItems(string key, object cacheItem,string tableName)
        {
            SqlCacheDependency sqlDep = new SqlCacheDependency("","");
            //System.Web.Caching.SqlCacheDependencyAdmin.EnableTableForNotifications();
            //System.Web.Caching.Cache.
            //HttpContext.Current.Cache.Add();
        }
    }
}
