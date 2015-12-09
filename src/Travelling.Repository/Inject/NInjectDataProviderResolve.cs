using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Modules;
using Travelling.TravelInterface;
using Travelling.DataProvider;
using Travelling.TravelInterface.Data;
using Travelling.TravelInterface.Repository;
using Travelling.DataProvider.HotelSyncRecord;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.TravelInterface.Data.Hotel;
using Travelling.DataProvider.Hotel;
using Travelling.TravelInterface.Data.SceneryTicket;
using Travelling.DataProvider.Scenery;
using Travelling.TravelInterface.Data.Setting;
using Travelling.DataProvider.Setting;

namespace Travelling.Repository
{
    /// <summary>
    /// 依赖注入
    /// </summary>
    public class NInjectDataProviderResolve : NinjectModule
    {
        /// <summary>
        /// 绑定对象
        /// </summary>
        public override void Load()
        {
            Bind<IUserDataProvider>().To<UsersDataProvider>();
            Bind<IAccountInfoDataProvider>().To<AccountInfoDataProvider>();
            Bind<IXC_HotelProvinceDataProvider>().To<XC_HotelProvinceDataProvider>();
            Bind<IXC_HotelCountryDataProvider>().To<XC_HotelCountryDataProvider>();
            
            
            Bind<IXC_HotelThemeDataProvider>().To<XC_HotelThemeDataProvider>();
            
            Bind<ISceneryThemeDataProvider>().To<SceneryThemeDataProvider>();
            Bind<ISceneryInfoSyncRecordDataProvider>().To<SceneryInfoSyncRecordDataProvider>();
            
            
            Bind<IAccountLogDataProvider>().To<AccountLogDataProvider>();
            
            Bind<IHotelBookingOrderDataProvider>().To<HotelBookingOrderDataProvider>();

            //同步对象绑定
            
            Bind<IXC_HotelSearchInfoDataProvider>().To<XC_HotelSearchInfoDataProvider>();
            Bind<IXC_HotelDescriptionDataProvider>().To<XC_HotelDescriptionDataProvider>();
            Bind<IXC_HotelRoomInfoDataProvider>().To<XC_HotelRoomInfoDataProvider>();
            Bind<IXC_HotelRefPointInfoDataProvider>().To<XC_HotelRefPointInfoDataProvider>();
            Bind<IXC_HotelLocationDataProvider>().To<XC_HotelLocationDataProvider>();
            
            

            Bind<IHotelCityBusinessLogic>().To<HotelCityBusinessLogic>();
            
            Bind<IXC_HotelPriceDataProvider>().To<XC_HotelPriceDataProvider>();
            Bind<IHotelDescriptionDataProvider>().To<HotelDescriptionDataProvider>();

            Bind<IXC_HotelAreaInfoDataProvider>().To<XC_HotelAreaInfoDataProvider>();
            Bind<IJobSchedulerDataProvider>().To<JobSchedulerDataProvider>();
            Bind<IXC_HotelRoomRateJobSchedulerDataProvider>().To<XC_HotelRoomRateJobSchedulerDataProvider>();
            Bind<IXC_HotelCityDetailInfoDataProvider>().To<XC_HotelCityDetailInfoDataProvider>();
            Bind<IXC_HotelBrandDetailInfoDataProvider>().To<XC_HotelBrandDetailInfoDataProvider>();
            Bind<ISceneryProvinceDetailInfoDataProvider>().To<SceneryProvinceDetailInfoDataProvider>();
            Bind<IJobSchedulerLogDataProvider>().To<JobSchedulerLogDataProvider>();
            Bind<IXC_HotelRoomRatePlanDataProvider>().To<XC_HotelRoomRatePlanDataProvider>();
            Bind<IOperatingLogDataProvider>().To<OperatingLogDataProvider>();

            Bind<IFriendLinkDataProvider>().To<FriendLinkDataProvider>();
            Bind<ISettingConfigDataProvider>().To<SettingConfigDataProvider>();
            Bind<IUnionDetailInfoDataProvider>().To<UnionDetailInfoDataProvider>();
            Bind<IArticleInfoDataProvider>().To<ArticleInfoDataProvider>();

            Bind<IHotelInfoDataProvider>().To<HotelInfoDataProvider>();
            Bind<ICityInfoDataProvider>().To<CityInfoDataProvider>();
            Bind<ILocationInfoDataProvider>().To<LocationInfoDataProvider>();
            Bind<IHotelBrandDataProvider>().To<HotelBrandDataProvider>();
        }
    }
}
