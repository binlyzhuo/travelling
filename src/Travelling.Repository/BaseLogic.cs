using AutoMapper;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Caching;
using Travelling.Domain;
using Travelling.Domain.Hotel;
using Travelling.Domain.HotelSyncRecord;
using Travelling.Repository.Inject;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.HotelSyncRecord;
using Travelling.ViewModel.Travel;

namespace Travelling.Repository
{
    /// <summary>
    /// 业务基类
    /// </summary>
    public class BaseLogic
    {
        /// <summary>
        /// 依赖注入对象
        /// </summary>
        protected readonly StandardKernel kernel;
        protected readonly StandardKernel ketnelZhuna;

        /// <summary>
        /// 缓存处理对象
        /// </summary>
        protected readonly ICacheProvider cacheProvider;

        
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseLogic()
        {
            kernel = new Ninject.StandardKernel(new NInjectDataProviderResolve());
            ketnelZhuna = new Ninject.StandardKernel(new ZhunaNInjectDataProvider());
            cacheProvider = new DefaultCacheProvider();
            
        }

        
    }
}
