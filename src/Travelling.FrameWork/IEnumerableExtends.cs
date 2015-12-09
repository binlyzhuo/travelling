using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.FrameWork
{
    /// <summary>
    /// IEnumerable扩展
    /// </summary>
    public static class IEnumerableExtends
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> Page<T>()
        {
            return null;
        }

        /// <summary>
        /// 拼接成字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Join<T>(this IEnumerable<T> list, string s)
        {
            return string.Join(s,list);
        }

        /// <summary>
        /// 获取个数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static List<T> Range<T>(this List<T> list, int num)
        {
            if (list.Count >= num)
                return list.GetRange(0, num);
            return list;
        }

        public static List<T> Take<T>(this List<T> list,int pageNum,int pageSize)
        {
            var items = list.Skip(pageNum * pageSize).Take(pageSize).ToList();
            return items;
        }

        public static int PageCount<T>(this List<T> list,int pageSize)
        {
            int pageCount = list.Count % pageSize == 0 ? list.Count / pageSize : list.Count / pageSize + 1;
            return pageCount;
        }
    }
}
