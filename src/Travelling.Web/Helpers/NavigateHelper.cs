using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using Travelling.Caching;

namespace Travelling.Web.Helpers
{
    public class NavigateHelper
    {
        public static MvcHtmlString GetTopMenus(TopMenuSetting selected = TopMenuSetting.Home)
        {
            var menuItems = HttpContext.Current.Cache.Get(CacheKeys.TopMenuSettingCache) as IEnumerable<MenuInfo>;
            if(menuItems==null)
            {
                Type enumType = typeof(TopMenuSetting);

                menuItems = from int val in Enum.GetValues(enumType)
                                   let field = enumType.GetField(Enum.GetName(enumType, val))
                                   let att = (MenuUrlAttribute)field.GetCustomAttributes(typeof(MenuUrlAttribute), false).SingleOrDefault()
                                   select new MenuInfo() { Index = att.Index, Title = att.Title, Url = att.Url,Value=val };
                HttpContext.Current.Cache.Insert(CacheKeys.TopMenuSettingCache, menuItems);
            }

            StringBuilder navigate = new StringBuilder();

            foreach (var m in menuItems)
            {
                navigate.AppendFormat("<a href=\"{0}\">{1}</a>",m.Url,m.Title);
            }
            return new MvcHtmlString(navigate.ToString());
        }

        
    }
}
