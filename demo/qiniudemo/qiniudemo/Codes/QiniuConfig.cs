using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qiniu.Conf;
using System.Configuration;

namespace qiniudemo.Codes
{
    public class QiniuConfig
    {
        static QiniuConfig()
        {
            Qiniu.Conf.Config.ACCESS_KEY = ConfigurationManager.AppSettings["ACCESS_KEY"];
            Qiniu.Conf.Config.SECRET_KEY = ConfigurationManager.AppSettings["SECRET_KEY"];
            Qiniu.Conf.Config.UP_HOST = ConfigurationManager.AppSettings["UP_HOST"];
            Qiniu.Conf.Config.USER_AGENT = ConfigurationManager.AppSettings["USER_AGENT"];
            Qiniu.Conf.Config.API_HOST = ConfigurationManager.AppSettings["API_HOST"];
            Qiniu.Conf.Config.RSF_HOST = ConfigurationManager.AppSettings["RSF_HOST"];
            Qiniu.Conf.Config.PREFETCH_HOST = ConfigurationManager.AppSettings["PREFETCH_HOST"];
        }
    }
}