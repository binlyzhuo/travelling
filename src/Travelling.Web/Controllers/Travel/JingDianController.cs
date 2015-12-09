using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Travelling.FrameWork;
using Travelling.OpenApiEntity.Scenery.Module;
using Travelling.OpenApiLogic;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Dto.Ticket;
using Travelling.ViewModel.Ticket;
using Travelling.ViewModel.Travel;
using Travelling.Web.Helpers;

namespace Travelling.Web.Controllers.Travel
{
    /// <summary>
    /// 景区门票Controller
    /// </summary>
    public class JingDianController : BaseController
    {
        private readonly ISceneryTicketInfoBusinessLogic sceneryTicketBusiness;
        private readonly IHotelCityBusinessLogic hotelCityBusinessLogic;

        private string GetView(string viewName)
        {
            return string.Format("~/Areas/Travel/Views/JingDian/{0}.cshtml", viewName);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ticketBusiness"></param>
        public JingDianController(ISceneryTicketInfoBusinessLogic ticketBusiness,IHotelCityBusinessLogic  hotelCityLogic)
        {
            if (sceneryTicketBusiness==null)
            {
                sceneryTicketBusiness = ticketBusiness;
            }
            if(hotelCityBusinessLogic==null)
            {
                hotelCityBusinessLogic = hotelCityLogic;
            }
        }

        /// <summary>
        /// 景区预定首页
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 3600)]
        public ActionResult Index()
        {
            string title = "景点门票频道-景点门票预订-门票预订-卓家客栈zjkz78.com";
            string descriptions = "景点门票, 景点门票预订, 门票预订, 全国旅游景点门票, 卓家客栈zjkz78.com";
            string keyWords = "卓家客栈预订平台提供全国八千家景点门票3-7折预订，您不但可以预订打折门票，还可以了解到最新的门票价格、旅游资讯及游客点评。预订旅游景点门票就上卓家客栈，在线免费预订，景点取票付款，赶快行动吧！";

            SetPageSEO(title,keyWords,descriptions);
            var items = sceneryTicketBusiness.GetSceneryThemes();
            ViewBag.Themes = items;

            return View(GetView("Index"));
        }

        /// <summary>
        /// 查看景区详细信息
        /// </summary>
        /// <param name="sceneryid"></param>
        /// <returns></returns>
        public ActionResult SceneryInfo(int sceneryid = 0)
        {
            var sceneryinfo = sceneryTicketBusiness.GetSceneryInfoByID(sceneryid);
            string seoTitle = string.Format("{0}门票、{0}门票价格、{0}预订、{0}", sceneryinfo.SceneryName);
            string seoKeyWords = string.Format("{0}门票_{0}门票价格_{0}预订_{0}_卓家客栈预订平台", sceneryinfo.SceneryName);
            string seoDescriptions = string.Format("卓家客栈旅游网提供{0}特价门票预订，无需在线支付，解除您一切后顾之忧。成功预订{0}门票，让您享受实实在在的优惠，卓家客栈是您快乐出游的更好选择！", sceneryinfo.SceneryName);
            SetPageSEO(seoTitle,seoKeyWords,seoDescriptions);
            var sceneryImgs = sceneryTicketBusiness.GetSceneryImgInfos(sceneryid);

            sceneryImgs.ForEach(u =>
            {
                u.ImgList = JsonConvert.DeserializeObject<List<SceneryImgSizeCode>>(u.SizeInfo);
            });

            sceneryinfo.ThemeName = sceneryTicketBusiness.GetSceneryThemeByThemeId(Convert.ToInt32(sceneryinfo.Themes));
            ViewBag.SceneryDetail = sceneryinfo;
            ViewBag.ImgGally = sceneryImgs;
            

            AddSceneryToCookie(sceneryinfo);
            List<SceneryPolicy> policies = new List<SceneryPolicy>();

            var prices = SceneryTicketServiceLogic.GetSceneryPrice(sceneryid).SceneryPrices;
            if(prices.Count>0)
            {
                policies = prices[0].Policies;
            }

            ViewData["TicketPrices"] = policies;

            var nearSceneryInfos = sceneryTicketBusiness.GetNearSceneryInfo(sceneryid);
            ViewData["NearSceneryInfos"] = nearSceneryInfos;

            var traffic = sceneryTicketBusiness.GetSceneryTrafficInfo(sceneryinfo);
            ViewData["TrafficInfo"] = traffic;

            var sceneryYouLike = sceneryTicketBusiness.GetSceneryInfoByCityId(sceneryinfo.CityID);
            ViewData["SceneryYouLike"] = sceneryYouLike;

            var hotelinfos = sceneryTicketBusiness.GetHotelInfoBySceneryName(sceneryinfo.CityName);
            ViewData["SceneryHotelInfos"] = hotelinfos;
            return View();
        }

        

