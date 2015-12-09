using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataProvider;
using Travelling.DataProvider.Scenery;
using Travelling.TravelInterface.Data;
using Travelling.TravelInterface.Data.SceneryTicket;

namespace Travelling.Repository.Inject
{
    /// <summary>
    /// 景区对象依赖注入
    /// </summary>
    public class TicketNInjectDataProvider : NinjectModule
    {
        /// <summary>
        /// 注入
        /// </summary>
        public override void Load()
        {
            
            Bind<ISceneryThemeDataProvider>().To<SceneryThemeDataProvider>();
            
            Bind<ISceneryInfoSyncRecordDataProvider>().To<SceneryInfoSyncRecordDataProvider>();
            
            Bind<ISceneryInfoDetailDataProvider>().To<SceneryInfoDetailDataProvider>();
            Bind<ISceneryTicketPriceDataProvider>().To<SceneryTicketPriceDataProvider>();
            Bind<ISceneryImgInfoDataProvider>().To<SceneryImgInfoDataProvider>();
            Bind<ISceneryTicketOrderDataProvider>().To<SceneryTicketOrderDataProvider>();
            Bind<ISceneryProvinceDetailInfoDataProvider>().To<SceneryProvinceDetailInfoDataProvider>();
        }
    }
}
