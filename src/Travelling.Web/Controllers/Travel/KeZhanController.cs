using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Travelling.Lucene;
using Travelling.OpenApiEntity.TC.Hotel;
using Travelling.OpenApiEntity.TC.Hotel.Module;
using Travelling.OpenApiLogic;
using Travelling.ViewModel;
using Travelling.ViewModel.Travel;
using Travelling.Web.XmlData;

namespace Travelling.Web.Controllers.Travel
{
    /// <summary>
    /// 古镇
    /// </summary>
    public class KeZhanController:BaseController
    {
        private string GetView(string viewName)
        {
            return string.Format("~/Areas/Travel/Views/KeZhan/{0}.cshtml", viewName);
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 3600)]
        public ActionResult Index()
        {
            string title = "古镇客栈预订_特色客栈预订_客栈民宿推荐_卓家客栈酒店预订";
            string keyWords = "古镇客栈预订,特色客栈推荐,民宿客栈价格查询";
            string descriptions = "卓家客栈酒店预订,提供全国数千城市的客栈民宿预订信息，特色旅馆、度假村、农家乐价格查询，优质青年旅舍、酒店式公寓图片查询等服务。客栈、旅馆、度假村、酒店式公寓、青年旅舍、农家乐、民宿、古镇。";
            SetPageSEO(title,keyWords,descriptions);

            var cityinfos = XmlDataSource.GuZhenHotelCityInfoGet();
            ViewBag.GuZhen = cityinfos;

            int cityid = 385;
            GetHotelListCallEntity callEntity = new GetHotelListCallEntity();
            callEntity.cityId = cityid;
            callEntity.comeDate = DateTime.Now.AddDays(1);
            callEntity.leaveDate = DateTime.Now.AddDays(3);
            callEntity.keyword = "西塘";
            callEntity.searchFields = "hotelName,address";
            
            var rep=OTATCHotelServiceLogic.TC_GetHotelList(callEntity);
            
            return View(GetView("Index"),rep);
        }

        /// <summary>
        /// 古镇客栈信息
        /// </summary>
        /// <param name="pinyin"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [OutputCache(Duration = 3600)]
        public ActionResult GuZhen(string pinyin)
        {
            var cityinfos = XmlDataSource.GuZhenHotelCityInfoGet();
            ViewBag.GuZhen = cityinfos;
            var cityinfo = cityinfos.SingleOrDefault(u => u.Pinyin == pinyin);
            

            ViewBag.Selected = cityinfo;

            GetHotelListCallEntity callEntity = new GetHotelListCallEntity();
            callEntity.cityId = cityinfo.CityId;
            callEntity.comeDate = DateTime.Now.AddDays(1);
            callEntity.leaveDate = DateTime.Now.AddDays(3);
            callEntity.keyword = cityinfo.KeyWords;
            callEntity.searchFields = "hotelName,address";
            

            string title = string.Format("{0}古城_{0}古城客栈_卓家客栈旅游网", cityinfo.CityName);
            string seoKeyWords = string.Format("{0}古城,{0}古城客栈,{0}古城旅游,卓家客栈旅游网", cityinfo.CityName);
            string descriptions = string.Format("卓家客栈古镇客栈为您提供{0}客栈预订价格查询、{0}特色客栈推荐等服务，低廉的价格，享受酒店不具备的个性体验，是您查询预订客栈的最佳选择", cityinfo.CityName);

            SetPageSEO(title,seoKeyWords,descriptions);
            var rep = OTATCHotelServiceLogic.TC_GetHotelList(callEntity);

            return View(GetView("GuZhen"), rep);
        }

        [HttpGet]
        public ActionResult GuZhenPage(string pinyin,int page=1)
        {
            var cityinfos = XmlDataSource.GuZhenHotelCityInfoGet();
            ViewBag.GuZhen = cityinfos;
            var cityinfo = cityinfos.SingleOrDefault(u => u.Pinyin == pinyin);


            ViewBag.Selected = cityinfo;

            GetHotelListCallEntity callEntity = new GetHotelListCallEntity();
            callEntity.cityId = cityinfo.CityId;
            callEntity.comeDate = DateTime.Now.AddDays(1);
            callEntity.leaveDate = DateTime.Now.AddDays(3);
            callEntity.keyword = cityinfo.KeyWords;
            callEntity.searchFields = "hotelName,address";
            callEntity.Page = page;

            string title = string.Format("{0}古城_{0}古城客栈_卓家客栈旅游网", cityinfo.CityName);
            string seoKeyWords = string.Format("{0}古城,{0}古城客栈,{0}古城旅游,卓家客栈旅游网", cityinfo.CityName);
            string descriptions = string.Format("卓家客栈古镇客栈为您提供{0}客栈预订价格查询、{0}特色客栈推荐等服务，低廉的价格，享受酒店不具备的个性体验，是您查询预订客栈的最佳选择", cityinfo.CityName);

            SetPageSEO(title, seoKeyWords, descriptions);
            var rep = OTATCHotelServiceLogic.TC_GetHotelList(callEntity);

            return View(GetView("GuZhen"), rep);
        }

