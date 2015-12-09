using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Travelling.Web.Session
{
    public class SessionStore
    {
        private static SessionStore instance;
        private static object _lock = new object();

        public SessionStore()
        {

        }

        public static SessionStore GetInstance()
        {
            if(instance==null)
            {
                lock(_lock)
                {
                    if(instance==null)
                    {
                        instance = new SessionStore();
                    }
                }
            }
            return instance;
        }

        public void SaveSession(string sessionKey,dynamic sessionObj)
        {
            HttpContext.Current.Session[sessionKey] = sessionObj;
        }

        public dynamic GetSession(string sessionKey)
        {
            dynamic sessionObj = HttpContext.Current.Session[sessionKey];
            return sessionObj;
        }
    }
}
