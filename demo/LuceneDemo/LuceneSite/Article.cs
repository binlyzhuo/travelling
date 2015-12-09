using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuceneSite
{
    public class Article
    {
        public string Id { set; get; }
        public string ClassId { set; get; }
        public string ClassName { set; get; }
        public string Title { set; get; }
        public string Summary { set; get; }
        public string Score { set; get; }
        public DateTime CreateTime { set; get; }
    }
}