using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Travelling.Web.Helpers
{
    /// <summary>
    /// 自定义路由
    /// </summary>
    public class CustomerRouteConfig
    {
        public static void KeZhanRegisterAreaRoute(AreaRegistrationContext context)
        {
            context.MapRoute(
             "Travel_KeZhanGuZhenHotels",
             "guzhen_{pinyin}_{page}.html",
             new { controller = "KeZhan", action = "GuZhenPage", page = 1, pinyin = UrlParameter.Optional },
             namespaces: new[] { "Travelling.Web.Controllers.Travel" }
         );
            context.MapRoute(
             "Travel_KeZhanGuZhen",
             "guzhen_{pinyin}.html",
             new { controller = "KeZhan", action = "GuZhen", pinyin = UrlParameter.Optional },
             namespaces: new[] { "Travelling.Web.Controllers.Travel" }
         );

            context.MapRoute(
              "Travel_KeZhanJiuDian",
              "hotelinfo2_{hotelid}.html",
              new { controller = "KeZhan", action = "Detail", hotelid = UrlParameter.Optional },
              namespaces: new[] { "Travelling.Web.Controllers.Travel" }
          );

            
        }

        public static void UtilityRegisterAreaRoute(AreaRegistrationContext context)
        {
            context.MapRoute(
              "Travel_UtilityPageError",
              "error.html",
              new { controller = "Utility", action = "Error"},
              namespaces: new[] { "Travelling.Web.Controllers.Travel" }
          );
            context.MapRoute(
              "Travel_UtilityPage404",
              "page404.html",
              new { controller = "Utility", action = "PageNotFound" },
              namespaces: new[] { "Travelling.Web.Controllers.Travel" }
          );
        }

        public static void ArticleRegisterAreaRoute(AreaRegistrationContext context)
        {
            context.MapRoute(
             "Travel_NewsInfo",
             "newsinfo_{newsid}.html",
             new { controller = "News", action = "NewsInfo", newsid = UrlParameter.Optional },
             namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );

            context.MapRoute(
             "Travel_NewsList",
             "news.html",
             new { controller = "News", action = "NewsList"},
             namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );
        }

        public static void HotelRegisterAreaRoute(AreaRegistrationContext context)
        {
            context.MapRoute(
             "Travel_hotelsearchlist",
             "hotelsearchlist_{cityid}.html",
             new { controller = "JiuDian", action = "HotelSearchList", cityid = UrlParameter.Optional },
             namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );

            context.MapRoute(
             "Travel_hotelsearchlistwithsearchkey",
             "hotelsearchlist_{cityid}/{keywords}",
             new { controller = "JiuDian", action = "HotelSearchList", cityid = UrlParameter.Optional, keywords = UrlParameter.Optional },
             namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );

            context.MapRoute(
                "Travel_HotelInfo",
                "HotelInfo_{hotelId}_{startDate}_{endDate}.html",
                new { controller = "JiuDian", action = "HotelInfo", hotelId = UrlParameter.Optional, startDate = DateTime.Now.ToString("yyyy-MM-dd"), endDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") },
                namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );

            context.MapRoute(
                "Travel_HotelInfo2",
                "Hotelinfo_{hotelId}.html",
                new { controller = "JiuDian", action = "Hotelinfo", hotelId = 0 },
                namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );

            context.MapRoute(
                "Travel_HotelInfozhuna",
                "Hotelinfo1_{hotelId}.html",
                new { controller = "QiTian", action = "HotelInfo", hotelId = 0 },
                namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );

            context.MapRoute(
                "Travel_BrandInCity", 
                "city{cityid}/chain{brandid}.html",
                new { controller = "JiuDian", action = "HotelBrandInCity", cityid = 1, brandid = UrlParameter.Optional }, 
                namespaces: new[] { "Travelling.Web.Controllers.Travel" });


        }

        public static void LandMarkRegisterAreaRoute(AreaRegistrationContext context)
        {
            context.MapRoute(
             "Travel_hotelcitylist",
             "hotelcitylist.html",
             new { controller = "LandMark", action = "HotelCityList" },
             namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );
            context.MapRoute(
             "Travel_scenerycitylist",
             "scenerycitylist.html",
             new { controller = "LandMark", action = "SceneryCityList" },
             namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );

            context.MapRoute(
             "Travel_schools",
             "schools.html",
             new { controller = "LandMark", action = "Schools" },
             namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );

            context.MapRoute(
             "Travel_schoolsincity",
             "city{cityid}/schools.html",
             new { controller = "LandMark", action = "SchoolsInCity" },
             namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );
        }

        public static void SceneryRegisterAreaRoute(AreaRegistrationContext context)
        {
            context.MapRoute(
             "Travel_ticketsearchlist",
             "ticketsearchlist_{cityid}.html",
             new { controller = "JingDian", action = "TicketSearchList", cityid = UrlParameter.Optional },
             namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );


            context.MapRoute(
             "Travel_ticketsearchlist2",
             "ticketsearchlist.html",
             new { controller = "JingDian", action = "TicketSearchList2"},
             namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );

            context.MapRoute(
             "Travel_ticketsearchlist_theme",
             "ticketsearchlist/theme{themeid}.html",
             new { controller = "JingDian", action = "TicketSearchWithTheme", themeid = UrlParameter.Optional },
             namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );

            context.MapRoute(
             "Travel_ticketsearchlist_province",
             "ticketsearchlist/province{provinceid}.html",
             new { controller = "JingDian", action = "TicketSearchWithProvince", provinceid = UrlParameter.Optional },
             namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );

        }

        public static void PinPaiRegisterAreaRoute(AreaRegistrationContext context)
        {
            context.MapRoute(
             "Travel_7daysinn",
             "7daysinn.html",
             new { controller = "PinPai", action = "SevenDays", provinceid = UrlParameter.Optional },
             namespaces: new[] { "Travelling.Web.Controllers.Travel" }
            );
        }
    }
}
