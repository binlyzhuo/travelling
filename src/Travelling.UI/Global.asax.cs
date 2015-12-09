using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Travelling.CommonLibrary;
using Travelling.Web;
using StackExchange.Profiling;
using Travelling.Web.Application;
using StackExchange.Profiling.Mvc;
using Travelling.Web.Controllers.Travel;
namespace Travelling.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    /// <summary>
    /// 系统全局设置
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 系统启动事件
        /// </summary>
        protected void Application_Start()
        {
            DependencyResolver.SetResolver(new NInjectControllerFactory());
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Qiniu.Conf.Config.Init();
            //MiniProfiler.Start();

            LogHelper.LogConfig(Server.MapPath(@"~\App_Data\log4net.config"));

            AppGlobalSetting.Instance.LoadSetting();
        }

        /// <summary>
        /// 系统请求事件
        /// </summary>
        protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            {
                StackExchange.Profiling.MiniProfiler.Start();
            }
        }

        /// <summary>
        /// 系统结束请求事件
        /// </summary>
        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }

        /// <summary>
        /// 系统停止
        /// </summary>
        protected void Application_End()
        {
            //MiniProfiler..Stop();
        }

        protected void Application_Error(object sender, EventArgs e)
        {

            var ex = Server.GetLastError();
            LogHelper.Error(ex);
            var httpStatusCode = (ex is HttpException) ? (ex as HttpException).GetHttpCode() : 500;

            switch (httpStatusCode)
            {
                case 404:
                    Response.Redirect("/page404.html");
                    break;
                default:
                    Response.Redirect("/page404.html");
                    break;
            }

            
        }

        /// <summary>
        /// 会话开始事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_Start(object sender, EventArgs e)
        {

        }
    }
}