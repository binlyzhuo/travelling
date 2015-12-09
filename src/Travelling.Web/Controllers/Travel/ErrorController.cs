using System.Web.Mvc;

namespace Travelling.Web.Controllers.Travel
{
    public class ErrorController : BaseController
    {
        public ErrorController()
        {
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}