using System.Web.Mvc;
using System;
using System.Web;
using System.Text;
using Travelling.Web.Helpers;

namespace Travelling.UI.Areas.Travel
{
    /// <summary>
    /// Area处理类
    /// </summary>
    public class TravelAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// 默认Area
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "Travel";
            }
        }

        /// <summary>
        /// 注册Area
        /// </summary>
        /// <param name="context"></param>
        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
                "Travel_HotelQuery",
                "hotelsearch_{cityid}_{areaid}_{locationid}_{brandid}_{start}_{end}_{hotellevel}_{price}_{page}_{order}_{keywords}.html",
                new { controller = "JiuDian", action = "hotelsearch", cityid = "0", areaid = "0", locationid = "0", brandid = "0", start = DateTime.Now.ToString("yyyy-MM-dd"), end = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), hotellevel = "0", price = "0", page = 1, order = 0, keywords = UrlParameter.Optional },
                namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );

            context.MapRoute(
                "Travel_HotelOrder",
                "hotelorder_{hotelId}_{roomtypeCode}_{startDate}_{endDate}.html",
                new { controller = "JiuDian", action = "Order", roomtypeCode = UrlParameter.Optional, hotelId = UrlParameter.Optional, startDate = DateTime.Now.ToString("yyyy-MM-dd"), endDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") },
                namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );

            context.MapRoute(
                "Travel_HotelBrandDetail",
                "pinpai_{brandid}.html",
                new { controller = "PinPai", action = "HotelBrandDetail", brandid = 0 },
                namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );

            context.MapRoute(
                "Travel_HotelBrandCity",
                "pinpai2_{brandid}.html",
                new { controller = "PinPai", action = "HotelBrandCity", brandid = 0 },
                namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );

            context.MapRoute(
               "Travel_SceneryQuery",
               "ticketsearch_{provinceid}_{cityid}_{themeid}_{star}_{page}_{orderby}_{keywords}.html",
               new { controller = "JingDian", action = "ticketsearch", provinceid = 0, cityid = 0, themeid = 0, star = 0, page = 1, orderby = 0, keywords = UrlParameter.Optional },
               namespaces: new[] { "Travelling.Web.Controllers.Travel" }
           );

            context.MapRoute(
               "Travel_SceneryOrder",
               "sceneryorder_{sceneryid}_{policyID}.html",
               new { controller = "JingDian", action = "Order", sceneryid = 0, policyID = 0 },
               namespaces: new[] { "Travelling.Web.Controllers.Travel" }
           );

            context.MapRoute(
                "Travel_SceneryInfo",
                "SceneryInfo_{sceneryid}.html",
                new { controller = "JingDian", action = "SceneryInfo", sceneryid = UrlParameter.Optional },
                namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );


            context.MapRoute(
               "Travel_SceneryOrderResult",
               "ticketorder.html",
               new { controller = "JingDian", action = "OrderResult" },
               namespaces: new[] { "Travelling.Web.Controllers.Travel" }
           );

            context.MapRoute(
                "Travel_TuanCity",
                "tuan_{cityid}.html",
                new { controller = "Tuan", action = "TuanCity", cityid = UrlParameter.Optional },
                namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );
            context.MapRoute(
               "Travel_TuanCity2",
               "tuan2_{cityid}.html",
               new { controller = "Tuan", action = "TuanCity2", cityid = UrlParameter.Optional },
               namespaces: new[] { "Travelling.Web.Controllers.Travel" }
           );

            context.MapRoute(
              "Travel_CityInfo",
              "city_{cityId}.html",
              new { controller = "LandMark", action = "CityInfo", cityId = UrlParameter.Optional },
              namespaces: new[] { "Travelling.Web.Controllers.Travel" }
          );

            CustomerRouteConfig.HotelRegisterAreaRoute(context);
            CustomerRouteConfig.SceneryRegisterAreaRoute(context);
            CustomerRouteConfig.LandMarkRegisterAreaRoute(context);
            CustomerRouteConfig.KeZhanRegisterAreaRoute(context);
            CustomerRouteConfig.UtilityRegisterAreaRoute(context);
            CustomerRouteConfig.ArticleRegisterAreaRoute(context);
            CustomerRouteConfig.PinPaiRegisterAreaRoute(context);

            context.MapRoute(
                "Travel_default",
                "Travel/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );



        }
    }
}
