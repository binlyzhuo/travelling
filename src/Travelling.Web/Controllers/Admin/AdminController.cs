using System.Web.Mvc;
using Travelling.TravelInterface.Repository;

namespace Travelling.Web.Controllers.Admin
{
    /// <summary>
    /// 默认
    /// </summary>
    public class AdminController : BaseAdminController
    {
        private readonly IAccountBusinessLogic accountInfoBusiness;

        public AdminController(IAccountBusinessLogic accountBusiness)
        {
            this.accountInfoBusiness = accountBusiness;
        }

        //[Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["loginaccount"] = null;
            return RedirectToAction("Login", "Home");
        }
    }
}