using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace Travelling.Web.Controllers.Travel
{
    public class MapController:BaseController
    {
        private string getView(string viewName)
        {
            return string.Format("~/Areas/Travel/Views/Map/{0}.cshtml", viewName);
        }

        [HttpGet]
        public ActionResult AMap(string lat,string lng,string name)
        {
            Tuple<string, string, string> positions = Tuple.Create<string, string, string>(lng, lat, name);
            string gaodeMapKey = ConfigurationManager.AppSettings["GaoDeMapKey"];
            ViewBag.GaoDeMapKey = gaodeMapKey;
            return View(getView("AMap"), positions);
        }

        [HttpGet]
        public ActionResult BaiduMap(string lat, string lng, string name)
        {
            Tuple<string, string, string> positions = Tuple.Create<string, string, string>(lng, lat, name);
            //string gaodeMapKey = ConfigurationManager.AppSettings["GaoDeMapKey"];
            //ViewBag.GaoDeMapKey = gaodeMapKey;
            return View(getView("BaiduMap"), positions);
        }
    }
}
