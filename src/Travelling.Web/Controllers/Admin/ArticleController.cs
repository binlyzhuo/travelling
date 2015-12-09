using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.Setting;

namespace Travelling.Web.Controllers.Admin
{
    public class ArticleController:BaseAdminController
    {
        private readonly ISettingBusinessLogic settingBusinessLogic; 
        private string getView(string viewName)
        {
            return string.Format("~/Areas/Admin/Views/Article/{0}.cshtml",viewName);
        }
        public ArticleController(ISettingBusinessLogic settingLogic)
        {
            this.settingBusinessLogic = settingLogic;
        }

        public ActionResult Index()
        {
            return View(getView("Index"));
        }

        public ActionResult ArticleList(ArticleInfoSearchModel search)
        {
            var pageViewResult = settingBusinessLogic.ArticleInfoPageResult(search);
            return View(getView("ArticleList"), pageViewResult);
        }

        [HttpGet]
        public ActionResult AddArticle()
        {
            return View(getView("AddArticle"));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddArticle(string title,string content,string tag,bool state,int articleType)
        {
            ArticleInfoDto article = new ArticleInfoDto();
            article.AddDate = DateTime.Now;
            article.Content = content;
            article.Title = title;
            article.Tag = tag;
            article.State = state ? 1 : 0;
            article.Type = articleType;
            article.UserID = accountinfo.ID;
            article.Author = accountinfo.Name;
            article.CityName = "";
            int articleId=settingBusinessLogic.AddArticleInfo(article);
            return View(getView("AddResult"), articleId);
        }

        public ActionResult AddResult(int articleId)
        {
            return View(getView("AddResult"));
        }

        [HttpGet]
        public ActionResult ArticleEdit(int articleId)
        {
            var articleDto = settingBusinessLogic.ArticleInfoGetByID(articleId);
            return View(getView("ArticleEdit"), articleDto);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ArticleEdit(int id,string title, string content, string tag, bool state, int articleType)
        {
            ArticleInfoDto articleDto = new ArticleInfoDto();
            articleDto.ID = id;
            articleDto.Title = title;
            articleDto.Content = content;
            articleDto.Tag = tag;
            articleDto.State = state ? 1 : 0;
            articleDto.Type = articleType;

            int updateResult = settingBusinessLogic.ArticleInfoUpdate(articleDto)?1:0;

            return View(getView("AddResult"), updateResult);
        }

        public ActionResult ArticleDelete(int articleId)
        {
            int deleteResult = settingBusinessLogic.ArticleDelete(articleId)?1:0;
            return View(getView("AddResult"), deleteResult);
        }
    }
}
