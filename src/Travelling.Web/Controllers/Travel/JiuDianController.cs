using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using Travelling.FrameWork;
using Travelling.OpenApiEntity.Ctrip.Enums;
using Travelling.OpenApiEntity.Ctrip.Hotel.Module;
using Travelling.OpenApiEntity.Ctrip.Tuan;
using Travelling.OpenApiLogic;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.ViewModel.Hotel;
using Travelling.ViewModel.Travel;
using Travelling.Web.Helpers;

namespace Travelling.Web.Controllers.Travel
{
    /// <summary>
    /// 酒店Web控制类
    /// </summary>
    public class JiuDianController : BaseController
    {
        private readonly IHotelInfoBusinessLogic hotelInfoBusinessLogic;
        private readonly ISceneryTicketInfoBusinessLogic ticketInfoBusinessLoigic;
        private readonly IHotelCityBusinessLogic hotelCityBusinessLogic;
        private readonly IZhunaHotelBusinessLogic zhunaHotelBusinessLogic;

        private string GetView(string viewName)
        {
            return string.Format("~/Areas/Travel/Views/JiuDian/{0}.cshtml", viewName);
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hotelInfoRep"></param>
        public JiuDianController(IHotelInfoBusinessLogic hotelBusinessLogic, 
            ISceneryTicketInfoBusinessLogic ticketBusiness, 
            IHotelCityBusinessLogic hotelCityBusiness,
            IZhunaHotelBusinessLogic zhuanHotelLogic
            )
        {
            this.ticketInfoBusinessLoigic = ticketBusiness;
            this.hotelInfoBusinessLogic = hotelBusinessLogic;
            this.hotelCityBusinessLogic = hotelCityBusiness;
            this.zhunaHotelBusinessLogic = zhuanHotelLogic;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        [OutputCache(Duration = 36000)]
        public ActionResult Index()
        {
            string title = "酒店预订,酒店查询,宾馆住宿预订,网上订酒店【卓家客栈】";
            string descriptions = "卓家客栈提供国内631多个城市，80 多个品牌,包括洲际、万豪、雅高、喜达屋等国际知名酒店品牌，以及如家、锦江之星、格林豪泰等经济型商务连锁酒店，超过3万家酒店的在线预订和电话预订服务。无需在线付款，酒店前台付款"
;
            string keyWords = "酒店,酒店预订";
            SetPageSEO(title, keyWords, descriptions);

            var hotHotelCities = hotelCityBusinessLogic.HotelCityDetailInfosGet().Where(u => u.IsHotCity == 1).ToList();
            ViewData["HotHotelCities"] = hotHotelCities;
            //var hotelHotels = hotelInfoBusinessLogic.HotelDescriptionGetByCityIdList(hotHotelCities.Select(u=>u.CityID).ToList());
            return View(GetView("Index"));
        }

        /// <summary>
        /// 获取房间信息
        /// </summary>
        /// <param name="roomtypecode"></param>
        /// <returns></returns>
        public ActionResult RoomInfo(int roomtypecode = 0)
        {
            Tuple<int> roomInfo = Tuple.Create<int>(roomtypecode);
            return View(roomInfo);
        }

        /// <summary>
        /// 酒店信息
        /// </summary>
        /// <returns></returns>
        //[OutputCache(Duration = 3600)]
        [HttpGet]
        public ActionResult HotelInfo(int hotelId = 0, string startDate = "", string endDate = "")
        {
            var hotelDescDto = hotelInfoBusinessLogic.GetHotelDescriptionByHotelId(hotelId);

            string seoKeys = string.Format("{0},{0}电话,{0}地址,{0}价格查询", hotelDescDto.HotelDescription.HotelName);
            string seoDescriptions = string.Format("{0}官网联合预订,卓家客栈酒店提供{0}价格查询,涵盖{0}电话、服务设施、地址交通及周边酒店信息,鲜活的{0}网友真实点评、酒店图片等信息。网上订{0},来卓家客栈享受有房保证!", hotelDescDto.HotelDescription.HotelName);
            SetPageSEO(hotelDescDto.HotelDescription.HotelName, seoKeys, seoDescriptions);

            if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
            {
                startDate = DateTime.Now.ToString("yyyy-MM-dd");
                endDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            }

            HotelInfoQuery hotelQuery = new HotelInfoQuery();
            hotelQuery.CityId = hotelDescDto.HotelDescription.HotelCityCode;

            hotelQuery.StartDate = DateTime.Parse(startDate);
            hotelQuery.EndDate = DateTime.Parse(endDate);
            ViewData["QueryCondition"] = hotelQuery;
            HotelCookieView cookieView = new HotelCookieView() {
                HotelId = hotelDescDto.HotelDescription.HotelID,
                HotelName = hotelDescDto.HotelDescription.HotelName,
                Amount = hotelDescDto.HotelDescription.TrueAmount,
                HotelIcon = hotelDescDto.HotelDescription.HotelImg,
                HotelStar = (int)hotelDescDto.HotelDescription.HotelStarRate, 
                UnionId = 0
            };
            AddHotelToCookie(cookieView);
            string hotCities = hotelInfoBusinessLogic.HotelCityDetailInfoGetJsonData();
            ViewBag.HotCities = hotCities;

            var nearHotels = hotelInfoBusinessLogic.GetNearHotelInfos(hotelId, 1).Range(8);
            ViewBag.NearHotels = nearHotels;

            ViewBag.HotelViewed = GetHotelViewed();

            ViewBag.RefPoints = hotelInfoBusinessLogic.GetRefPointsByHotelID(hotelId);

            var nearSceneryInfos = ticketInfoBusinessLoigic.GetSceneryInfoByHotelCityName(hotelDescDto.HotelDescription.CityName).Range(8);
            ViewBag.NearSceneryInfos = nearSceneryInfos;

            List<int> hotelIds = new List<int>() { hotelId };
            var roomRatesApiResult = OTAHotelServiceLogic.OTA_HotelRatePlan(hotelIds, hotelQuery.StartDate, hotelQuery.EndDate);

            List<RoomRatePlan> roomRates = roomRatesApiResult.HotelRatePlanList[0].RoomRatePlanList ?? new List<RoomRatePlan>();
            List<HotelRoomRateViewModel> roomRateViewModels = new List<HotelRoomRateViewModel>();
            if (roomRates.Count > 0)
            {
                var roominfos = hotelInfoBusinessLogic.HotelRoomInfoGetByHotelId(hotelId);
                List<MultimediaImgDescription> roomImgs = JsonConvert.DeserializeObject<List<MultimediaImgDescription>>(hotelDescDto.HotelDescription.MediaItems);

                HotelRoomRateViewModel viewModel;
                HotelRoomInfo roominfo;
                RoomRate rate;
                List<MultimediaImgDescription> imgDescriptions;
                foreach (var rp in roomRates)
                {
                    roominfo = roominfos.Where(u => u.RoomTypeCode == rp.HotelRoomCode).SingleOrDefault();
                    if (roominfo == null)
                    {
                        continue;
                    }
                    rate = rp.RoomRateList != null && rp.RoomRateList.Count > 0 ? rp.RoomRateList[0] : null;

                    viewModel = new HotelRoomRateViewModel();
                    viewModel.BedTypeCode = "0";

                    if (rate != null)
                    {
                        viewModel.NumberOfBreakfast = rate.NumberOfBreakfast;
                        viewModel.Date = rate.StartTime;
                        viewModel.HoteId = hotelId;
                        viewModel.Internet = "";
                        viewModel.Policy = "";
                        viewModel.BedTypeCode = roominfo.BedTypeCode;
                        viewModel.AmountBeforeTax = (int)rate.AmountBeforeTax;
                        viewModel.RoomTypeCode = rp.HotelRoomCode;
                        viewModel.RoomTypeName = roominfo.RoomTypeName;
                        viewModel.CancelAmount = (int)rate.CancelAmount;
                        viewModel.Floor = roominfo.Floor;
                        viewModel.RoomSize = roominfo.RoomSize;
                        viewModel.StandardOccupancy = roominfo.StandardOccupancy;
                        viewModel.RateCategoryCode = rp.RatePlanCategory;

                        imgDescriptions = roomImgs.Where(u => u.Caption == viewModel.RoomTypeName).ToList();
                        if (imgDescriptions != null && imgDescriptions.Count > 1)
                        {
                            viewModel.BigImg = imgDescriptions[0].Url;
                            viewModel.SmallImage = imgDescriptions[0].Url.Replace("_500_412", "_300_225");
                        }
                        else
                        {
                            viewModel.BigImg = roomImgs[0].Url;
                            viewModel.BigImg = roomImgs[0].Url.Replace("_500_412", "_300_225");
                        }
                        roomRateViewModels.Add(viewModel);
                    }
                }
            }
            ViewBag.RatePlans = roomRateViewModels;

            return View(hotelDescDto);
        }

        /// <summary>
        /// 酒店房间预定
        /// </summary>
        /// <returns></returns>
        public ActionResult Order(int roomTypeCode = 0, int hotelId = 0, string startDate = "", string endDate = "", int cityId = 0, string cityName = "")
        {
            var hotelInfo = hotelInfoBusinessLogic.GetHotelDescriptionByHotelId(hotelId);
            var hotelRoomInfo = hotelInfoBusinessLogic.GetHotelRoomInfoByRoomTypeCode(roomTypeCode);
            hotelRoomInfo.HotelCode = hotelId;
            ViewBag.RoomInfo = hotelRoomInfo;
            HotelRoomBookInfo bookInfo = new HotelRoomBookInfo();
            bookInfo.InRoomDate = DateTime.Parse(startDate);
            bookInfo.OffRoomDate = DateTime.Parse(endDate);
            bookInfo.HotelCode = hotelId;
            bookInfo.RoomTypeCode = roomTypeCode;
            HotelPolicy policyInfo = new HotelPolicy();
            if (!string.IsNullOrEmpty(hotelInfo.HotelDescription.PolicyInfo))
            {
                policyInfo = JsonConvert.DeserializeObject<HotelPolicy>(hotelInfo.HotelDescription.PolicyInfo);
            }
            ViewBag.PolicyInfo = policyInfo;
            string HotelImg = "";
            if (!string.IsNullOrEmpty(hotelInfo.HotelDescription.HotelImg))
            {
                HotelImg = hotelInfo.HotelDescription.HotelImg;
            }
            else
            {
                List<MultimediaImgDescription> imgs = JsonConvert.DeserializeObject<List<MultimediaImgDescription>>(hotelInfo.HotelDescription.MediaItems);
            }
            ViewBag.HotelImg = HotelImg;

            List<Facility> hotelRoomServices = new List<Facility>();

            if (!string.IsNullOrEmpty(hotelRoomInfo.Facility))
            {
                hotelRoomServices = JsonConvert.DeserializeObject<List<Facility>>(hotelRoomInfo.Facility);
            }

            ViewBag.HotelRoomServices = BuildRoomServices(hotelRoomServices, hotelRoomInfo);

            //var roomRatePlans = hotelInfoBusinessLogic.GetHotelRoomRatePlans(hotelInfo.HotelDescription.HotelID, roomTypeCode, hotelInfo.HotelDescription.HotelCityCode, bookInfo.InRoomDate, bookInfo.OffRoomDate);
            //ViewBag.RoomPrices = roomRatePlans;

            var rateplans = OTAHotelServiceLogic.OTA_HotelRatePlan(hotelId, bookInfo.InRoomDate, bookInfo.OffRoomDate.AddDays(-1));

            var roomrate = rateplans.RoomRatePlanList.Where(u => u.HotelRoomCode == roomTypeCode).SingleOrDefault();
            int totlaAmount = (int)roomrate.RoomRateList.Sum(u => u.AmountBeforeTax);
            ViewBag.TotalAmount = totlaAmount;

            ViewBag.RoomPriceList = roomrate.RoomRateList;
            return View(bookInfo);
        }

        /// <summary>
        /// 下单结果
        /// </summary>
        /// <returns></returns>
        [HandleError()]
        public ActionResult OrderResult(string orderNo)
        {
            SetPageSEO("酒店订单结果");
            HotelOrderResult orderResult = TempData["OrderResult"] as HotelOrderResult;

            if (orderResult.Success)
            {
                var orderInfo = hotelInfoBusinessLogic.GetHotelBookOrderBySerial(orderResult.OrderNo);
                orderResult.OrderInfo = orderInfo;
            }

            TempData["OrderResult"] = orderResult;
            return View("~/Areas/Travel/Views/JiuDian/OrderResult.cshtml", orderResult);
        }

        private MvcHtmlString BuildRoomServices(List<Facility> services, HotelRoomPrimaryInfo roomInfo)
        {
            StringBuilder build = new StringBuilder();
            build.AppendFormat("<li class=\"room_type\"><span>{0}</span></li>", roomInfo.RoomTypeName);
            string bedTypeName = "";
            if (!string.IsNullOrEmpty(roomInfo.BedTypeCode))
            {
                bedTypeName = EnumHelper.GetDescriptionFromEnumValue((BedType)roomInfo.BedTypeCode.ToInt32());
            }

            build.AppendFormat("<li alt=\"{0}\" title=\"{0}\" class=\"s_fac\"><span class=\"t\">床型：{0}</span></li>", bedTypeName);

            var freeAddBed = services.Select(u =>
            {
                return u.Code == 17;
            });

            var feeAddBed = services.Select(u =>
            {
                return u.Code == 11;
            });

            if (freeAddBed != null && freeAddBed.Count() > 0)
            {
                build.Append("<li alt=\"可加床\" title=\"可加床\" class=\"s_fac\"><span>加床：</span>可加床</li>");
            }
            build.AppendFormat("<li alt=\"{0}层\" title=\"{0}层\"><span>楼层：</span>{0}层</li>", roomInfo.Floor);
            build.AppendFormat("<li alt=\"{0}平方米\" title=\"{0}平方米\"><span>面积：</span>{0}平方米</li>", roomInfo.Size);
            var internet = services.Select(u =>
            {
                return u.Code == 3;
            });
            if (internet != null && internet.Count() > 0)
            {
                build.Append("<li alt=\"全部房间支持免费有线上网\" title=\"全部房间支持免费有线上网\" class=\"s_bd\"><span>宽带：</span>全部房间支持免费有线上网</li>");
            }

            return new MvcHtmlString(build.ToString());
        }

        /// <summary>
        /// 酒店下单
        /// </summary>
        /// <param name="bookInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Order(HotelRoomBookInfo bookInfo)
        {
            HotelOrderResult jsonViewResult = new HotelOrderResult() { Success = false };

            string startDateTime = bookInfo.InRoomDate.ToString("yyyy-MM-dd") + " " + bookInfo.BeforeCheckInTime;
            string endDateTime = bookInfo.OffRoomDate.ToString("yyyy-MM-dd") + " " + bookInfo.LastCheckInTime;
            string lastCheckInDate = bookInfo.InRoomDate.ToString("yyyy-MM-dd") + " " + bookInfo.LastCheckInTime;

            var avaibleRep = OTAHotelServiceLogic.HotelRoomBookAvaible(bookInfo.HotelCode, bookInfo.RoomTypeCode, bookInfo.RoomCount, bookInfo.Customers.Count, Convert.ToDateTime(startDateTime), Convert.ToDateTime(endDateTime), Convert.ToDateTime(lastCheckInDate));
            if (!avaibleRep.AvaibleStatus)
            {
                jsonViewResult.Success = false;
                jsonViewResult.Message = "预定失败，请重新预定";
                jsonViewResult.Errors = avaibleRep.Errors.Select(u =>
                {
                    return new HotelBookError()
                    {
                        Code = u.Code,
                        Content = u.Content,
                        ShortText = u.ShortText,
                        Type = u.Type
                    };
                }).ToList();
            }
            else
            {
                var hotelInfo = hotelInfoBusinessLogic.GetHotelDescriptionByHotelId(bookInfo.HotelCode); //hotelInfoRep.SingleOrDefault(bookInfo.HotelCode);
                bookInfo.HotelName = hotelInfo.HotelDescription.HotelName;
                bookInfo.HotelAddress = hotelInfo.HotelDescription.AddressLine;

                var bookResult = hotelInfoBusinessLogic.BookRooms(bookInfo);

                if (!string.IsNullOrEmpty(bookResult.OrderSerial))
                {
                    jsonViewResult.Success = true;
                    jsonViewResult.Message = "预定成功:" + bookResult.OrderSerial;
                    jsonViewResult.OrderNo = bookResult.OrderSerial;
                }
                else
                {
                    jsonViewResult.Success = false;
                    HotelBookError bookError = new HotelBookError()
                    {
                        Code = bookResult.Code,
                        Content = bookResult.FailReason,
                        ShortText = bookResult.FailReason,
                        Type = 0
                    };
                    jsonViewResult.Errors = new List<HotelBookError>() { bookError };
                    //jsonViewResult.Message = string.Format("预定失败，失败原因:{0}", EnumHelper.GetDescriptionFromEnumValue((HotelBookResultCode)bookResult.Code));
                }
            }

            TempData["OrderResult"] = jsonViewResult;
            return RedirectToAction("OrderResult");
        }

        /// <summary>
        /// 酒店下单验证
        /// </summary>
        /// <param name="bookInfo"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private string BookValidate(HotelRoomBookInfo bookInfo, out bool result)
        {
            string errorMsg = "";
            result = true;

            DateTime inRoomDateTime = DateTime.Parse(string.Format("{0} {1}", bookInfo.InRoomDate.ToString("yyyy-MM-dd"), bookInfo.BeforeCheckInTime));
            if (inRoomDateTime <= DateTime.Now)
            {
                errorMsg = "入住日期不能晚于当前日期";
                result = false;
            }

            if (bookInfo.InRoomDate >= bookInfo.OffRoomDate)
            {
                errorMsg = "入住日期不能晚于离店日期";
                result = false;
            }

            if (bookInfo.HotelCode <= 0)
            {
                errorMsg = "非法酒店";
                result = false;
            }
            if (bookInfo.RoomTypeCode <= 0)
            {
                errorMsg = "非法房型";
                result = false;
            }
            if (bookInfo.AmountBeforeTax <= 0)
            {
                errorMsg = "房费不正确";
                result = false;
            }
            if (!string.IsNullOrEmpty(bookInfo.ContactEmail) && Utils.IsValidEmail(bookInfo.ContactEmail))
            {
                errorMsg = "邮箱格式不正确";
                result = false;
            }
            if (string.IsNullOrEmpty(bookInfo.ContactName))
            {
                errorMsg = "输入联系人";
                result = false;
            }
            if (bookInfo.Customers == null || bookInfo.RoomCount == 0)
            {
                errorMsg = "输入客人信息";
                result = false;
            }
            if (bookInfo.InRoomDate <= DateTime.Now)
            {
                errorMsg = "入住时间晚于当前时间";
            }

            if (string.IsNullOrEmpty(bookInfo.MobilePhone))
            {
                errorMsg = "请填写手机号码";
                result = false;
            }

            if (string.IsNullOrEmpty(bookInfo.MobilePhone) || !Utils.IsValidTelphone(bookInfo.MobilePhone))
            {
                errorMsg = "请填写正确的手机号码";
                result = false;
            }

            if (bookInfo.RoomCount <= 0)
            {
                errorMsg = "房间数量应该大于0";
                result = false;
            }

            if (bookInfo.RoomCount > 0)
            {
                for (var index = 0; index < bookInfo.RoomCount; index++)
                {
                    if (string.IsNullOrEmpty(bookInfo.Customers[index]))
                    {
                        errorMsg = "请填写住客姓名";
                        result = false;
                        break;
                    }
                }
            }

            //var rateplans = hotelInfoBusinessLogic.GetRoomPriceByRoomTypeCodeAndHotelID(bookInfo.HotelCode,, bookInfo.RoomTypeCode, bookInfo.InRoomDate, bookInfo.OffRoomDate);

            //if (rateplans == null || rateplans.Count == 0)
            //{
            //    result = false;
            //    errorMsg = "当前日期没有房间可预定";
            //}
            return errorMsg;
        }

        /// <summary>
        /// 酒店预定查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult HotelBookingQuery(HotelBookingQueryModel query)
        {
            int price = (int)query.HotelPriceLevel;
            return View();
        }

        [HttpGet]
        public ActionResult Map(string latitude = "", string longitude = "", string hotelName = "")
        {
            Tuple<string, string, string> positions = Tuple.Create<string, string, string>(longitude, latitude, hotelName);
            string gaodeMapKey = ConfigurationManager.AppSettings["GaoDeMapKey"];
            ViewBag.GaoDeMapKey = gaodeMapKey;
            return View("~/Areas/Travel/Views/JiuDian/Map.cshtml", positions);
        }

        /// <summary>
        /// 获取地图
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        [HttpGet]
        public JavaScriptResult GetMapFunction(string latitude = "", string longitude = "")
        {
            string funJs = "var mapObj;"
                            + "function mapInit(){"
                                + "mapObj = new AMap.Map(\"iCenter\",{"
                                    + "view: new AMap.View2D({"
                                        + string.Format("center: new AMap.LngLat({0}, {1}),", longitude, latitude)
                                        + "zoom:13 "
                                    + "})"
                                + "});"
                                + "var marker = new AMap.Marker({"
        + "position:mapObj.getCenter(),"
        + "draggable:true,"
        + "cursor:'move',"
        + "raiseOnDrag:true"
    + "})"
+ "marker.setMap(mapObj);"
                            + "}";
            return JavaScript(funJs);
        }

        [HttpGet]
        public JsonResult GetCustomerInputs(int customerCount, DateTime beginDate, DateTime endDate)
        {
            JsonViewResult jsonViewResult = new JsonViewResult();
            int index = 0;
            StringBuilder build = new StringBuilder();
            for (int i = 1; i <= customerCount; i++)
            {
                build.AppendFormat("<input type=\"text\" name=\"Customers[{0}]\" id=\"J_resident_{1}\" onblur='warning(this);' class=\"input_txt customerName\" autocomplete=\"off\" index=\"{1}\" req=\"1\" placeholder=\"住客{1}（中文/英文）（必填）\">", index, index + 1);
                index++;
            }
            //for (int i = 1; i <= customerCount; i++)
            //{
            //    build.AppendFormat("<input type=\"text\" name=\"Customers[{0}]\" id=\"J_resident_{1}\" class=\"input_txt customerName\" autocomplete=\"off\" index=\"{1}\" req=\"1\" placeholder=\"住客{1}（中文/英文）（必填）\">", index, index + 1);
            //    index++;
            //}

            build.Append("<input type=\"hidden\" index=\"16\"><div style=\"display: none;\" id=\"notEnoughUser\" class=\"b_notes\"><i></i>请填写住客姓名。</div>");
            build.Append("<div style=\"display: none;\" id=\"blackListUser\" class=\"b_notes\"><i></i>请输入正确的入住人姓名。</div>");
            build.Append("<div style=\"display: none;\" id=\"wrongName\" class=\"b_notes\"><i></i>请填写正确的住客姓名（中文/英文）中文填写如：王小花，英文填写需要在名与姓间加“/”如：wang/xiaohua</div>");
            build.Append("<div class=\"order_notes2\">");
            build.AppendFormat("<i></i>至少填写<span id=\"minUser\">{1}</span>人，最多填写<span id=\"maxUser\">{0}</span>人。所填姓名需与入住时所持证件一致。", customerCount * 2, customerCount);

            TimeSpan span = endDate - beginDate;

            Tuple<string, string, string> jsonData = Tuple.Create<string, string, string>(build.ToString(), span.Days.ToString(), customerCount.ToString());

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取最晚到底时间
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetReceiveTimeList(string startDate)
        {
            DateTime date = DateTime.Parse(startDate);
            StringBuilder timeBuild = new StringBuilder();
            StringBuilder timeEndBuild = new StringBuilder();
            if (date > DateTime.Now.Date || (DateTime.Now.Date == date.Date && DateTime.Now.Hour < 12))
            {
                for (int start = 12; start <= 23; start++)
                {
                    timeBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", start, "00");
                    timeBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", start, "30");

                    if (start + 3 == 24)
                    {
                        timeEndBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", "23", "59");
                        continue;
                    }
                    else if (start + 3 < 25)
                    {
                        timeEndBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", start + 3, "00");
                        timeEndBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", start + 3, "30");
                    }
                }
            }
            else
            {
                for (int s = DateTime.Now.Hour; s <= 23; s++)
                {
                    if (DateTime.Now.Minute >= 30)
                    {
                        if (s + 1 < 24)
                        {
                            // just a test for it in your dream!!
                            // for it in your dream!!!
                            // go

                            timeBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", s + 1, "00");
                            timeBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", s + 1, "30");
                            //timeEndBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", s + 3, "00");
                        }
                        if (s == 23)
                        {
                            timeBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", s, "30");
                            timeEndBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", "23", "59");
                        }

                        if (s + 3 == 24)
                        {
                            timeEndBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", "23", "59");
                            continue;
                        }
                        else if (s + 3 < 25)
                        {
                            timeEndBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", s + 3, "00");
                            timeEndBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", s + 3, "30");
                        }
                    }
                    else
                    {
                        if (s + 1 < 24)
                        {
                            timeBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", s, "30");
                            timeBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", s + 1, "00");

                            if (s + 3 < 24)
                            {
                                timeEndBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", s + 3, "30");
                                timeEndBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", s + 4, "00");
                            }
                            //timeEndBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", s + 3, "00");
                        }
                        if (s == 23)
                        {
                            timeBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", "23", "30");
                        }
                        if (s + 1 > 24)
                        {
                            timeEndBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", "23", "30");
                        }
                        if (s + 3 >= 24)
                        {
                            timeEndBuild.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", "23", "59");
                            continue;
                        }
                    }
                }
            }

            StringBuilder buildLeft = new StringBuilder();
            StringBuilder buildRight = new StringBuilder();

            int hour = date.Hour < 12 ? 12 : date.Hour;
            int min = date.Minute;
            int startMin = min;
            for (int index = hour; index <= 23; index++)
            {
                if (min <= 30 && hour == index)
                {
                    buildLeft.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", index, "00");
                    if (hour == 12)
                    {
                        buildLeft.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", index, "30");
                    }
                }
                else if (hour == index && min >= 30)
                {
                    continue;
                }
                else
                {
                    buildLeft.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", index, "00");
                    buildLeft.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", index, "30");
                }
            }

            for (int index = hour + 3; index <= 23; index++)
            {
                if (startMin >= 30)
                {
                    buildRight.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", index + 1, "30");
                    buildRight.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", index + 1, "00");
                    if (index >= 23)
                    {
                        buildRight.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", "23", "59");
                    }
                }
                else
                {
                    buildRight.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", index, "00");
                    buildRight.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", index, "30");
                    if (index >= 23)
                    {
                        buildRight.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", "23", "59");
                    }
                }
            }
            //for()
            var jsonResult = new { left = timeBuild.ToString(), right = timeEndBuild.ToString() };

            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public string GetNextTimes(string selectTime)
        {
            DateTime dt;
            List<string> items = selectTime.Split(':').ToArray().ToList();
            int hour = items[0].ToInt32();
            int min = items[1].ToInt32();

            string minStr = "";
            string hourStr = "";

            if (hour + 3 > 23)
            {
                hourStr = "23";
                minStr = "59";
                if (min >= 30)
                {
                    minStr = "59";
                }

                string ss = string.Format("<option value=\"{0}:{1}:00\">{0}:{1}</option>", hourStr, minStr);
                return string.Format("<option value=\"{0}:{1}:00\">{0}:{1}</option>", hourStr, minStr);
            }
            else
            {
                StringBuilder build = new StringBuilder();
                for (int index = hour + 3; index <= 23; index++)
                {
                    if (min >= 30)
                    {
                        if (index >= 23)
                        {
                            build.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", "23", "59");
                        }
                        else
                        {
                            build.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", index, "30");
                            build.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", index, "00");
                        }
                    }
                    else
                    {
                        build.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", index, "00");
                        build.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", index, "30");
                        if (index >= 23)
                        {
                            build.AppendFormat("<option value=\"{0}:{1}:00\">{0}:{1}</option>", "23", "59");
                        }
                    }
                }
                return build.ToString();
            }
        }

        //[HttpPost]
        public ActionResult Loading(HotelRoomBookInfo bookInfo)
        {
            Thread.Sleep(2000);
            JsonViewResult jsonViewResult = new JsonViewResult();
            if (bookInfo.InRoomDate < DateTime.Now.Date)
            {
                jsonViewResult.Message = "入住时间不能晚于离开时间";
            }
            if (bookInfo.InRoomDate > bookInfo.OffRoomDate)
            {
                jsonViewResult.Message = "入住时间不能晚于离开时间";
            }
            return View();
        }

        [HttpPost]
        public JsonResult CheckBookState(HotelRoomBookInfo bookInfo)
        {
            JsonViewResult jsonViewResult = new JsonViewResult() { Success = true };
            if (bookInfo.InRoomDate < DateTime.Now.Date)
            {
                jsonViewResult.Message = "入住时间不能晚于当前时间";
                jsonViewResult.Success = false;
                return GetJsonResult(jsonViewResult);
            }
            if (bookInfo.InRoomDate > bookInfo.OffRoomDate)
            {
                jsonViewResult.Message = "入住时间不能晚于离开时间";
                jsonViewResult.Success = false;
                return GetJsonResult(jsonViewResult);
            }
            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 游客酒店浏览记录
        /// </summary>
        /// <returns></returns>
        public ActionResult HotelViewed()
        {
            var hotels = GetHotelViewed();
            return PartialView(hotels.Reverse());
        }

        /// <summary>
        /// 酒店信息查询
        /// </summary>
        /// <param name="cityid">城市</param>
        /// <param name="areaid">热门区域</param>
        /// <param name="locationid">行政区域</param>
        /// <param name="brandid">酒店品牌</param>
        /// <param name="start">入住日期</param>
        /// <param name="end">离店日期</param>
        /// <param name="hotellevel">酒店星级</param>
        /// <param name="price">酒店价格</param>
        /// <param name="page">页码</param>
        /// <param name="keywords">搜索关键字</param>
        /// <param name="minPrice">最低价格</param>
        /// <param name="maxPrice">最高价格</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        [ActionName("hotelsearch")]
        public ActionResult Query(string cityid, string areaid, string locationid, string brandid, string start, string end, string hotellevel, string price, string page = "1", string keywords = "", int minPrice = 1, int maxPrice = 99999, int order = 0)
        {
            //301 重定向
            Response.RedirectPermanent(string.Format("/hotelsearchlist_{0}.html",cityid));

            string hotCities = hotelInfoBusinessLogic.HotelCityDetailInfoGetJsonData();
            ViewBag.HotCities = hotCities;
            if (cityid == "0")
            {
                cityid = "1";
            }

            HotelInfoQuery hotelQuery = new HotelInfoQuery();
            hotelQuery.CityId = cityid.ToInt32();
            hotelQuery.AreaId = areaid.ToInt32();
            hotelQuery.EndDate = end.ToDateTime();
            hotelQuery.HotelBrandID = brandid;
            hotelQuery.HotelPrice = price;
            hotelQuery.HotelStar = hotellevel;
            hotelQuery.KeyWords = keywords.Replace("search", "");
            hotelQuery.LocationID = locationid.ToInt32();
            hotelQuery.PageSize = 10;
            hotelQuery.StartDate = start.ToDateTime();
            hotelQuery.PageIndex = int.Parse(page);

            hotelQuery.MinPrice = price.Split('-')[0].ToInt32();
            hotelQuery.MaxPrice = price.Split('-')[1].ToInt32();

            hotelQuery.OrderType = order;

            var cityInfo = hotelCityBusinessLogic.HotelCityDetailInfoGetByCityID(hotelQuery.CityId);
            string title = string.Format("{0}酒店预定", cityInfo.CityName);
            string seoKeyWords = string.Format("{0}酒店,{0}酒店预订,{0}酒店价格查询,{0}宾馆住宿推荐,网上{0}酒店,卓家客栈酒店", cityInfo.CityName);
            string seoDescriptions = string.Format("{0}酒店预订:门市价2折起,卓家客栈订{0}酒店更享受7*24小时服务.北京酒店预订,尽在卓家客栈酒店预订平台.", cityInfo.CityName);
            SetPageSEO(title, seoKeyWords, seoDescriptions);



            var hotelinfos2 = hotelInfoBusinessLogic.HotelRoomInfoQuery(hotelQuery);

            if (hotelinfos2 == null)
            {
                hotelQuery.TotalRecords = 0;
            }
            else
            {
                hotelQuery.TotalRecords = hotelinfos2.Item3;
            }

            hotelQuery.KeyWords = string.IsNullOrEmpty(hotelQuery.KeyWords) ? "search" : hotelQuery.KeyWords;

            ViewData["QueryCondition"] = hotelQuery;

            ViewBag.TotalRecords = hotelinfos2.Item3;

            List<int> hotelIdList = hotelinfos2.Item1.Select(u => { return u.HotelID; }).ToList();

            int cityId = Convert.ToInt32(cityid);
            string cityName = hotelInfoBusinessLogic.HotelCityDetailInfoGetAll(HotelCityDetailSearchType.All).Where(u => u.CityID == cityId).SingleOrDefault().CityName;
            ViewBag.CityName = cityName;
            ViewBag.CityID = cityId;
            var locations = hotelInfoBusinessLogic.GetLocationInfoByCityID(cityId);
            ViewBag.Locations = locations;
            var refPoints = hotelInfoBusinessLogic.GetRefPointsByCityID(cityId);
            var areaInfo = hotelInfoBusinessLogic.GetCityAreaInfoByCityId(cityId);
            ViewBag.AreaInfos = areaInfo;

            var hotelBrands = hotelCityBusinessLogic.HotelBrandSearchRecommends();
            ViewBag.HotelBrands = hotelBrands;
            ViewBag.HotelInfos = hotelinfos2.Item1;
            ViewBag.HotelRoomPrices = hotelinfos2.Item2;

            // bind search form
            ViewBag.StartData = start;
            ViewBag.EndDate = end;

            // practical hotels
            var practicalHotels = hotelInfoBusinessLogic.HotelPracticalForCity(cityId);
            ViewData["PracticalHotels"] = practicalHotels;

            // 推荐景区
            var sceneryinfos = ticketInfoBusinessLoigic.GetSceneryInfoByHotelCityName(cityName);
            ViewData["SceneryInHotelCity"] = sceneryinfos;

            return View("~/Areas/Travel/Views/JiuDian/Query.cshtml");
        }

        

        public PartialViewResult MostPracticalHotels()
        {
            var hotCities = hotelCityBusinessLogic.HotelCityDetailInfosGet().Where(u => u.IsHotCity == 1).ToList();
            var hotelinfos = hotelInfoBusinessLogic.HotelCheapMost();
            var data = Tuple.Create<List<HotelPrimaryInfo>, List<HotelCityDetailInfo>>(hotelinfos, hotCities);
            return PartialView(GetView("MostPracticalHotels"), data);
        }

        /// <summary>
        /// 热门城市酒店信息
        /// </summary>
        /// <returns></returns>
        public PartialViewResult HotHotels()
        {
            var hotCities = hotelCityBusinessLogic.HotelCityDetailInfosGet().Where(u => u.IsHotCity == 1).ToList();
            var hotelinfos = hotelInfoBusinessLogic.HotelMostPractical();
            var data = Tuple.Create<List<HotelPrimaryInfo>, List<HotelCityDetailInfo>>(hotelinfos, hotCities);
            return PartialView(GetView("HotHotels"), data);
        }

        public PartialViewResult HotelBrands()
        {
            var hotelBrands = hotelInfoBusinessLogic.HotelBrandDetailInfoGet();
            return PartialView(GetView("HotelBrands"), hotelBrands);
        }

        public PartialViewResult HotelsInSeason()
        {
            return PartialView(GetView("HotelsInSeason"));
        }

        public PartialViewResult HotelQuickSearch()
        {
            return PartialView(GetView("HotelQuickSearch"));
        }

        /// <summary>
        /// 酒店热门团购
        /// </summary>
        /// <returns></returns>
        public ActionResult HotelGroup()
        {
            Product_GetCallEntity tuanCall = new Product_GetCallEntity();
            tuanCall.CityID = 1;
            tuanCall.PageSize = 5;
            var rep = OTATuanServiceLogic.Product_Get(tuanCall);
            return View(GetView("HotelGroup"), rep.GroupProductInfoList);
        }

        [HttpPost]
        public JsonResult GetHotelRoomRateResult(int hotelid, DateTime startdate, DateTime endDate)
        {
            JsonViewResult<List<HotelRoomBookCheckResult>> jsonViewResult = new JsonViewResult<List<HotelRoomBookCheckResult>>() { Success = false };
            List<int> hotellist = new List<int>() { hotelid };
            var roomrates = OTAHotelServiceLogic.OTA_HotelRatePlan(hotellist, startdate, endDate);
            List<HotelRoomBookCheckResult> bookStates = new List<HotelRoomBookCheckResult>();
            HotelRoomBookCheckResult bookState;
            int days = (endDate - startdate).Days;
            for (int start = 0; start < days; start++)
            {
                bookState = new HotelRoomBookCheckResult();
                bookState.CheckInDate = startdate.AddDays(start).ToString("yyyy-MM-dd");
                bookStates.Add(bookState);
            }
            jsonViewResult.obj = bookStates;
            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult HotelRoomRateResult(int hotelid,DateTime startDate,DateTime endDate)
        {
            List<int> hotelIds = new List<int>() { hotelid };
            ViewBag.HotelId = hotelid;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            var hotelDescDto = hotelInfoBusinessLogic.GetHotelDescriptionByHotelId(hotelid);
            var roomRatesApiResult = OTAHotelServiceLogic.OTA_HotelRatePlan(hotelIds, startDate, endDate);

            List<RoomRatePlan> roomRates = roomRatesApiResult.HotelRatePlanList[0].RoomRatePlanList ?? new List<RoomRatePlan>();
            List<HotelRoomRateViewModel> roomRateViewModels = new List<HotelRoomRateViewModel>();

            if (roomRates.Count > 0)
            {
                var roominfos = hotelInfoBusinessLogic.HotelRoomInfoGetByHotelId(hotelid);
                var roomImgs = JsonConvert.DeserializeObject<List<MultimediaImgDescription>>(hotelDescDto.HotelDescription.MediaItems);
                HotelRoomRateViewModel viewModel;
                HotelRoomInfo roominfo;
                RoomRate rate;
                List<MultimediaImgDescription> imgDescriptions;
                foreach (var rp in roomRates)
                {
                    roominfo = roominfos.Where(u => u.RoomTypeCode == rp.HotelRoomCode).SingleOrDefault();
                    if (roominfo == null)
                    {
                        continue;
                    }
                    rate = rp.RoomRateList != null && rp.RoomRateList.Count > 0 ? rp.RoomRateList[0] : null;

                    viewModel = new HotelRoomRateViewModel();
                    viewModel.BedTypeCode = "0";

                    if (rate != null)
                    {
                        viewModel.NumberOfBreakfast = rate.NumberOfBreakfast;
                        viewModel.Date = rate.StartTime;
                        viewModel.HoteId = hotelid;
                        viewModel.Internet = "";
                        viewModel.Policy = "";
                        viewModel.BedTypeCode = roominfo.BedTypeCode;
                        viewModel.AmountBeforeTax = (int)rate.AmountBeforeTax;
                        viewModel.RoomTypeCode = rp.HotelRoomCode;
                        viewModel.RoomTypeName = roominfo.RoomTypeName;
                        viewModel.CancelAmount = (int)rate.CancelAmount;
                        viewModel.Floor = roominfo.Floor;
                        viewModel.RoomSize = roominfo.RoomSize;
                        viewModel.StandardOccupancy = roominfo.StandardOccupancy;
                        viewModel.RateCategoryCode = rp.RatePlanCategory;

                        imgDescriptions = roomImgs.Where(u => u.Caption == viewModel.RoomTypeName).ToList();
                        if (imgDescriptions != null && imgDescriptions.Count > 1)
                        {
                            viewModel.BigImg = imgDescriptions[0].Url;
                            viewModel.SmallImage = imgDescriptions[0].Url.Replace("_500_412", "_300_225");
                        }
                        else
                        {
                            viewModel.BigImg = roomImgs[0].Url;
                            viewModel.BigImg = roomImgs[0].Url.Replace("_500_412", "_300_225");
                        }
                        roomRateViewModels.Add(viewModel);
                    }
                }
            }
            ViewBag.RatePlans = roomRateViewModels;
            return View(GetView("HotelRoomRateResult"));
        }

        [HttpGet]
        public ActionResult HotelSearchList(int cityid,string keywords="")
        {
            var cityinfo=hotelCityBusinessLogic.HotelCityDetailInfoGetByCityID(cityid);
            ViewBag.CityID = cityid;
            ViewBag.CityName = cityinfo.CityName;

            ViewBag.StartData = DateTime.Now;
            ViewBag.EndDate = DateTime.Now.AddDays(1);

            // map
            var zhunaCityInfo = zhunaHotelBusinessLogic.GetZhunaCityInfoByCtripCityId(cityinfo.CityID);
            CityMapInfo citymap = new CityMapInfo();
            citymap.CityName = cityinfo.CityName;
            citymap.Lat = zhunaCityInfo.baidu_lat;
            citymap.Lng = zhunaCityInfo.baidu_lng;

            ViewBag.CityMap = citymap; 


            string title = string.Format("{0}{1}酒店,{0}{1}酒店预订,{0}{1}宾馆住宿推荐【卓家客栈】", cityinfo.CityName,keywords);

            string seokeywords = string.Format("{0}{1}酒店,{0}{1}酒店预订,{0}{1}酒店价格查询,{0}{1}宾馆住宿推荐,网上订{0}{1}酒店,卓家客栈酒店", cityinfo.CityName,keywords);
            string descriptions = string.Format("找到满意的{0}酒店,卓家客栈酒店为您提供{0}酒店预订,查询{0}酒店价格,推荐优质的{0}宾馆住宿,查看{0}酒店房间图片,酒店地址电话等信息.网上订{0}酒店就选卓家客栈,享受可订保证", cityinfo.CityName);

            SetPageSEO(title,seokeywords,descriptions);

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now.AddDays(1);

            HotelInfoQuery search = new HotelInfoQuery();
            search.CityId = cityid;
            search.StartDate = start;
            search.EndDate = end;
            search.PageIndex = 1;
            search.PageSize = 20;
            search.KeyWords = keywords;
            search.CityName = cityinfo.CityName;
            ViewData["QueryCondition"] = search;

            var locations = hotelInfoBusinessLogic.GetLocationInfoByCityID(cityid);
            ViewBag.Locations = locations;
            var refPoints = hotelInfoBusinessLogic.GetRefPointsByCityID(cityid);
            var areaInfo = hotelInfoBusinessLogic.GetCityAreaInfoByCityId(cityid);
            ViewBag.AreaInfos = areaInfo;

            var hotelBrands = hotelCityBusinessLogic.HotelBrandSearchRecommends();
            ViewBag.HotelBrands = hotelBrands;

            var hotelinfos2 = hotelInfoBusinessLogic.HotelRoomInfoQuery(search);
            if (hotelinfos2 == null)
            {
                search.TotalRecords = 0;
            }
            else
            {
                search.TotalRecords = hotelinfos2.Item3;
            }
            ViewBag.HotelInfos = hotelinfos2.Item1;
            ViewBag.HotelRoomPrices = hotelinfos2.Item2;

            // bind search form
            ViewBag.StartData = start.ToString("yyyy-MM-dd");
            ViewBag.EndDate = end.ToString("yyyy-MM-dd");

            // practical hotels
            var practicalHotels = hotelInfoBusinessLogic.HotelPracticalForCity(cityid);
            ViewData["PracticalHotels"] = practicalHotels;

            // 推荐景区
            var sceneryinfos = ticketInfoBusinessLoigic.GetSceneryInfoByHotelCityName(cityinfo.CityName);
            ViewData["SceneryInHotelCity"] = sceneryinfos;
            return View(GetView("HotelSearchList"));
        }

        [HttpPost]
        public ActionResult HotelSearchList(int cityid, DateTime HotelInRoomDate, DateTime HotelLeaveRoomDate, string HotelStarLevel, string HotelPriceLevel, string LocationID, string HotelBrandID, string Page="1", string searchkeywords="",int Order=0,int minPrice = 1, int maxPrice = 99999)
        {
            var cityinfo = hotelCityBusinessLogic.HotelCityDetailInfoGetByCityID(cityid);
            ViewBag.CityID = cityid;
            ViewBag.CityName = cityinfo.CityName;
            string title = string.Format("{0}酒店,{0}酒店预订,{0}宾馆住宿推荐【卓家客栈】", cityinfo.CityName);

            string seokeywords = string.Format("{0}酒店,{0}酒店预订,{0}酒店价格查询,{0}宾馆住宿推荐,网上订{0}酒店,卓家客栈酒店", cityinfo.CityName);
            string seodescriptions = string.Format("找到满意的{0}酒店,卓家客栈酒店为您提供{0}酒店预订,查询{0}酒店价格,推荐优质的{0}宾馆住宿,查看{0}酒店房间图片,酒店地址电话等信息.网上订{0}酒店就选卓家客栈,享受可订保证", cityinfo.CityName);

            SetPageSEO(title, seokeywords, seodescriptions);

            //DateTime start = DateTime.Now;
            //DateTime end = DateTime.Now.AddDays(1);

            var zhunaCityInfo = zhunaHotelBusinessLogic.GetZhunaCityInfoByCtripCityId(cityinfo.CityID);
            CityMapInfo citymap = new CityMapInfo();
            citymap.CityName = cityinfo.CityName;
            citymap.Lat = zhunaCityInfo.baidu_lat;
            citymap.Lng = zhunaCityInfo.baidu_lng;
            ViewBag.CityMap = citymap; 

            HotelInfoQuery search = new HotelInfoQuery();
            search.CityId = cityid;
            search.StartDate = HotelInRoomDate;
            search.EndDate = HotelLeaveRoomDate;
            search.PageIndex = Page.ToInt32();
            search.PageSize = 10;
            search.KeyWords = searchkeywords;
            search.HotelBrandID = HotelBrandID;
            search.MinPrice = HotelPriceLevel.Split('-')[0].ToInt32();
            search.MaxPrice = HotelPriceLevel.Split('-')[1].ToInt32();
            search.LocationID = LocationID.ToInt32();
            search.CityName = cityinfo.CityName;

            ViewData["QueryCondition"] = search;

            var locations = hotelInfoBusinessLogic.GetLocationInfoByCityID(cityid);
            ViewBag.Locations = locations;
            var refPoints = hotelInfoBusinessLogic.GetRefPointsByCityID(cityid);
            // ??
            var areaInfo = hotelInfoBusinessLogic.GetCityAreaInfoByCityId(cityid);
            ViewBag.AreaInfos = areaInfo;

            var hotelBrands = hotelCityBusinessLogic.HotelBrandSearchRecommends();
            ViewBag.HotelBrands = hotelBrands;

            var hotelinfos2 = hotelInfoBusinessLogic.HotelRoomInfoQuery(search);
            if (hotelinfos2 == null)
            {
                search.TotalRecords = 0;
            }
            else
            {
                search.TotalRecords = hotelinfos2.Item3;
            }
            ViewBag.HotelInfos = hotelinfos2.Item1;
            ViewBag.HotelRoomPrices = hotelinfos2.Item2;

            // bind search form
            ViewBag.StartData = HotelInRoomDate;
            ViewBag.EndDate = HotelLeaveRoomDate;

            


            // practical hotels
            var practicalHotels = hotelInfoBusinessLogic.HotelPracticalForCity(cityid);
            ViewData["PracticalHotels"] = practicalHotels;

            // 推荐景区
            var sceneryinfos = ticketInfoBusinessLoigic.GetSceneryInfoByHotelCityName(cityinfo.CityName);
            ViewData["SceneryInHotelCity"] = sceneryinfos;
            return View(GetView("HotelSearchList"));
        }

        [HttpPost]
        public ActionResult HotelSearchResultList(int cityid, DateTime HotelInRoomDate, DateTime HotelLeaveRoomDate, string HotelStarLevel, string HotelPriceLevel, string LocationID, string HotelBrandID = "0", string Page = "1", int areaid = 0, string AreaName = "", string searchkeywords = "", int Order = 0, int minPrice = 1, int maxPrice = 99999)
        {
            //var cityinfo = hotelCityBusinessLogic.HotelCityDetailInfoGetByCityID(cityid);
            //ViewBag.CityID = cityid;
            //ViewBag.CityName = cityinfo.CityName;
            //string title = string.Format("{0}酒店,{0}酒店预订,{0}宾馆住宿推荐【卓家客栈】", cityinfo.CityName);

            //string seokeywords = string.Format("{0}酒店,{0}酒店预订,{0}酒店价格查询,{0}宾馆住宿推荐,网上订{0}酒店,卓家客栈酒店", cityinfo.CityName);
            //string seodescriptions = string.Format("找到满意的{0}酒店,卓家客栈酒店为您提供{0}酒店预订,查询{0}酒店价格,推荐优质的{0}宾馆住宿,查看{0}酒店房间图片,酒店地址电话等信息.网上订{0}酒店就选卓家客栈,享受可订保证", cityinfo.CityName);

            //SetPageSEO(title, seokeywords, seodescriptions);

            //DateTime start = DateTime.Now;
            //DateTime end = DateTime.Now.AddDays(1);

            HotelInfoQuery search = new HotelInfoQuery();
            search.CityId = cityid;
            search.StartDate = HotelInRoomDate;
            search.EndDate = HotelLeaveRoomDate;
            search.PageIndex = Page.ToInt32();
            search.PageSize = 10;
            search.KeyWords = "";
            search.HotelBrandID = HotelBrandID;
            search.MinPrice = string.IsNullOrEmpty(HotelPriceLevel) ? 1 : HotelPriceLevel.Split('-')[0].ToInt32();
            search.MaxPrice = string.IsNullOrEmpty(HotelPriceLevel)?9999:HotelPriceLevel.Split('-')[1].ToInt32();
            search.LocationID = LocationID.ToInt32();
            search.HotelPrice = HotelPriceLevel;
            search.OrderType = Order;
            search.AreaId = areaid;
            search.KeyWords = AreaName;
            ViewData["QueryCondition"] = search;

            //var locations = hotelInfoBusinessLogic.GetLocationInfoByCityID(cityid);
            //ViewBag.Locations = locations;
            //var refPoints = hotelInfoBusinessLogic.GetRefPointsByCityID(cityid);
            //// ??
            //var areaInfo = hotelInfoBusinessLogic.GetCityAreaInfoByCityId(cityid);
            //ViewBag.AreaInfos = areaInfo;

            //var hotelBrands = hotelCityBusinessLogic.HotelBrandSearchRecommends();
            //ViewBag.HotelBrands = hotelBrands;

            var hotelinfos2 = hotelInfoBusinessLogic.HotelRoomInfoQuery(search);
            if (hotelinfos2 == null)
            {
                search.TotalRecords = 0;
            }
            else
            {
                search.TotalRecords = hotelinfos2.Item3;
            }
            ViewBag.HotelInfos = hotelinfos2.Item1;
            ViewBag.HotelRoomPrices = hotelinfos2.Item2;

            // bind search form
            ViewBag.StartData = HotelInRoomDate;
            ViewBag.EndDate = HotelLeaveRoomDate;

            // practical hotels
            //var practicalHotels = hotelInfoBusinessLogic.HotelPracticalForCity(cityid);
            //ViewData["PracticalHotels"] = practicalHotels;

            // 推荐景区
            //var sceneryinfos = ticketInfoBusinessLoigic.GetSceneryInfoByHotelCityName(cityinfo.CityName);
            //ViewData["SceneryInHotelCity"] = sceneryinfos;
            return View(GetView("HotelSearchResult"));
        }

        [HttpGet]
        public ActionResult HotelBrandInCity(int cityid,int brandId)
        {
            var cityinfo = hotelCityBusinessLogic.HotelCityDetailInfoGetByCityID(cityid);
            ViewBag.CityID = cityid;
            ViewBag.CityName = cityinfo.CityName;

            var brand = hotelInfoBusinessLogic.HotelBrandsGet(brandId);

            string keywords = string.Format("{0}{1}连锁酒店,{0} {1}快捷酒店, {0}{1}连锁酒店预订", cityinfo.CityName, brand.BrandName);

            string title = string.Format("{0}{1}连锁酒店预定，{0}{1}连锁酒店预定电话，{0}{1}快捷酒店官网联合预订 - 卓家客栈", cityinfo.CityName, brand.BrandName);
            string descriptions = string.Format("找到满意的{0}酒店,卓家客栈酒店为您提供{0}酒店预订,查询{0}酒店价格,推荐优质的{0}宾馆住宿,查看{0}酒店房间图片,酒店地址电话等信息.网上订{0}酒店就选卓家客栈,享受可订保证", cityinfo.CityName);

            SetPageSEO(title, keywords, descriptions);

            var zhunaCityInfo = zhunaHotelBusinessLogic.GetZhunaCityInfoByCtripCityId(cityinfo.CityID);
            CityMapInfo citymap = new CityMapInfo();
            citymap.CityName = cityinfo.CityName;
            citymap.Lat = zhunaCityInfo.baidu_lat;
            citymap.Lng = zhunaCityInfo.baidu_lng;
            ViewBag.CityMap = citymap; 

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now.AddDays(1);

            HotelInfoQuery search = new HotelInfoQuery();
            search.CityId = cityid;
            search.StartDate = start;
            search.EndDate = end;
            search.PageIndex = 1;
            search.PageSize = 20;
            search.KeyWords = "";
            search.HotelBrandID = brandId.ToString();

            ViewData["QueryCondition"] = search;

            var locations = hotelInfoBusinessLogic.GetLocationInfoByCityID(cityid);
            ViewBag.Locations = locations;
            var refPoints = hotelInfoBusinessLogic.GetRefPointsByCityID(cityid);
            var areaInfo = hotelInfoBusinessLogic.GetCityAreaInfoByCityId(cityid);
            ViewBag.AreaInfos = areaInfo;

            var hotelBrands = hotelCityBusinessLogic.HotelBrandSearchRecommends();
            ViewBag.HotelBrands = hotelBrands;

            var hotelinfos2 = hotelInfoBusinessLogic.HotelRoomInfoQuery(search);
            if (hotelinfos2 == null)
            {
                search.TotalRecords = 0;
            }
            else
            {
                search.TotalRecords = hotelinfos2.Item3;
            }
            ViewBag.HotelInfos = hotelinfos2.Item1;
            ViewBag.HotelRoomPrices = hotelinfos2.Item2;

            // bind search form
            ViewBag.StartData = start.ToString("yyyy-MM-dd");
            ViewBag.EndDate = end.ToString("yyyy-MM-dd");

            // practical hotels
            var practicalHotels = hotelInfoBusinessLogic.HotelPracticalForCity(cityid);
            ViewData["PracticalHotels"] = practicalHotels;

            // 推荐景区
            var sceneryinfos = ticketInfoBusinessLoigic.GetSceneryInfoByHotelCityName(cityinfo.CityName);
            ViewData["SceneryInHotelCity"] = sceneryinfos;

            return View(GetView("HotelSearchList"));
        }

       
    }
}