        /// <summary>
        /// 景区信息查询
        /// </summary>
        /// <param name="provinceid">省份id</param>
        /// <param name="themeid">景区主题</param>
        /// <param name="star">景区星级</param>
        /// <param name="page">页码</param>
        /// <param name="keywords">景区名称或者省份</param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("ticketsearch")]
        public ActionResult Query(int provinceid = 0, int cityId = 0, int themeid = 0, int star = 0, int page = 1,int orderby=0, string keywords = "search")
        {

            // 301
            // Response.RedirectPermanent(string.Format("/hotelsearchlist_{0}.html",cityid));
            if(cityId>0)
            {
                Response.RedirectPermanent(string.Format("/ticketsearchlist_{0}.html", cityId));
            }
            if (provinceid > 0)
            {
                //ticketsearchlist_{cityid}.html
                //ticketsearchlist/province{provinceid}.html
                //ticketsearchlist/theme{themeid}.html
                //ticketsearchlist.html
                Response.RedirectPermanent(string.Format("/ticketsearchlist/province{0}.html", provinceid));
            }
            if(themeid>0)
            {
                Response.RedirectPermanent(string.Format("/ticketsearchlist/theme{0}.html", themeid));
            }
            Response.RedirectPermanent("/ticketsearchlist.html");

            SceneryQueryInfo queryInfo = new SceneryQueryInfo();
            queryInfo.PageIndex = page;
            queryInfo.PageSize = 10;
            queryInfo.ProvinceId = provinceid;
            queryInfo.ThemeId = themeid;
            queryInfo.KeyWord = keywords;
            queryInfo.CityID = cityId;
            queryInfo.Star = star;
            queryInfo.OrderBy = orderby;
            string titleKeyWords = "";
            if(cityId>0)
            {
                var cityInfo = sceneryTicketBusiness.GetSceneryProvincesAndCities().SingleOrDefault(u => u.ID == cityId);
                titleKeyWords = cityInfo.Name;
            }
            else if(provinceid>0)
            {
                var provinceInfo = sceneryTicketBusiness.GetSceneryProvinces().SingleOrDefault(u => u.ID == provinceid);
                titleKeyWords = provinceInfo.Name;
            }
            if(string.IsNullOrEmpty(titleKeyWords)&&keywords=="search")
            {
                titleKeyWords = "";
            }
            string seoTitle = string.Format("{0}景点订票_景点搜索_卓家客栈旅游", titleKeyWords);
            string seoKeyWords = "全国景点门票预订，全国旅游景点大全";
            string seoDescriptions = string.Format("卓家客栈旅游为您提供全国景点门票预订，全国旅游景点大全，让您享受实实在在的门票优惠，卓家客栈旅游景点门票频道是您预订景点门票，快乐出游的最佳选择！");
            SetPageSEO(seoTitle, seoKeyWords, seoDescriptions);

            var sceneryinfos = sceneryTicketBusiness.SceneryInfoQuery(queryInfo);
            queryInfo.TotalRecords = sceneryinfos.Item3;
            ViewData["SceneryQuery"] = queryInfo;
            ViewBag.SceneryInfos = sceneryinfos;

            var hotelinfos = sceneryTicketBusiness.GetHotelInfoBySceneryName("济南");
            ViewData["LocalHotelInfos"] = hotelinfos;

            var localSceneryInfos = sceneryTicketBusiness.GetSceneryInfoByCityName("济南");
            ViewData["LocalSceneryInfos"] = localSceneryInfos;

            ViewBag.Provinces = sceneryTicketBusiness.GetSceneryProvinces();
            ViewBag.SceneryThemes = sceneryTicketBusiness.GetSceneryThemes();

            ViewBag.CityInfos = sceneryTicketBusiness.GetSceneryCityInfoByProvinceId(provinceid);

            return View(GetView("Query"), queryInfo);
        }

       

