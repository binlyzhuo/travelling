using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Caching
{
    /// <summary>
    /// An abstract class for implementing a basic cache provider
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// 清除所有缓存
        /// </summary>
        void ClearAllCache();

        /// <summary>
        /// 根据键值删除缓存数据
        /// </summary>
        /// <param name="key"></param>
        void ClearCacheItem(string key);

        /// <summary>
        /// 缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cacheItem"></param>
        void InsertCacheItems(string key, object cacheItem);
        
        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        object GetCacheItem(string cacheKey);

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        T GetCacheItem<T>(string cacheKey)
            where T : class;
    }
}
