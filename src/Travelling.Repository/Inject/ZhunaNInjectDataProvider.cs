using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Travelling.TravelInterface.Repository;
using Travelling.DataProvider.Zhuna_Hotel;
using Travelling.TravelInterface.Data.Zhuna;

namespace Travelling.Repository.Inject
{
    public class ZhunaNInjectDataProvider : NinjectModule
    {
        public override void Load()
        {
            Bind<IZhuna_CityInfoDataProvider>().To<Zhuna_CityInfoDataProvider>();
            Bind<IZhuna_HotelChainDataProvider>().To<Zhuna_HotelChainDataProvider>();
            Bind<IZhuna_HotelInfoDataProvider>().To<Zhuna_HotelInfoDataProvider>();
            Bind<IZhuna_CityAreaInfoDataProvider>().To<Zhuna_CityAreaInfoDataProvider>();
            Bind<IZhuna_CityLableDataProvider>().To<Zhuna_CityLableDataProvider>();
            Bind<IZhuna_SchoolInfoDataProvider>().To<Zhuna_SchoolInfoDataProvider>();
            Bind<IZhuna_RefPointDataProvider>().To<Zhuna_RefPointDataProvider>();
            Bind<IZhuna_CBDDataProvider>().To<Zhuna_CBDDataProvider>();
            Bind<IZhuna_CityLableInfoDataProvider>().To<Zhuna_CityLableInfoDataProvider>();
        }
    }
}
