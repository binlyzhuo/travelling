using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Dto.Hotel;

namespace Travelling.Web.Controllers.Travel
{
    /// <summary>
    /// 酒店品牌修改
    /// </summary>
    public class PinPaiController : BaseController
    {
        private readonly IHotelInfoBusinessLogic hotelInfoBusinessLogic;
        private readonly IHotelCityBusinessLogic hotelCityBusinessLogic;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hotelinfoLogic"></param>
        /// <param name="hotelCityLogic"></param>
        public PinPaiController(IHotelInfoBusinessLogic hotelinfoLogic,IHotelCityBusinessLogic hotelCityLogic)
        {
            this.hotelInfoBusinessLogic = hotelinfoLogic;
            this.hotelCityBusinessLogic = hotelCityLogic;
        }

        private string GetView(string viewName)
        {
            
            return string.Format("~/Areas/Travel/Views/PinPai/{0}.cshtml", viewName);
        }


        /// <summary>
        /// 酒店品牌首页
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 3600)]
        public ActionResult Index()
        {
            string title = "连锁酒店预订_经济型连锁酒店_星级品牌酒店_卓家客栈旅游预订平台";
            string description = "连锁酒店预订，卓家客栈为您提供100个城市、100个品牌、2000多家连锁酒店的在线预订服务，包括如家快捷酒店、7天连锁酒店、锦江之星、汉庭酒店连锁、莫泰168、格林豪泰等知名品牌。";
            string keywords = "连锁酒店预订,经济型连锁酒店,星级品牌酒店,连锁品牌";
            SetPageSEO(title,keywords,description);
            var hotelBrands = hotelInfoBusinessLogic.HotelBrandDetailInfoGet();
            var hotelBrandsGroups = Tuple.Create<IEnumerable<HotelBrandDetailInfo>, IEnumerable<HotelBrandDetailInfo>>(hotelBrands.Where(u => u.Type == 0), hotelBrands.Where(u => u.Type == 1));
            ViewBag.HotelViewed = GetHotelViewed();
            var hotHotelCities = hotelCityBusinessLogic.HotelCityDetailInfosGet().Where(u => u.IsHotCity == 1).ToList();
            ViewData["HotHotelCities"] = hotHotelCities;
            return View(GetView("Index"), hotelBrandsGroups);
        }

        /// <summary>
        /// 查看品牌详情
        /// </summary>
        /// <param name="brandid"></param>
        /// <returns></returns>
        public ActionResult HotelBrandDetail(int brandid)
        {
            var brandDetail = hotelInfoBusinessLogic.HotelBrandDetailInfoGet().SingleOrDefault(u => u.BrandID == brandid);
            string title = string.Format("{0}酒店-{0}酒店预订-卓家客栈酒店预定", brandDetail.BrandName);
            string descriptions = string.Format("{0}酒店-{0}酒店预订",brandDetail.BrandName);
            string keywords = string.Format("{0}酒店专业的连锁酒店品牌{0}酒店全国各城市分店的信息查询及预订服务,{0}酒店的热门推荐让您更加清晰，订{0}酒店,预定电话:{1}",brandDetail.BrandName,brandDetail.BrandTel);
            SetPageSEO(title, keywords, descriptions);
            var brandSummaryInfo = hotelInfoBusinessLogic.HotelBrandSummaryInfos().Where(u => u.BrandID == brandid).ToList().OrderBy(u=>u.OrderFlag).ToList();
            ViewBag.HotelBrandSummaryInfos = brandSummaryInfo;
            var hotHotelCities = hotelCityBusinessLogic.HotelCityDetailInfosGet().Where(u => u.IsHotCity == 1).ToList();
            ViewData["HotHotelCities"] = hotHotelCities;
            
            return View(GetView("HotelBrandDetail"), brandDetail);
        }

        /// <summary>
        /// 根据城市查询酒店品牌信息
        /// </summary>
        /// <param name="brandid"></param>
        /// <returns></returns>
        public ActionResult HotelBrandCity(int brandid)
        {
            var brandDetail = hotelInfoBusinessLogic.HotelBrandDetailInfoGet().SingleOrDefault(u => u.BrandID == brandid);
            string title = string.Format("{0}酒店-{0}酒店预订-卓家客栈酒店预定", brandDetail.BrandName);
            string descriptions = string.Format("{0}酒店-{0}酒店预订", brandDetail.BrandName);
            string keywords = string.Format("{0}酒店专业的连锁酒店品牌{0}酒店全国各城市分店的信息查询及预订服务,{0}酒店的热门推荐让您更加清晰，订{0}酒店,预定电话:{1}", brandDetail.BrandName, brandDetail.BrandTel);

            SetPageSEO(title,keywords,descriptions);

            var hotHotelCities = hotelCityBusinessLogic.HotelCityDetailInfosGet().Where(u => u.IsHotCity == 1).ToList();
            ViewData["HotHotelCities"] = hotHotelCities;
            var hotelCitySummaryInfos = hotelInfoBusinessLogic.HotelCitySummaryInfos().Where(u=>u.BrandCode==brandid).ToList();
            ViewBag.HotelCitySummaryInfos = hotelCitySummaryInfos;
            return View(GetView("HotelBrandCity"), brandDetail);
        }

        [HttpGet]
        public ActionResult BrandInCity(int cityid,int brandid)
        {
            return View();
        }

        public ActionResult SevenDays()
        {
            int brandid = 1;
            return View(GetView("SevenDays"));
        }
    }
}
