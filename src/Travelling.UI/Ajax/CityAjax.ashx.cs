using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travelling.UI.Ajax
{
    /// <summary>
    /// Summary description for CityAjax
    /// </summary>
    public class CityAjax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}