        /// <summary>
        /// 下单页面
        /// </summary>
        /// <param name="sceneryid">景区id</param>
        /// <param name="policyID">景区价格策略</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Order(int sceneryid = 0, int policyID = 0)
        {
            var sceneryPrices = SceneryTicketServiceLogic.GetSceneryPrice(sceneryid).SceneryPrices[0].Policies;
            var ticketInfo = sceneryPrices.SingleOrDefault(u => u.PolicyId == policyID);

            DateTime startTime = DateTime.Now;
            DateTime endTime = ticketInfo.eDate;

            ViewBag.StartDate = startTime.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endTime.ToString("yyyy-MM-dd");

            int days = (int)(endTime - startTime).TotalDays;
            List<string> prices = new List<string>();
            for (int i = 0; i < days; i++)
            {
                startTime = startTime.AddDays(1);
                prices.Add(string.Format("{0}|{1}", startTime.ToString("yyyy-MM-dd"), ticketInfo.tcPrice));
            }

            string priceCollection = prices.Join(",");
            ViewBag.PriceCollection = priceCollection;

            var sceneryInfo = sceneryTicketBusiness.GetSceneryInfoByID(sceneryid);
            ViewBag.SceneryInfo = sceneryInfo;

            SetPageSEO(string.Format("{0}门票预定", sceneryInfo.SceneryName));
            return View(ticketInfo);
        }

        /// <summary>
        /// 景区门票下单
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <param name="policyid"></param>
        /// <param name="orderdate"></param>
        /// <param name="ticketcount"></param>
        /// <param name="linkman"></param>
        /// <param name="linktel"></param>
        /// <param name="orderremark"></param>
        /// <returns></returns>
        [HttpPost]
        public void Order(int sceneryId, int policyid, string orderdate, int ticketcount, string linkman, string linktel, string orderremark, int total_price = 0)
        {
            var sceneryInfo = sceneryTicketBusiness.GetSceneryInfoByID(sceneryId);
            SetPageSEO(string.Format("{0}门票预定", sceneryInfo.SceneryName));
            var bookResult = sceneryTicketBusiness.SceneryOrder(sceneryId, policyid, ticketcount, orderdate.ToDateTime(), linkman.GetSafeHtmlInput(), linktel.GetSafeHtmlInput(), orderremark.GetSafeHtmlInput(), total_price, sceneryInfo.SceneryName);
            TempData["SceneryTicketBookResult"] = bookResult;
            //return ref("ticketorder.html");
            //Redirect("ticketorder.html");
            Response.Redirect("/ticketorder.html");
        }

