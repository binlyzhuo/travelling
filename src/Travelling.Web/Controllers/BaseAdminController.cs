using Travelling.ViewModel.Dto.User;
using Travelling.Web.Filter;
using Travelling.Web.Session;

namespace Travelling.Web.Controllers
{
    /// <summary>
    /// 管理后台BaseController
    /// </summary>
    [AdminAuthorize]
    public class BaseAdminController : BaseController
    {
        protected AccountInfo accountinfo;

        public BaseAdminController()
        {
            //if (Session["loginaccount"]==null)
            //{
            //    if (accountinfo == null)
            //    {
            //        Response.Redirect("/Admin/Login");
            //    }
            //}
            //accountinfo = Session["loginaccount"] as AccountInfo;
            //if (accountinfo == null)
            //{
            //    Response.Redirect("/Admin/Login");
            //}
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            accountinfo = SessionStore.GetInstance().GetSession(SessionKey.AccountInfo);
            //if(accountinfo==null)
            //{
            //    //Response.Redirect("/Admin/Login");
            //}

            ViewBag.AccountInfo = accountinfo;
            ////if (accountinfo == null)
            ////{
            ////    Response.Redirect("/Admin/Login");
            ////}
        }
    }
}