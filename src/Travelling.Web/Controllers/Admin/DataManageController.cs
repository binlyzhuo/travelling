using System.Web.Mvc;

namespace Travelling.Web.Controllers.Admin
{
    public class DataManageController : BaseAdminController
    {
        private readonly string BaseViewPath = "~/Areas/Admin/Views/DataMannage/{0}.cshtml";

        public ActionResult DataCheck()
        {
            return View(string.Format(BaseViewPath, "DataCheck"));
        }
    }
}