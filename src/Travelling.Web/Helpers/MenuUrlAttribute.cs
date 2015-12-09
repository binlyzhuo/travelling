using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Web.Helpers
{
    [AttributeUsage(AttributeTargets.Field,AllowMultiple=false,Inherited=false)]
    public class MenuUrlAttribute:Attribute
    {
        private string title;
        private string url;
        private int index;

        public MenuUrlAttribute(string title,string url,int index)
        {
            this.title = title;
            this.url = url;
            this.index = index;
        }

        public string Title
        {
            get
            {
                return this.title;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }
        }

        public int Index
        {
            get
            {
                return this.index;
            }
        }
    }
}
