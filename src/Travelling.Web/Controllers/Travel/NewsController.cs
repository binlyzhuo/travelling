using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Admin;

namespace Travelling.Web.Controllers.Travel
{
    public class NewsController:BaseController
    {

        private readonly ISettingBusinessLogic settingBusinessLogic;

        private string GetView(string viewName)
        {
            return string.Format("~/Areas/Travel/Views/News/{0}.cshtml", viewName);
        }

        public NewsController(ISettingBusinessLogic settingLogic)
        {
            this.settingBusinessLogic = settingLogic;
        }

        public ActionResult Index()
        {
            string title = "旅游资讯_卓家客栈";
            string keywords = "旅游资讯";
            string descriptions = "卓家客栈资讯网：国内专业全面的旅游媒体平台，为网友们提供旅游行业资讯，出境游资讯，各旅行社资讯，景区资讯，酒店资讯，交通资讯以及旅游展会资讯和考试资讯等信息。";
            SetPageSEO(title,keywords,descriptions);
            ArticleInfoSearchModel search = new ArticleInfoSearchModel();
            var news = settingBusinessLogic.ArticleInfoPageResult(search);

            return View(GetView("Index"), news);
        }

        [HttpGet]
        public ActionResult NewsInfo(int newsid)
        {
            var articleDto = settingBusinessLogic.ArticleInfoGetByID(newsid);
            string title = articleDto.Title;
            string keywords = articleDto.Tag;
            SetPageSEO(title, keywords,title);
            var nextlast = settingBusinessLogic.GetNextAndLastArticle(newsid);
            ViewBag.NextAndLast = nextlast;
            return View(GetView("NewsInfo"), articleDto);
        }

        public ActionResult LastestNews()
        {
            ArticleInfoSearchModel search = new ArticleInfoSearchModel();
            var news = settingBusinessLogic.ArticleInfoPageResult(search);

            return View(GetView("LastestNews"), news.Items);
        }
        
    }
}
