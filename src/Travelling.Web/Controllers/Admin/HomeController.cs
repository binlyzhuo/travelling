using System.Web.Mvc;
using System.Web.Security;
using Travelling.FrameWork;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Admin;
using Travelling.Web.Helpers;
using Travelling.Web.Session;

namespace Travelling.Web.Controllers.Admin
{
    public class HomeController : BaseController
    {
        private readonly IAccountBusinessLogic accountInfoBusiness;

        public HomeController(IAccountBusinessLogic accountBusiness)
        {
            this.accountInfoBusiness = accountBusiness;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            SetPageSEO("管理员登录");
            LoginModel loginModel = new LoginModel();
            return View(loginModel);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            SetPageSEO("管理员登录");
            string validateCode = Session["ValidateCode"] as string;
            if (loginModel.ValidateCode != validateCode)
            {
                ViewBag.ErrorMsg = "验证码错误";
                return Login();
            }
            loginModel.Password = Md5.GetMd5(loginModel.Password);
            var accountinfo = accountInfoBusiness.GetAccountInfo(loginModel.UserName, loginModel.Password);
            if (accountinfo == null)
            {
                ViewBag.ErrorMsg = "用户名或者密码不正确";
                return Login();
            }
            //SetLoginInfo(accountinfo);
            //Session["loginaccount"] = accountinfo;
            if (loginModel.RememberMe)
            {
                FormsAuthentication.SetAuthCookie(accountinfo.Name, true);
            }
            SessionStore.GetInstance().SaveSession(SessionKey.AccountInfo, accountinfo);
            return RedirectToAction("Index", "Admin");
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
    }
}