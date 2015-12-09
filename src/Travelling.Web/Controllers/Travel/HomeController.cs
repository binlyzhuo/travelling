using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.ViewModel.Dto.Zhuna;
using Travelling.ViewModel.Hotel;
using Travelling.ViewModel.Travel;
using Travelling.Web.Helpers;
using Travelling.Web.XmlData;

namespace Travelling.Web.Controllers.Travel
{
    /// <summary>
    /// HomeController
    /// </summary>
    public class HomeController : BaseController
    {
        private readonly IHotelInfoBusinessLogic hotelInfoBusinessLogic;
        private readonly IHotelCityBusinessLogic cityBusinessLogic;
        private readonly ISceneryTicketInfoBusinessLogic sceneryTicketBusinessLogic;
        private readonly ISettingBusinessLogic settingBusinessLogic;
        private readonly IZhunaHotelBusinessLogic zhunaHotelBusinessLogic;

        private readonly string HotCityInfos;

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="rep"></param>
        /// <param name="repAccount"></param>
        public HomeController(IHotelInfoBusinessLogic hotelInfoBusiness, ISceneryTicketInfoBusinessLogic sceneryTicketBusiness, ISettingBusinessLogic settingBusiness,IHotelCityBusinessLogic cityLogic,IZhunaHotelBusinessLogic zhuanHotelLogic)
        {
            //GetTopMenus(TopMenuSetting.Home);

            hotelInfoBusinessLogic = hotelInfoBusiness;
            sceneryTicketBusinessLogic = sceneryTicketBusiness;
            settingBusinessLogic = settingBusiness;
            cityBusinessLogic = cityLogic;
            zhunaHotelBusinessLogic = zhuanHotelLogic;
            HotCityInfos = hotelInfoBusinessLogic.HotelCityDetailInfoGetJsonData();
        }

        /// <summary>
        /// 获取view路径
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        private string GetView(string viewName)
        {
            return string.Format("~/Areas/Travel/Views/Home/{0}.cshtml",viewName);
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration=3600)]
        public ActionResult Index()
        {
            string title = "卓家客栈-酒店预订，景点门票，特价酒店，特价门票，古镇客栈，7天连锁酒店，如家连锁酒店。";
            string keywords = "酒店预订，景点门票，自助游，卓家客栈，古镇客栈，7天连锁酒店，7天酒店官网，如家连锁酒店，如家酒店官网，汉庭连锁酒店，汉庭连锁酒店官网，格林豪泰连锁酒店，锦江之星连锁酒店";
            string descriptions = "卓家客栈是专业旅游预订平台，提供特惠酒店、连锁酒店、星级酒店、古镇客栈、景点门票预订服务；专业服务、品质保障，让您的旅行更安心。";
            SetPageSEO(title, keywords, descriptions);
            var hotHotelCities = cityBusinessLogic.HotelCityDetailInfosGet().Where(u => u.IsHotCity == 1).ToList();
            
            ViewData["HotHotelCities"] = hotHotelCities;

            
            return View("~/Areas/Travel/Views/Home/Index.cshtml");
        }

        /// <summary>
        /// 热门酒店
        /// </summary>
        /// <returns></returns>
        public ActionResult HotHotels()
        {
            var hotHotels = hotelInfoBusinessLogic.GetHotCityHotelInfos();
            return PartialView("~/Areas/Travel/Views/Home/HotHotels.cshtml", hotHotels);
        }

        /// <summary>
        /// 推荐酒店
        /// </summary>
        /// <returns></returns>
        public ActionResult RecommendHotels()
        {
            var hotHotels = hotelInfoBusinessLogic.GetChoiceCityHotelInfos();
            return PartialView("~/Areas/Travel/Views/Home/RecommendHotels.cshtml", hotHotels);
        }

