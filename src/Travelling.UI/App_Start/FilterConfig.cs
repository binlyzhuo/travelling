﻿using System.Web;
using System.Web.Mvc;
using Travelling.Web.Filter;

namespace Travelling.UI
{
    /// <summary>
    /// 默认过滤器
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// 注册过滤器
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GZipCompressAttribute());
        }
    }
}