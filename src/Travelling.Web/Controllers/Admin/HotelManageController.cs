using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Travelling.FrameWork;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.Web.Application;

namespace Travelling.Web.Controllers.Admin
{
    /// <summary>
    /// 酒店信息管理
    /// </summary>
    public class HotelManageController : BaseAdminController
    {
        private readonly IHotelManageBusinessLogic hotelManageBusiness;
        private readonly string BaseViewPath = "~/Areas/Admin/Views/HotelManage/{0}.cshtml";

        private string GetView(string viewName)
        {
            return string.Format(BaseViewPath, viewName);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hotelManageBusinessLogic"></param>
        public HotelManageController(IHotelManageBusinessLogic hotelManageBusinessLogic)
        {
            this.hotelManageBusiness = hotelManageBusinessLogic;
        }

        /// <summary>
        /// 城市信息
        /// </summary>
        /// <returns></returns>
        public ActionResult CityInfo(int page = 1)
        {
            HotelCityDetailSearchModel search = new HotelCityDetailSearchModel();

            var pageObject = hotelManageBusiness.HotelCityDetailSearch(search);

            var provinces = hotelManageBusiness.GetHotelProvinces();
            ViewBag.HotelProvinces = provinces;

            //var cityinfoPageList = new StaticPagedList<HotelCityDetailInfo>(pageObject.Items, search.PageIndex, (int)search.PageSize, (int)pageObject.TotalCount);
            return View("~/Areas/Admin/Views/HotelManage/CityInfo.cshtml", pageObject);
        }

        /// <summary>
        /// 酒店城市详细信息查询结果
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CityInfoSearchResult(HotelCityDetailSearchModel search)
        {
            var pageObject = hotelManageBusiness.HotelCityDetailSearch(search);

            return PartialView("~/Areas/Admin/Views/HotelManage/CityInfoSearchResult.cshtml", pageObject);
        }

        [HttpPost]
        public JsonResult SetCityInfoStateAction(string cityids, int type, string action)
        {
            JsonViewResult jsonViewResult = new JsonViewResult() { Success = false };
            List<int> cityIdList = cityids.TrimEnd(',').Split(',').Select(u =>
            {
                return u.ToInt32();
            }).ToList();
            bool updateResult = false;
            switch (action.ToLower())
            {
                case "rdcity":
                    updateResult = hotelManageBusiness.UpdateRecommendState(cityIdList, type);

                    break;

                case "hotcity":
                    updateResult = hotelManageBusiness.UpdateHotCityState(cityIdList, type);
                    break;

                case "searchcity":
                    updateResult = hotelManageBusiness.UpdateSearchCityState(cityIdList, type);
                    break;
            }
            jsonViewResult.Success = updateResult;

            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SetHotCityStateAction(string cityids, int type)
        {
            List<int> cityIdList = cityids.TrimEnd(',').Split(',').Select(u =>
            {
                return u.ToInt32();
            }).ToList();
            bool updateResult = hotelManageBusiness.UpdateHotCityState(cityIdList, type);
            return View();
        }

        public ActionResult BrandInfo(int pageindex = 1)
        {
            HotelBrandInfoSearchModel brandSearch = new HotelBrandInfoSearchModel();
            brandSearch.PageSize = 10;
            brandSearch.PageIndex = pageindex;
            var pageViewResult = hotelManageBusiness.HotelBrandInfosSearch(brandSearch);
            return View("~/Areas/Admin/Views/HotelManage/BrandInfo.cshtml");
        }

        [HttpPost]
        public ActionResult BrandInfoSearchResult(HotelBrandInfoSearchModel brandSearch)
        {
            brandSearch.PageSize = 10;
            var pageViewResult = hotelManageBusiness.HotelBrandInfosSearch(brandSearch);
            return View(pageViewResult);
        }

        public ActionResult OrderInfo()
        {
            return View("~/Areas/Admin/Views/HotelManage/OrderInfo.cshtml");
        }

        [HttpPost]
        public ActionResult OrderInfoSearchResult(HotelOrderInfoSearchModel search)
        {
            var pageViewResult = hotelManageBusiness.HotelBookingOrderGetPageResult(search);
            return View(GetView("OrderInfoResult"), pageViewResult);
        }

        public ActionResult CityInfoEdit(int cityid)
        {
            var cityinfo = hotelManageBusiness.GetHotelCityInfo(cityid);
            return View(cityinfo);
        }

        [HttpPost]
        public JsonResult CityInfoEdit(HotelCityDetailInfo cityInfo)
        {
            JsonViewResult jsonViewResult = new JsonViewResult() { Success = false };
            jsonViewResult.Success = hotelManageBusiness.UpdateCityInfo(cityInfo);
            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetCityInfo(int cityId)
        {
            var cityinfo = hotelManageBusiness.GetHotelCityInfo(cityId);
            return View("~/Areas/Admin/Views/HotelManage/CityInfoEdit.cshtml", cityinfo);
        }

        public ActionResult BrandInfoEdit(int brandId = 0)
        {
            var brandinfo = hotelManageBusiness.GetHotelBrandDetailInfo(brandId);
            return View(brandinfo);
        }

        [HttpPost]
        public JsonResult BrandInfoEdit(HotelBrandDetailInfo brandInfo)
        {
            JsonViewResult jsonViewResult = new JsonViewResult() { Success = false };

            string tempImg = HotelInfoConfig.HotelBrandTempImgPath + brandInfo.BrandImg;
            string saveImg = HotelInfoConfig.HotelBrandImgPath + brandInfo.BrandImg;

            if (System.IO.File.Exists(Server.MapPath(tempImg)))
            {
                System.IO.File.Move(Server.MapPath(tempImg), Server.MapPath(saveImg));
                System.IO.File.Delete(Server.MapPath(tempImg));
            }

            bool updateResult = hotelManageBusiness.UpdateHotelBrandInfo(brandInfo);
            jsonViewResult.Success = updateResult;
            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetHotelBrandInfo(int brandId)
        {
            var brandinfo = hotelManageBusiness.GetHotelBrandDetailInfo(brandId);

            return View("~/Areas/Admin/Views/HotelManage/BrandInfoEdit.cshtml", brandinfo);//BrandInfoEdit
        }

        [HttpPost]
        public JsonResult UploadBrandImg(int brandid)
        {
            var uploadFile = Request.Files[0];
            AjaxUploadFileViewResult jsonViewResult = new AjaxUploadFileViewResult() { Success = false };
            jsonViewResult.FileName = uploadFile.FileName;
            Guid guid = Guid.NewGuid();
            string newName = guid.ToString() + "." + uploadFile.FileName.GetFileExtends();
            jsonViewResult.Success = true;
            string fullPath = Server.MapPath(HotelInfoConfig.HotelBrandTempImgPath);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            string fullName = fullPath + newName;
            jsonViewResult.TempFile = HotelInfoConfig.HotelBrandTempImgPath + newName;
            jsonViewResult.Message = "ok";
            jsonViewResult.FileExtend = uploadFile.FileName.GetFileExtends();
            jsonViewResult.FileName = newName;
            uploadFile.SaveAs(fullName);
            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult HotelOrderCancel(string orderno)
        {
            JsonViewResult jsonViewResult = new JsonViewResult();
            jsonViewResult.Success = hotelManageBusiness.HotelBookOrderCancel(orderno);
            return GetJsonResult(jsonViewResult);
        }
    }
}