        /// <summary>
        /// 景区门票下单结果
        /// </summary>
        /// <returns></returns>
        //[ActionName("ticketorder")]
        public ActionResult OrderResult()
        {
            SceneryTicketBookResult bookResult = TempData["SceneryTicketBookResult"] as SceneryTicketBookResult;
            if (bookResult != null && bookResult.Success)
            {
                bookResult.OrderInfo = sceneryTicketBusiness.GetSceneryRicketOrderByOrderNo(bookResult.OrderNo);
                var sceneryInfo = sceneryTicketBusiness.GetSceneryInfoByID(bookResult.OrderInfo.SceneryID);
                bookResult.SceneryInfo = sceneryInfo;
                SetPageSEO("门票预定成功");
            }
            else
            {
                SetPageSEO("门票预定失败");
            }
            TempData["SceneryTicketBookResult"] = bookResult;
            return View("~/Areas/Travel/Views/JingDian/OrderResult.cshtml", bookResult);
        }

        /// <summary>
        /// 景区地图
        /// </summary>
        /// <param name="sceneryid"></param>
        /// <returns></returns>
        public ActionResult SceneryMap(int sceneryid)
        {
            var sceneryinfo = sceneryTicketBusiness.GetSceneryInfoByID(sceneryid);
            return View(GetView("SceneryMap"), sceneryinfo);
        }

        /// <summary>
        /// 热门景区主题
        /// </summary>
        /// <returns></returns>
        public PartialViewResult HotTheme()
        {
            return PartialView(GetView("HotTheme"));
        }

        /// <summary>
        /// 热门旅游城市
        /// </summary>
        /// <returns></returns>
        public PartialViewResult HotTravelCity()
        {
            return PartialView(GetView("HotTravelCity"));
        }

        public PartialViewResult HotSceneries()
        {
            var items = sceneryTicketBusiness.HotSceneryForProvincesByGrade();
            return PartialView(GetView("HotSceneries"), items);
        }

        [HttpGet]
        public ActionResult TicketSearchList(int cityId)
        {
            SceneryQueryInfo queryInfo = new SceneryQueryInfo();
            queryInfo.PageIndex = 1;
            queryInfo.PageSize = 10;
            queryInfo.ProvinceId = 0;
            queryInfo.ThemeId = 0;
            queryInfo.KeyWord = "";
            queryInfo.CityID = cityId;
            queryInfo.Star = 0;
            queryInfo.OrderBy = 0;
            string titleKeyWords = "";
            var cityInfo = sceneryTicketBusiness.GetSceneryProvincesAndCities().SingleOrDefault(u => u.ID == cityId);
            titleKeyWords = cityInfo.Name;

            string seoTitle = string.Format("{0}景点订票_景点搜索_卓家客栈旅游", titleKeyWords);
            string seoKeyWords = string.Format("{0}景点门票预订，{0}旅游景点大全", cityInfo.Name);
            string seoDescriptions = string.Format("卓家客栈旅游为您提供{0}景点门票预订，{0}旅游景点大全，让您享受实实在在的门票优惠，卓家客栈旅游景点门票频道是您预订景点门票，快乐出游的最佳选择！", cityInfo.Name);
            SetPageSEO(seoTitle, seoKeyWords, seoDescriptions);

            var sceneryinfos = sceneryTicketBusiness.SceneryInfoQuery(queryInfo);
            queryInfo.TotalRecords = sceneryinfos.Item3;
            ViewData["SceneryQuery"] = queryInfo;
            ViewBag.SceneryInfos = sceneryinfos;

            var hotelinfos = sceneryTicketBusiness.GetHotelInfoBySceneryName("济南");
            ViewData["LocalHotelInfos"] = hotelinfos;

            var localSceneryInfos = sceneryTicketBusiness.GetSceneryInfoByCityName("济南");
            ViewData["LocalSceneryInfos"] = localSceneryInfos;

            ViewBag.Provinces = sceneryTicketBusiness.GetSceneryProvinces();
            ViewBag.SceneryThemes = sceneryTicketBusiness.GetSceneryThemes();

            ViewBag.CityInfos = sceneryTicketBusiness.GetSceneryCityInfoByProvinceId(cityInfo.ParentID);
            if (string.IsNullOrEmpty(queryInfo.KeyWord))
            {
                queryInfo.KeyWord = "search";
            }
            return View(GetView("TicketSearchList"), queryInfo);
        }

