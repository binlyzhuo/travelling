using System;
using System.Web.Mvc;
using Travelling.ViewModel.Dto.User;
using Travelling.Web.Session;

namespace Travelling.Web.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AdminAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            AccountInfo accountInfo = SessionStore.GetInstance().GetSession(SessionKey.AccountInfo);
            if (accountInfo == null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");
            }
        }
    }
}