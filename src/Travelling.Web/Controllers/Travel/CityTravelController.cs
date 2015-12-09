using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Travelling.Web.Controllers.Travel
{
    public class CityTravelController:BaseController
    {
       public ActionResult Index()
        {
            return View();
        }
    }
}