        [HttpGet]
        public ActionResult TicketSearchList2(string keywords,int themeid=0)
        {
            ViewBag.KeyWords = keywords;
            SceneryQueryInfo queryInfo = new SceneryQueryInfo();
            queryInfo.PageIndex = 1;
            queryInfo.PageSize = 10;
            queryInfo.ProvinceId = 0;
            queryInfo.ThemeId = themeid;
            queryInfo.CityID = 0;
            queryInfo.Star = 0;
            queryInfo.OrderBy = 0;
            queryInfo.KeyWord = keywords;

            string seoTitle = string.Format("{0}景点订票_景点搜索_卓家客栈旅游", keywords);
            string seoKeyWords = string.Format("{0}景点门票预订，{0}旅游景点大全", keywords);
            string seoDescriptions = string.Format("卓家客栈旅游为您提供{0}景点门票预订，{0}旅游景点大全，让您享受实实在在的门票优惠，卓家客栈旅游景点门票频道是您预订景点门票，快乐出游的最佳选择！", keywords);
            SetPageSEO(seoTitle, seoKeyWords, seoDescriptions);

            var sceneryinfos = sceneryTicketBusiness.SceneryInfoQuery(queryInfo);
            queryInfo.TotalRecords = sceneryinfos.Item3;
            ViewData["SceneryQuery"] = queryInfo;
            ViewBag.SceneryInfos = sceneryinfos;

            var hotelinfos = sceneryTicketBusiness.GetHotelInfoBySceneryName("济南");
            ViewData["LocalHotelInfos"] = hotelinfos;

            var localSceneryInfos = sceneryTicketBusiness.GetSceneryInfoByCityName("济南");
            ViewData["LocalSceneryInfos"] = localSceneryInfos;

            ViewBag.Provinces = sceneryTicketBusiness.GetSceneryProvinces();
            ViewBag.SceneryThemes = sceneryTicketBusiness.GetSceneryThemes();

            if (string.IsNullOrEmpty(queryInfo.KeyWord))
            {
                queryInfo.KeyWord = "search";
            }
            return View(GetView("TicketSearchList"), queryInfo);
        }

        public ActionResult TicketSearchWithTheme(int themeid)
        {
            SceneryQueryInfo queryInfo = new SceneryQueryInfo();
            queryInfo.PageIndex = 1;
            queryInfo.PageSize = 10;
            queryInfo.ProvinceId = 0;
            queryInfo.ThemeId = themeid;
            queryInfo.CityID = 0;
            queryInfo.Star = 0;
            queryInfo.OrderBy = 0;
            queryInfo.KeyWord = "";

            var theme = sceneryTicketBusiness.GetSceneryThemeByThemeId(themeid);
            string themeName = !string.IsNullOrEmpty(theme) ? theme : "";

            string seoTitle = string.Format("{0}景点订票_景点搜索_卓家客栈旅游", themeName);
            string seoKeyWords = string.Format("{0}景点门票预订，{0}旅游景点大全", themeName);
            string seoDescriptions = string.Format("卓家客栈旅游为您提供{0}景点门票预订，{0}旅游景点大全，让您享受实实在在的门票优惠，卓家客栈旅游景点门票频道是您预订景点门票，快乐出游的最佳选择！", themeName);
            SetPageSEO(seoTitle, seoKeyWords, seoDescriptions);

            var sceneryinfos = sceneryTicketBusiness.SceneryInfoQuery(queryInfo);
            queryInfo.TotalRecords = sceneryinfos.Item3;
            ViewData["SceneryQuery"] = queryInfo;
            ViewBag.SceneryInfos = sceneryinfos;

            var hotelinfos = sceneryTicketBusiness.GetHotelInfoBySceneryName("济南");
            ViewData["LocalHotelInfos"] = hotelinfos;

            var localSceneryInfos = sceneryTicketBusiness.GetSceneryInfoByCityName("济南");
            ViewData["LocalSceneryInfos"] = localSceneryInfos;

            ViewBag.Provinces = sceneryTicketBusiness.GetSceneryProvinces();
            ViewBag.SceneryThemes = sceneryTicketBusiness.GetSceneryThemes();

            return View(GetView("TicketSearchList"), queryInfo);
        }

