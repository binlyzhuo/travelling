using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Travelling.OpenApiEntity.Ctrip.Tuan;
using Travelling.OpenApiLogic;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Travel;
using Travelling.Web.Helpers;
using Travelling.Web.XmlData;

namespace Travelling.Web.Controllers.Travel
{
    public class TuanController:BaseController
    {
        private readonly IHotelCityBusinessLogic hotelCityBusinessLogic;

        public TuanController(IHotelCityBusinessLogic cityLogic)
        {
            this.hotelCityBusinessLogic = cityLogic;
        }

        private string GetView(string viewName)
        {
            return string.Format("~/Areas/Travel/Views/Tuan/{0}.cshtml", viewName);
        }

        [OutputCache(Duration = 3600)]
        public ActionResult Index()
        {

            JsonLocalIPInfo localInfo = ApplicationSetting.GetLocalInfo();

            var locationCity = hotelCityBusinessLogic.HotelCityDetailInfosGet().Where(u => u.CityName.Contains(localInfo.data.city) || localInfo.data.city.Contains(u.CityName)).ToList();

            if (locationCity != null && locationCity.Count > 0)
            {

                ViewBag.CityId = locationCity[0].CityID;

                ViewBag.CityName = locationCity[0].CityName;

            }

            else
            {

                ViewBag.CityId = 1;

                ViewBag.CityName = "北京";

            }


            

            var cityInfo = hotelCityBusinessLogic.HotelCityDetailInfoGetByCityID(ViewBag.CityId);
            string description = string.Format("{0}团购网,卓家客栈团购提供{0}团购导航,让你快速选择{0}酒店团购众多打折促销团购产品,使您团购更放心！", cityInfo.CityName);
            string keyWords = string.Format("{0}团购,{0}团购网站大全,{0}团购导航,{0}酒店团购", cityInfo.CityName);

            SetPageSEO(string.Format("{0}酒店团购", cityInfo.CityName), keyWords, description);

            Product_GetCallEntity tuanCall = new Product_GetCallEntity() { CityID = ViewBag.CityId };
            var rep = OTATuanServiceLogic.Product_Get(tuanCall);
            var hotHotelCities = hotelCityBusinessLogic.HotelCityDetailInfosGet().Where(u => u.IsHotCity == 1).ToList();
            ViewData["HotHotelCities"] = hotHotelCities;
            
            return View(GetView("Index"), rep.GroupProductInfoList);
        }

        public PartialViewResult TuanCityList()
        {
            var cityinfos=XmlDataSource.HotelGroupCityInfosGet();
            //var hotCities = hotelCityBusinessLogic.HotelCityDetailInfosGet().Where(u => u.IsHotCity == 1).ToList();
            return PartialView(GetView("TuanCityList"), cityinfos);
        }

        [HttpGet]
        public ActionResult TuanCity(int cityId)
        {
            GroupProductListCallEntity callEntity = new GroupProductListCallEntity();
            callEntity.CityId = cityId;
            var cityInfo = hotelCityBusinessLogic.HotelCityDetailInfoGetByCityID(cityId);
            string description = string.Format("{0}团购网,卓家客栈团购提供{0}团购导航,让你快速选择{0}酒店团购众多打折促销团购产品,使您团购更放心！",cityInfo.CityName);
            string keyWords = string.Format("{0}团购,{0}团购网站大全,{0}团购导航,{0}酒店团购", cityInfo.CityName);

            SetPageSEO(string.Format("{0}酒店团购", cityInfo.CityName), keyWords, description);
            Product_GetCallEntity tuanCall = new Product_GetCallEntity();
            tuanCall.CityID = cityId;

            var rep = OTATuanServiceLogic.Product_Get(tuanCall);
            ViewBag.CityId = cityId;
            ViewBag.CityName = hotelCityBusinessLogic.HotelCityDetailInfosGet().SingleOrDefault(u => u.CityID == cityId).CityName;

            return View(GetView("Index"), rep.GroupProductInfoList);
        }

        [HttpPost]
        public ActionResult TuanCity2(int cityId)
        {
            GroupProductListCallEntity callEntity = new GroupProductListCallEntity();
            callEntity.CityId = cityId;
            var cityInfo = hotelCityBusinessLogic.HotelCityDetailInfoGetByCityID(cityId);

            string description = string.Format("{0}团购网,卓家客栈团购提供{0}团购导航,让你快速选择{0}酒店团购众多打折促销团购产品,使您团购更放心！", cityInfo.CityName);
            string keyWords = string.Format("{0}团购,{0}团购网站大全,{0}团购导航,{0}酒店团购", cityInfo.CityName);

            SetPageSEO(string.Format("{0}酒店团购", cityInfo.CityName), keyWords, description);

            Product_GetCallEntity tuanCall = new Product_GetCallEntity();
            tuanCall.CityID = cityId;

            var rep = OTATuanServiceLogic.Product_Get(tuanCall);
            ViewBag.CityId = cityId;
            ViewBag.CityName = hotelCityBusinessLogic.HotelCityDetailInfosGet().SingleOrDefault(u => u.CityID == cityId).CityName;

            return View(GetView("Index"), rep.GroupProductInfoList);
        }
        
    }
}
