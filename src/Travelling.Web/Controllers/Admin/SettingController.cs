using System;
using System.Text;
using System.Web.Mvc;
using Travelling.Caching;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.Setting;
using System.Configuration;
using Travelling.FrameWork;
using Travelling.CommonLibrary;
using System.Xml;

namespace Travelling.Web.Controllers.Admin
{
    public class SettingController : BaseAdminController
    {
        private readonly ISettingBusinessLogic settingBusiessLogic;
        private string baseViewPath = "~/Areas/Admin/Views/Setting/{0}.cshtml";

        private string GetViewPath(string viewName)
        {
            return string.Format(baseViewPath, viewName);
        }

        public SettingController(ISettingBusinessLogic settingBusiness)
        {
            this.settingBusiessLogic = settingBusiness;
        }

        public ActionResult FriendLinks()
        {
            return View(GetViewPath("FriendLinks"));
        }

        [HttpGet]
        public ActionResult FriendLinkEdit(int fid = 0)
        {
            if (fid > 0)
            {
                var item = settingBusiessLogic.FriendLinkGetById(fid);
                return View(GetViewPath("FriendLinkEdit"), item);
            }
            else
            {
                return View(GetViewPath("FriendLinkAdd"));
            }
        }

        [HttpPost]
        public JsonResult FriendLinkEdit(FriendLinkDto model)
        {
            JsonViewResult jsonViewResult = new JsonViewResult();
            if (model.ID > 0)
            {
                jsonViewResult.Success = settingBusiessLogic.FriendLinkUpdate(model);
            }
            else
            {
                model.AddDate = DateTime.Now;
                model.Creator = accountinfo.Name;
                jsonViewResult.Success = settingBusiessLogic.FriendLinkAdd(model);
            }

            return GetJsonResult(jsonViewResult);
        }

        public ActionResult FriendLinkSearchResult(FriendLinkSearchModel searchModel)
        {
            var pageViewResutl = settingBusiessLogic.FriendLinkGetPageResult(searchModel);
            return View(GetViewPath("FriendLinkSearchResult"), pageViewResutl);
        }

        [HttpPost]
        public JsonResult FriendLinkDelete(int fid)
        {
            JsonViewResult jsonViewResult = new JsonViewResult();
            jsonViewResult.Success = settingBusiessLogic.FriendLinkDelete(fid);
            return GetJsonResult(jsonViewResult);
        }

        public ActionResult CacheManage()
        {
            var cacheKeys = CacheObjectInfo.GetCacheKeysInfo();
            return View(GetViewPath("CacheManage"), cacheKeys);
        }

        [HttpPost]
        public JsonResult CacheReset(string key)
        {
            JsonViewResult jsonViewResult = new JsonViewResult();
            string postUrl = ConfigurationManager.AppSettings["CacheSettingUrl"];
            StringBuilder postData = new StringBuilder();
            postData.AppendFormat("<request><token>{0}</token><action>{1}</action></request>","123456",key);
            string repContent=HttpHelper.PostDataToServer(postUrl, postData.ToString());
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(repContent);
            jsonViewResult.Success = true;
            jsonViewResult.Message = "ok";
            LogHelper.Info(repContent);
            return GetJsonResult(jsonViewResult);
        }
    }
}