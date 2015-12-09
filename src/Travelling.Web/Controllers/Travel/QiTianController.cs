using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using Travelling.OpenApiLogic;
using Travelling.FrameWork;
using Travelling.OpenApiEntity.Zhuna;
using Travelling.CommonLibrary;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Travel;

namespace Travelling.Web.Controllers.Travel
{
    public class QiTianController:BaseController
    {
        private string getView(string viewName)
        {
            return string.Format("~/Areas/Travel/Views/QiTian/{0}.cshtml", viewName);
        }

        public QiTianController()
        { }

        private readonly ISceneryTicketInfoBusinessLogic sceneryingoBusinessLogic;
        private readonly IZhunaHotelBusinessLogic zhunaHotelBusiness;

        public QiTianController(ISceneryTicketInfoBusinessLogic sceneryinfoLogic,IZhunaHotelBusinessLogic hotellogic)
        {
            this.sceneryingoBusinessLogic = sceneryinfoLogic;
            this.zhunaHotelBusiness = hotellogic;
        }

        [HttpGet]
        [OutputCache(Duration=6000)]
        public ActionResult HotelInfo(int hotelid = 0,string startDate="",string endDate="")
        {
            var repHotelInfo=ZhunaHotelServiceLogic.HotelInfoSearch(hotelid);
            var repHotelImg = ZhunaHotelServiceLogic.GetHotelPic(hotelid);
            ViewBag.HotelImgs = repHotelImg.reqdata;

            HotelCookieView cookieView = new HotelCookieView()
            {
                HotelId =repHotelInfo.reqdata.id,
                HotelName = repHotelInfo.reqdata.hotelname,
                Amount = repHotelInfo.reqdata.min_jiage,
                HotelIcon = repHotelInfo.reqdata.picture,
                HotelStar = repHotelInfo.reqdata.xingji,
                UnionId = 1
            };
            AddHotelToCookie(cookieView);

            var repRooms = ZhunaHotelServiceLogic.HotelRoomPlanSearch(hotelid, DateTime.Now, DateTime.Now.AddDays(1));
            ViewBag.RoomRates = repRooms;

            var nearHotels = ZhunaHotelServiceLogic.HotelSearchNearBy(repHotelInfo.reqdata.lng, repHotelInfo.reqdata.lat);
            ViewBag.NearHotels = nearHotels;
            string title = string.Format("{0}酒店预定,{1}酒店预定", repHotelInfo.reqdata.hotelname, repHotelInfo.reqdata.cityname);
            string keywords = string.Format("{0}酒店预定,{1}酒店预定", repHotelInfo.reqdata.hotelname, repHotelInfo.reqdata.cityname);
            string description = repHotelInfo.reqdata.content;
            SetPageSEO(title,keywords,description);

            var nearSceneryinfos = sceneryingoBusinessLogic.GetSceneryInfosBycCoordinate(repHotelInfo.reqdata.baidu_lat, repHotelInfo.reqdata.baidu_lng,1,15);
            ViewBag.NearSceneryInfos = nearSceneryinfos;

            var cityinfo=zhunaHotelBusiness.ZhunaCityInfosGet().SingleOrDefault(u => u.cid == repHotelInfo.reqdata.cityid);
            if(cityinfo!=null)
            {
                repHotelInfo.reqdata.ctripcityid = cityinfo.ctripcityid;
            }

            return View(getView("HotelInfo"), repHotelInfo.reqdata);
        }

        [HttpGet]
        public ActionResult HotelRooms(int hotelid)
        {
            LogHelper.Info(string.Format("hotelid:{0}start!",hotelid));
            DateTime logStart = DateTime.Now;
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(1);
            var repEntity=ZhunaHotelServiceLogic.HotelRoomPlanSearch(hotelid, startDate, endDate);
            DateTime logEnd = DateTime.Now;
            LogHelper.Info(string.Format("hotelid:{0},end,耗时:{1}",hotelid,(logEnd-logStart).TotalMilliseconds));
            return View(getView("HotelRooms"), repEntity);
        }

        public ActionResult GetComments(int hotelid)
        {
            var comments = ZhunaHotelServiceLogic.GetHotelComment(hotelid);
            return View(getView("GetComments"), comments);
        }

        [HttpPost]
        public ActionResult GetRoomInfos(int hotelid,DateTime startDate,DateTime endDate)
        {
            var repEntity = ZhunaHotelServiceLogic.HotelRoomPlanSearch(hotelid, startDate, endDate);
            return View(getView("GetRoomInfos"), repEntity);
        }

        
    }
}
