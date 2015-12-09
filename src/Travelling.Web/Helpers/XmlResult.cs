using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Travelling.Web.Helpers
{
    public class XmlResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {

            if (context == null)
            {
                throw new ArgumentNullException("context is null");
            }

            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "text/xml";

            response.Write(responseContent);
        }

        private readonly string responseContent;
        public XmlResult(string rep)
        {
            this.responseContent = rep;
        }
    }
}
