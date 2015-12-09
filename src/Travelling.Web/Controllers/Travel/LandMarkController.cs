using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.ViewModel.Dto.Ticket;
using Travelling.ViewModel.Travel;

namespace Travelling.Web.Controllers.Travel
{
    public class LandMarkController:BaseController
    {
        private readonly IHotelCityBusinessLogic hotelCityBusinessLogic;
        private readonly IHotelInfoBusinessLogic hotelInfoBusinessLogic;
        private readonly ISceneryTicketInfoBusinessLogic ticketInfoBusinessLogic;
        private readonly IZhunaHotelBusinessLogic zhuanHotelBusinessLogic;
        private string GetView(string viewName)
        {
            return string.Format("~/Areas/Travel/Views/LandMark/{0}.cshtml", viewName);
        }

        public LandMarkController(IHotelCityBusinessLogic hotelCityLogic,IHotelInfoBusinessLogic hotelinfoLogic,ISceneryTicketInfoBusinessLogic ticketLogic,IZhunaHotelBusinessLogic zhunaHotelLogic)
        {
            this.hotelCityBusinessLogic = hotelCityLogic;
            this.hotelInfoBusinessLogic = hotelinfoLogic;
            this.ticketInfoBusinessLogic = ticketLogic;
            this.zhuanHotelBusinessLogic = zhunaHotelLogic;
        }

        [OutputCache(Duration = 3600)]
        public ActionResult Index()
        {
            var provinces = hotelCityBusinessLogic.GetHotelProvinces();
            var cityinfos = hotelCityBusinessLogic.HotelCityDetailInfosGet();
            var cityinfoData = Tuple.Create<List<HotelProvinceInfo>, List<HotelCityDetailInfo>>(provinces, cityinfos);
            string title = "城市酒店预定";
            string description = "国内城市地标景点信息，周边景点门票，酒店预定";
            string keywords = "景点门票，城市景点，城市地标，酒店预定";
            SetPageSEO(title,keywords,description);
            return View(GetView("Index"), cityinfoData);
        }

        [OutputCache(Duration = 36000)]
        public ActionResult CityInfo(int cityId)
        {
            var cityinfo = hotelCityBusinessLogic.HotelCityDetailInfoGetByCityID(cityId);

            string title = string.Format("{0}地标，{0}行政区域，{0}酒店预定",cityinfo.CityName);
            string description = string.Format("{0}地标，{0}行政区域，{0}酒店预定", cityinfo.CityName);
            string keywords = string.Format("{0}地标，{0}行政区域，{0}酒店预定", cityinfo.CityName);
            SetPageSEO(title,keywords,description);

            var locationInfos = hotelCityBusinessLogic.HotelLocationGetByCityId(cityId);
            ViewBag.Locations = locationInfos;
            var areainfos = hotelInfoBusinessLogic.GetCityAreaInfoByCityId(cityId);
            ViewBag.AreaInfos = areainfos;

            var sceneryInfos = ticketInfoBusinessLogic.GetSceneryInfoByHotelCityName(cityinfo.CityName);
            ViewBag.SceneryInfos = sceneryInfos;

            var hotelinfos = hotelInfoBusinessLogic.HotelDescriptionGetByCityId(cityinfo.CityID);
            ViewBag.HotelInfos = hotelinfos;

            var cbds = zhuanHotelBusinessLogic.HotCityTradeAreaGet().Where(u => u.CityId == cityId).ToList();
            if(cbds==null)
            {
                cbds = new List<TradeAreaInfo>();
            }
            ViewBag.CBDList = cbds;
            var schools = zhuanHotelBusinessLogic.SchoolSummaryInfos().Item1.Where(u => u.CityId == cityId).ToList();
            if(schools==null)
            {
                schools = new List<SchoolSummaryInfo>();
            }
            ViewBag.Schools = schools;

            
            return View(GetView("CityInfo"), cityinfo);
        }


        [OutputCache(Duration = 36000)]
        public ActionResult HotelCityList()
        {
            var provinces = hotelCityBusinessLogic.GetHotelProvinces();
            var cityinfos = hotelCityBusinessLogic.HotelCityDetailInfosGet();
            var cityinfoData = Tuple.Create<List<HotelProvinceInfo>, List<HotelCityDetailInfo>>(provinces, cityinfos);
            string title = "国内城市酒店预定查询_卓家客栈";
            string description = "酒店预定，酒店查询，酒店在线预定";
            string keywords = "国内城市酒店查询，酒店预定,卓家客栈酒店预定";
            SetPageSEO(title, keywords, description);
            
            return View(GetView("HotelCityList"), cityinfoData);
        }

        public ActionResult SceneryCityList()
        {
            string title = "国内城市景点门票_卓家客栈";
            string keywords = "景点门票，在线预定，景点大全";
            string descriptions = "卓家客栈提供国内景点门票预定、查询、地址、客户点评信息，无需在线付款，景区到付，让你安全放心的旅游。";
            SetPageSEO(title,keywords,descriptions);
            var items = ticketInfoBusinessLogic.GetSceneryProvincesAndCities();
            var provinces = items.Where(u => u.ParentID == 0).ToList();
            var citylist = items.Where(u => u.ParentID > 0).ToList();
            var provinceData = new Tuple<List<SceneryProvinceDetailInfo>, List<SceneryProvinceDetailInfo>>(provinces, citylist);
            return View(GetView("SceneryCityList"), provinceData);
        }

        [OutputCache(Duration = 36000)]
        public ActionResult Schools()
        {
            string title = "国内学校、大学周边酒店预定_卓家客栈";
            string keywords = "酒店预定，大学，学院，学校";
            string descriptions = "国内学校、大学周边酒店预定_卓家客栈";
            SetPageSEO(title,keywords,descriptions);
            var schools = zhuanHotelBusinessLogic.SchoolSummaryInfos();
            return View(GetView("Schools"), schools);
        }

        [OutputCache(Duration = 36000)]
        public ActionResult SchoolsInCity(int cityid)
        {
            var schools = zhuanHotelBusinessLogic.SchoolSummaryInfos().Item1.Where(u => u.CityId == cityid).ToList();
            var cityName = schools[0].CityName;

            string title = string.Format("{0}大学酒店预定，{0}学校酒店预定",cityName);
            string keywords = string.Format("{0}大学酒店预定，{0}学校酒店预定",cityName);
            string descriptions = string.Format("{0}大学酒店预定，{0}学校酒店预定",cityName);
            SetPageSEO(title, keywords, descriptions);
            var data = new Tuple<string, List<SchoolSummaryInfo>>(cityName,schools);
            return View(GetView("SchoolsInCity"),data);
        }
    }
}
