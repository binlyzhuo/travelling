using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace Travelling.FrameWork
{
    public class Md5
    {
        public static string GetMd5(string source)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile("","md5");
        }
    }
}
