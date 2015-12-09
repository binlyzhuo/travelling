using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataProvider.TC_Hotel;
using Travelling.TravelInterface.Data.TC_Hotel;

namespace Travelling.Repository.Inject
{
    public class TCHotelNInjectDataProvider : NinjectModule
    {
        public override void Load()
        {
            Bind<ITC_HotelCityInfoDataProvider>().To<TC_HotelCityInfoDataProvider>();
            Bind<ITC_HotelProvinceInfoDataProvider>().To<TC_HotelProvinceInfoDataProvider>();
            Bind<ITC_HotelRegionInfoDataProvider>().To<TC_HotelRegionInfoDataProvider>();
            Bind<ITC_HotelSectionInfoDataProvider>().To<TC_HotelSectionInfoDataProvider>();
            Bind<ITC_HotelListDataProvider>().To<TC_HotelListDataProvider>();
            Bind<ITC_HotelBrandDataProvider>().To<TC_HotelBrandDataProvider>();
        }
    }
}
