using System.Web.Mvc;
using Travelling.TravelInterface.Repository;

namespace Travelling.Web.Controllers.Travel
{
    /// <summary>
    /// ajax相关
    /// </summary>
    public class AjaxHelperController : BaseController
    {
        private readonly IHotelInfoBusinessLogic hotelInfoBusiness;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hotelBusiness"></param>
        public AjaxHelperController(IHotelInfoBusinessLogic hotelBusiness)
        {
            if (hotelInfoBusiness == null)
            {
                hotelInfoBusiness = hotelBusiness;
            }
        }

        /// <summary>
        /// 获取城市以及热门区域信息
        /// </summary>
        /// <param name="cityid"></param>
        /// <returns></returns>
        //[OutputCache()]
        public PartialViewResult CityAreaInfo(int cityid = 0)
        {
            //var areaInfos = hotelInfoBusiness.GetCityAreaSummaryInfo(cityid);
            var hotelBrands = hotelInfoBusiness.HotelBrandDetailInfoGet();
            var locations = hotelInfoBusiness.GetLocationInfoByCityID(cityid);
            ViewBag.HotelBrands = hotelBrands;
            ViewBag.Locations = locations;
            return PartialView();
        }
    }
}