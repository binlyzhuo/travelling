using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Caching
{
    public class CacheOptions
    {
        public object CacheObject { set; get; }
        public CacheOverdueType OverdueType { set; get; }
        public DateTime AbsoluteExpiration { set; get; }
        public TimeSpan SlidingExpiration { set; get; }
    }
}
