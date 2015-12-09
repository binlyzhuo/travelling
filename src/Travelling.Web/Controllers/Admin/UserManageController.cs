using System.Web.Mvc;
using Travelling.FrameWork;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Admin;

namespace Travelling.Web.Controllers.Admin
{
    public class UserManageController : BaseAdminController
    {
        private readonly string BaseViewPath = "~/Areas/Admin/Views/User/{0}.cshtml";
        private readonly IAccountBusinessLogic accountBusinessLogic;

        public UserManageController(IAccountBusinessLogic accountBusiness)
        {
            accountBusinessLogic = accountBusiness;
        }

        public ActionResult Profile()
        {
            return View(string.Format(BaseViewPath, "Profile"));
        }

        [HttpGet]
        public ActionResult UpdatePassword()
        {
            return View(string.Format(BaseViewPath, "UpdatePassword"));
        }

        [HttpPost]
        public ActionResult UpdatePassword(UserUpdatePasswordModel updateModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Msg = "信息填写错误";
                return View(string.Format(BaseViewPath, "UpdatePassword"));
            }

            if (updateModel.ConfirmPassword != updateModel.NewPassword)
            {
                ViewBag.Msg = "密码和确认密码不一致";
                return View(string.Format(BaseViewPath, "UpdatePassword"));
            }
            int uid = accountinfo.ID;

            accountinfo = accountBusinessLogic.GetAccountInfo(uid);
            if (Md5.GetMd5(updateModel.OldPassword) != accountinfo.Password)
            {
                ViewBag.Msg = "原密码不正确";
                return View(string.Format(BaseViewPath, "UpdatePassword"));
            }
            accountinfo.Password = Md5.GetMd5(updateModel.NewPassword);
            bool updateResult = accountBusinessLogic.UpdateAccountPassword(accountinfo);
            TempData["PwdUpdateResult"] = updateResult;
            ViewBag.Msg = updateResult ? "修改成功" : "修改失败";
            return RedirectToAction("UpdateResult", "UserManage");
        }

        public ActionResult UpdateResult()
        {
            bool updateResult = (bool)TempData["PwdUpdateResult"];
            TempData["PwdUpdateResult"] = updateResult;
            return View(string.Format(BaseViewPath, "UpdateResult"), updateResult);
        }
    }
}