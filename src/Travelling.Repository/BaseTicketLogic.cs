using AutoMapper;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Caching;
using Travelling.OpenApiEntity.Scenery.Module;
using Travelling.Repository.Inject;
using Travelling.ViewModel.Travel;

namespace Travelling.Repository
{
    /// <summary>
    /// 门票业务处理基类
    /// </summary>
    public class BaseTicketLogic
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
        public BaseTicketLogic()
        {
            kernel = new Ninject.StandardKernel(new TicketNInjectDataProvider());
            cacheProvider = new DefaultCacheProvider();
            
        }

        
    }
}