        public ActionResult TicketSearchWithProvince(int provinceId)
        {
            SceneryQueryInfo queryInfo = new SceneryQueryInfo();
            queryInfo.PageIndex = 1;
            queryInfo.PageSize = 10;
            queryInfo.ProvinceId = provinceId;
            queryInfo.ThemeId = 0;
            queryInfo.CityID = 0;
            queryInfo.Star = 0;
            queryInfo.OrderBy = 0;
            queryInfo.KeyWord = "";

            var provinceinfo = sceneryTicketBusiness.GetSceneryProvinceInfoByProvinceID(provinceId);
            string provinceName = provinceinfo != null ? provinceinfo.Name : "";

            string seoTitle = string.Format("{0}景点订票_景点搜索_卓家客栈旅游", provinceName);
            string seoKeyWords = string.Format("{0}景点门票预订，{0}旅游景点大全", provinceName);
            string seoDescriptions = string.Format("卓家客栈旅游为您提供{0}景点门票预订，{0}旅游景点大全，让您享受实实在在的门票优惠，卓家客栈旅游景点门票频道是您预订景点门票，快乐出游的最佳选择！", provinceName);
            SetPageSEO(seoTitle, seoKeyWords, seoDescriptions);

            var sceneryinfos = sceneryTicketBusiness.SceneryInfoQuery(queryInfo);
            queryInfo.TotalRecords = sceneryinfos.Item3;
            ViewData["SceneryQuery"] = queryInfo;
            ViewBag.SceneryInfos = sceneryinfos;

            var hotelinfos = sceneryTicketBusiness.GetHotelInfoBySceneryName("济南");
            ViewData["LocalHotelInfos"] = hotelinfos;

            var localSceneryInfos = sceneryTicketBusiness.GetSceneryInfoByCityName("济南");
            ViewData["LocalSceneryInfos"] = localSceneryInfos;

            ViewBag.Provinces = sceneryTicketBusiness.GetSceneryProvinces();
            ViewBag.SceneryThemes = sceneryTicketBusiness.GetSceneryThemes();
            ViewBag.CityInfos = sceneryTicketBusiness.GetSceneryCityInfoByProvinceId(provinceId);
            return View(GetView("TicketSearchList"), queryInfo);
        }

        [HttpPost]
        public ActionResult TicketSearchListResult(int provinceid,int cityid=0,int themeid=0,int page=1,int orderby=0,int star=0,string searchkeywords="")
        {
            SceneryQueryInfo queryInfo = new SceneryQueryInfo();
            queryInfo.PageIndex = page;
            queryInfo.PageSize = 10;
            queryInfo.ProvinceId = provinceid;
            queryInfo.ThemeId = themeid;
            queryInfo.KeyWord = searchkeywords;
            queryInfo.CityID = cityid;
            queryInfo.Star = star;
            queryInfo.OrderBy = orderby;

            var sceneryinfos = sceneryTicketBusiness.SceneryInfoQuery(queryInfo);
            queryInfo.TotalRecords = sceneryinfos.Item3;
            ViewData["SceneryQuery"] = queryInfo;
            ViewBag.SceneryInfos = sceneryinfos;

            return View(GetView("TicketSearchListResult"), queryInfo);
        }

        [HttpGet]
        public ActionResult GetCityInfoList(int provinceid)
        {
            var cityinfoList = sceneryTicketBusiness.GetSceneryCityInfoByProvinceId(provinceid);
            return View(GetView("CityInfoList"), cityinfoList);
        }
    }
}