using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Caching
{
    public enum CacheOverdueType
    {
        None = 0,
        AbsoluteExpiration=1,
        NoSlidingExpiration=2
    }
}
