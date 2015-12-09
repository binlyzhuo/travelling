using System;
using System.Web.Mvc;
using System.Configuration;

namespace Travelling.UI.Areas.Admin
{
    /// <summary>
    /// 管理员后台管理
    /// </summary>
    public class AdminAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// 默认Area
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        /// <summary>
        /// 注册Area
        /// </summary>
        /// <param name="context"></param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            bool isAdminApp = Convert.ToBoolean(ConfigurationManager.AppSettings["IsAdminApp"]);
            if(isAdminApp)
            {
                context.MapRoute(
                "Admin_default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "Travelling.Web.Controllers.Admin" }
            );
            }
            
        }
    }
}
