using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Web.Mvc;
using Travelling.ViewModel;
using Travelling.Caching;
using Travelling.Web.Helpers;

namespace Travelling.Web.Controllers.Travel
{
    public class SettingCachingController : Controller
    {
        public SettingCachingController()
        {

        }

        [HttpPost]
        public XmlResult CacheReset(ControllerContext context)
        {
            Stream stream = Request.InputStream;
            string reqContent = "";
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                reqContent = reader.ReadToEnd();
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(reqContent);
            string token = xmlDoc.SelectSingleNode("request/token").InnerText;
            string action = xmlDoc.SelectSingleNode("request/action").InnerText;
            if(action=="allcache")
            {
                CacheServiceFactory.Instance().ClearAllCache();
            }
            else
            {
                CacheServiceFactory.Instance().ClearCacheItem(action);
            }
            

            StringBuilder repContent = new StringBuilder();
            repContent.AppendFormat("<response><code>0</code><remark>ok</remark></response>");

            return new XmlResult(repContent.ToString());
        }
    }
}