        /// <summary>
        /// 获取游客评论信息
        /// </summary>
        /// <param name="hotelid"></param>
        /// <returns></returns>
        [HttpPost]
        [OutputCache(Duration = 3600)]
        public JsonResult GetComment(int hotelid)
        {
            var comments = OTATCHotelServiceLogic.GetCommentList(hotelid);
            HotelCommentInfo comment;
            JsonViewResult<HotelCommentInfo> jsonViewResult = new JsonViewResult<HotelCommentInfo>() { Success=false,Data=hotelid };
            if (comments.Comments != null && comments.Comments.Count>0)
            {
                comment = comments.Comments[0];
                jsonViewResult.Success = true;
                jsonViewResult.Data2 = comments.Comments.Count;
            }
            else
            {
                comment = new HotelCommentInfo();
                jsonViewResult.Success = false;
                jsonViewResult.Data2 = 0;
            }
            jsonViewResult.obj = comment;
            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取酒店评论
        /// </summary>
        /// <param name="hotelid"></param>
        /// <returns></returns>
        public PartialViewResult GetComments(int hotelid)
        {
            var comments = OTATCHotelServiceLogic.GetCommentList(hotelid);
            return PartialView(GetView("GetComments"), comments);
        }

        /// <summary>
        /// 酒店详情
        /// </summary>
        /// <param name="hotelid"></param>
        /// <returns></returns>
       [OutputCache(Duration = 3600)]
        public ActionResult Detail(int hotelid)
        {
            var repHotelDetail = OTATCHotelServiceLogic.TC_GetHotelDetail(hotelid);
            var hotelDetail = repHotelDetail.HotelDetailInfo;
            string title = hotelDetail.hotelName;
            string keyWords = string.Format("{0},{0}预定,{1}", hotelDetail.hotelName, hotelDetail.hotelName, hotelDetail.address);
            string descriptions = string.Format("{0},{0}预定,{1},在{2}您可以查询{0}的价格、地图、评价、特惠预订等信息", hotelDetail.hotelName, hotelDetail.address,"卓家客栈");
            SetPageSEO(title, keyWords, descriptions);
            var imgRep = OTATCHotelServiceLogic.TC_GetHotelImageList(hotelid);
            var imgList = imgRep.Imgs;
            ViewBag.ImgList = imgList;
            ViewBag.BaseImgUrl = imgRep.imageBaseUrl;

            HotelCookieView cookieView = new HotelCookieView()
            {
                HotelId = hotelDetail.hotelId,
                HotelName = hotelDetail.hotelName,
                Amount = (int)hotelDetail.lowestPrice,
                HotelIcon = imgRep.imageBaseUrl +"/small/"+ hotelDetail.introPhoto,
                HotelStar = 0,
                UnionId = 1
            };
            AddHotelToCookie(cookieView);

            var roomsRep = OTATCHotelServiceLogic.TC_GetHotelRooms(hotelid,DateTime.Now,DateTime.Now.AddDays(3));
            ViewBag.Rooms = roomsRep.Rooms;

            string cityName = repHotelDetail.HotelDetailInfo.cityName;
            
            var sceneryinfos = SceneryTicketSearchLucene.Instance().SceneryLuceneIndexSearch(cityName);
            ViewBag.NearSceneryInfos = sceneryinfos;
            GetHotelListCallEntity callEntity = new GetHotelListCallEntity();
            callEntity.cityId = hotelDetail.cityId;
            callEntity.comeDate = DateTime.Now;
            callEntity.leaveDate = DateTime.Now.AddDays(2);
            var hotelinfosRep = OTATCHotelServiceLogic.TC_GetHotelList(callEntity);
            ViewBag.NearHotelRep = hotelinfosRep;
            return View(GetView("Detail"), hotelDetail);
        }

        /// <summary>
        /// 热门古镇
        /// </summary>
        /// <returns></returns>
        public PartialViewResult HotGuZhen()
        {
            var cityinfos = XmlDataSource.GuZhenHotelCityInfoGet();
            return PartialView(GetView("HotGuZhen"), cityinfos);
        }
    }
}
