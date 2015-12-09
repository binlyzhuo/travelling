using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Runtime;
using System.Collections;

namespace Travelling.Caching
{
    /// <summary>
    /// 缓存处理
    /// </summary>
    public class DefaultCacheProvider:ICacheProvider
    {


        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public void ClearAllCache()
        {
            IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                HttpRuntime.Cache.Remove(CacheEnum.Key.ToString());
            }
        }

        /// <summary>
        /// 移除相关缓存数据
        /// </summary>
        /// <param name="key"></param>
        public void ClearCacheItem(string key)
        {
            if (HttpRuntime.Cache[key] != null)
            {
                HttpRuntime.Cache.Remove(key);
            }
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public object GetCacheItem(string cacheKey)
        {
            object cacheItem = HttpRuntime.Cache.Get(cacheKey);
            return cacheItem;
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public T GetCacheItem<T>(string cacheKey)
            where T:class
        {
            object cacheItem = GetCacheItem(cacheKey);
            if (cacheItem == null)
                return default(T);
            return cacheItem as T;
        }

        /// <summary>
        /// 缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cacheItem"></param>
        public void InsertCacheItems(string key, object cacheItem)
        {
            HttpRuntime.Cache.Insert(key,cacheItem);
        }

    }
}
