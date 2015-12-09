using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Travelling.Web.Controllers.Travel
{
    public class GuangGaoController:BaseController
    {
        private string GetView(string viewName)
        {
            return string.Format("~/Areas/Travel/Views/GuangGao/{0}.cshtml", viewName);
        }
        public ActionResult Index()
        {
            return View(GetView("Index"));
        }
    }
}
