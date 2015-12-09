using System.Web.Mvc;

namespace Travelling.Web.Controllers.Travel
{
    /// <summary>
    /// 用户订单查询页面
    /// </summary>
    public class DingDanController : BaseController
    {
        /// <summary>
        /// 订单查询页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // query
            return View();
        }
    }
}