        /// <summary>
        /// 导航
        /// </summary>
        /// <returns></returns>
        public ActionResult TopNavigate()
        {
            return PartialView("~/Areas/Travel/Views/Shared/_TopNavigate.cshtml");
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult TopSearch()
        {
            ViewBag.HotCities = HotCityInfos;
            return PartialView("~/Areas/Travel/Views/Shared/_TopSearch.cshtml");
        }

        /// <summary>
        /// 导航菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult TopMenu()
        {
            return PartialView("~/Areas/Travel/Views/Shared/_TopMenu.cshtml");
        }

        /// <summary>
        /// 底部导航
        /// </summary>
        /// <returns></returns>
        public ActionResult FooterNavigate()
        {
            return PartialView("~/Areas/Travel/Views/Shared/_FooterNavigate.cshtml");
        }

        /// <summary>
        /// 帮助
        /// </summary>
        /// <returns></returns>
        public ActionResult FooterHelper()
        {
            return PartialView("~/Areas/Travel/Views/Shared/_FooterHelper.cshtml");
        }

        /// <summary>
        /// 友情链接
        /// </summary>
        /// <returns></returns>
        public ActionResult FriendLinks()
        {
            var friendLinks = settingBusinessLogic.FriendLinks();
            return PartialView("~/Areas/Travel/Views/Shared/_FriendLinks.cshtml", friendLinks);
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return PartialView("~/Areas/Travel/Views/Shared/_About.cshtml");
        }

        /// <summary>
        /// 主框架
        /// </summary>
        /// <returns></returns>
        public PartialViewResult MainContent()
        {
            return PartialView(GetView("MainContent"));
        }

        /// <summary>
        /// 页面查询
        /// </summary>
        /// <returns></returns>
        public ActionResult Search()
        {
            return View();
        }

        
        public ActionResult HotProvinceSceneries()
        {
            var items = sceneryTicketBusinessLogic.HotSceneryForProvinces();
            return PartialView("~/Areas/Travel/Views/Home/HotProvinceSceneries.cshtml", items);
        }

        /// <summary>
        /// 获取附近城市景区信息
        /// </summary>
        /// <returns></returns>
        public ActionResult NearSceneies()
        {
            JsonLocalIPInfo localInfo = ApplicationSetting.GetLocalInfo();
           
            // 春节快乐

            var cityInfo = sceneryTicketBusinessLogic.GetSceneryProvincesAndCities().Where(u => u.ParentID > 0).ToList().Where(u =>
            {
                return localInfo.data.city.IndexOf(u.Name) > -1;
            }).SingleOrDefault();

            
            var sceneryAndCityinfos = sceneryTicketBusinessLogic.GetSceneryInfoByProvinceId(cityInfo.ParentID);

            return PartialView("~/Areas/Travel/Views/Home/NearSceneies.cshtml", sceneryAndCityinfos);
        }

        /// <summary>
        /// 酒店品牌列表信息
        /// </summary>
        /// <returns></returns>
        public PartialViewResult HotelBrands()
        {
            var hotelBrands = hotelInfoBusinessLogic.HotelBrandDetailInfoGet();
            return PartialView(GetView("HotelBrands"), hotelBrands);
        }

        public ActionResult HotSceneryCities()
        {
            var hotCities = sceneryTicketBusinessLogic.GetHotSceneryCities();
            return PartialView("~/Areas/Travel/Views/Home/HotSceneryCities.cshtml", hotCities);
        }

        /// <summary>
        /// 景区主题
        /// </summary>
        /// <returns></returns>
        public ActionResult SceneryThemes()
        {
            var items = sceneryTicketBusinessLogic.GetSceneryThemes();
            return PartialView("~/Areas/Travel/Views/Home/SceneryThemes.cshtml", items);
        }

        /// <summary>
        /// 游客浏览记录
        /// </summary>
        /// <returns></returns>
        public ActionResult VisitedHistory()
        {
            var hotels = GetHotelViewed();
            var sceneries = GetSceneryViewed();
            var visited = Tuple.Create<Queue<HotelCookieView>, Queue<SceneryInfoCookie>>(hotels, sceneries);
            Response.ContentEncoding = Encoding.UTF8;
            return PartialView("~/Areas/Travel/Views/Home/VisitedHistory.cshtml", visited);
        }

        [HttpPost]
        public ActionResult CityAreaInfos(int cityId, int areaCode, int dataindex, int islocation)
        {
            HotelFindAreaViewResult areaViewResult = new HotelFindAreaViewResult();
            areaViewResult.CityId = cityId;
            if(islocation==0)
            {
                var areainfos = hotelInfoBusinessLogic.GetCityAreaInfo();
                var areas = areainfos.Where(u => u.CityID == cityId && u.TypeCode == areaCode).ToList();
               
                
                areaViewResult.AreaInfos = areas;
                
            }
            else
            {
                var locations = cityBusinessLogic.HotelLocationGet();
                var cityLocations = locations.Where(u => u.LocationCityID == cityId).ToList();
                areaViewResult.locations = cityLocations;
            }

            areaViewResult.AreaCode = areaCode;
            areaViewResult.IsLocation = islocation;
            areaViewResult.DataIndex = dataindex;
            return View("~/Areas/Travel/Views/Home/CityAreaInfos.cshtml", areaViewResult);
        }

        /// <summary>
        /// 网站查询框
        /// </summary>
        /// <returns></returns>
        public PartialViewResult SearchBox()
        {
            return PartialView(GetView("SearchBox"));
        }

        /// <summary>
        /// 酒店快速查找
        /// </summary>
        /// <returns></returns>
        public PartialViewResult HotelQuickFind()
        {
            var hotHotelCities = cityBusinessLogic.HotelCityDetailInfosGet().Where(u => u.IsHotCity == 1).ToList();
            return PartialView(GetView("HotelQuickFind"), hotHotelCities);
        }

        public PartialViewResult HotelQuickSearch()
        {
            return PartialView(GetView("HotelQuickSearch"));
        }

        public PartialViewResult CityRecommend()
        {
            var recommendCityAndBrands = hotelInfoBusinessLogic.HotelRecommendCityAndBrandInfos();
            return PartialView(GetView("CityRecommend"), recommendCityAndBrands);
        }

        public ActionResult GuZhen()
        {
            var cityinfos = XmlDataSource.GuZhenHotelCityInfoGet();
            return View(GetView("GuZhen"), cityinfos);
        }

        public ActionResult AdView()
        {
            return PartialView(GetView("AdView"));
        }

        public ActionResult NewsInfo()
        {
            ArticleInfoSearchModel search = new ArticleInfoSearchModel();
            var newsItems = settingBusinessLogic.ArticleInfoPageResult(search);
            return PartialView(GetView("NewsInfo"), newsItems.Items);
        }

        /// <summary>
        /// 城市商圈
        /// </summary>
        /// <returns></returns>
        public ActionResult TradeArea()
        {
            var tradeAreas = zhunaHotelBusinessLogic.HotCityTradeAreaGet();
            var hotcityinfos = cityBusinessLogic.HotelCityDetailInfosGet().Where(u => u.IsHotCity == 1).ToList();
            Tuple<List<TradeAreaInfo>, List<HotelCityDetailInfo>> data = new Tuple<List<TradeAreaInfo>, List<HotelCityDetailInfo>>(tradeAreas, hotcityinfos);
            return View(GetView("TradeArea"), data);
        }

        /// <summary>
        /// 获取推荐学校信息
        /// </summary>
        /// <returns></returns>
        public ActionResult SchoolHotels()
        {
            var schools=XmlDataSource.SchoolsGet();
            return View(GetView("SchoolHotels"), schools);
        }

        public ActionResult HotHotelBrandCityInfos()
        {
            var brands = XmlDataSource.HotBrandsGet();
            return View(GetView("HotHotelBrandCityInfos"), brands);
        }
    }
}