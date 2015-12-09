using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Caching
{
    public class CacheServiceFactory
    {
        //private readonly ICacheProvider cacheProvider;

        private static ICacheProvider instance = null;
        private CacheServiceFactory()
        { }

        public static ICacheProvider Instance()
        {
            if(instance==null)
            {
                instance = new DefaultCacheProvider();
            }
            return instance;
        }

        
    }
}
