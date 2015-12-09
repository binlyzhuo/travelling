using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel
{
    public class PageObjectResult<T>
        where T:class
    {
        public List<T> Items { set; get; }
        public long TotalCount { set; get; }

        public long Page { set; get; }
        public long PageSize { set; get; }

        public long TotalPages { set; get; }
    }
}
