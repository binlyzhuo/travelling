using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Travelling.UI
{
    /// <summary>
    /// MVC路由设置
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// 注册路由表
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Travelling.Web.Controllers.Travel" }

            );


            //routes.MapRoute(
            //    name: "Admin_Login",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Admin", action = "Login", id = UrlParameter.Optional },
            //    namespaces: new[] { "Travelling.Web.Controllers.Travel" }

            //);

            //routes.MapRoute(
            //    "Travel_HotelQuery",
            //    "Travel/JiuDian/Query/{cityid}_{areaid}_{locationid}_{brandid}_{start}_{end}_{hotellevel}_{price}",
            //    new { cityid = "0", areaid = "0", locationid = "0", brandid = "0", start = "2014-10-5", end = "2014-11-05", hotellevel = "all", price = "all" },
            //    namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            //);
        }
    }
}