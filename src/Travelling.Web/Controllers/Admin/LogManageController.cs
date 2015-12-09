using System.Web.Mvc;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Admin;

namespace Travelling.Web.Controllers.Admin
{
    public class LogManageController : BaseAdminController
    {
        private readonly ISystemLogBusinessLogic logBusiness;
        private readonly string BaseViewPath = "~/Areas/Admin/Views/LogManage/{0}.cshtml";

        public LogManageController(ISystemLogBusinessLogic systemLogBusiness)
        {
            logBusiness = systemLogBusiness;
        }

        public ActionResult OperactingLog()
        {
            return View(string.Format(BaseViewPath, "OperactingLog"));
        }

        public ActionResult OperactingLogSearchResult(OperatingLogSearchModel search)
        {
            var pageViewResult = logBusiness.OperatingLogPageResult(search);
            return View(string.Format(BaseViewPath, "OperactingLogSearchResult"), pageViewResult);
        }
    }
}