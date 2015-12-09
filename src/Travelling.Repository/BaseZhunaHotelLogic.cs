using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Caching;
using Travelling.Repository.Inject;

namespace Travelling.Repository
{
    public class BaseZhunaHotelLogic
    {
        /// <summary>
        /// 依赖注入对象
        /// </summary>
        protected readonly StandardKernel kernel;

        /// <summary>
        /// 缓存处理对象
        /// </summary>
        protected readonly ICacheProvider cacheProvider;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public BaseZhunaHotelLogic()
        {
            kernel = new Ninject.StandardKernel(new ZhunaNInjectDataProvider());
            cacheProvider = new DefaultCacheProvider();
            
        }
    }
}
