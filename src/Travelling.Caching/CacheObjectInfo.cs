using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Travelling.Caching
{
    public class CacheObjectInfo
    {
        public string CacheKeyName { set; get; }
        public string CacheKeyValue { set; get; }
        public string CacheKeyRemark { set; get; }

        public static IEnumerable<CacheObjectInfo> GetCacheKeysInfo()
        {
            Type type = typeof(CacheKeys);


            var fields = from it in type.GetFields()
                         let des = (DescriptionAttribute)it.GetCustomAttributes(typeof(DescriptionAttribute), false).SingleOrDefault()
                         let text = des.Description
                         select new CacheObjectInfo { CacheKeyName = it.Name, CacheKeyRemark = text, CacheKeyValue = it.GetValue(it).ToString() };
            return fields;
        }
    }
}
