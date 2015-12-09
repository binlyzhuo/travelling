using System.Web.Mvc;

namespace Travelling.Web.Controllers.Travel
{
    /// <summary>
    /// 公共信息处理
    /// </summary>
    public class UtilityController : BaseController
    {
        private string GetView(string viewName)
        {
            return string.Format("~/Areas/Travel/Views/Utility/{0}.cshtml", viewName);
        }

        /// <summary>
        /// 500
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            return View(GetView("Error404"));
        }

        /// <summary>
        /// 404
        /// </summary>
        /// <returns></returns>
        public ActionResult PageNotFound()
        {
            return View(GetView("Error404"));
        }
    }
}