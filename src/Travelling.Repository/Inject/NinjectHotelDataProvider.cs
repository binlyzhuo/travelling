using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.Domain.Hotel;
using Ninject;
using Travelling.TravelInterface.Data.Hotel;
using Travelling.DataProvider.Hotel;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.DataProvider.HotelSyncRecord;

namespace Travelling.Repository.Inject
{
    public class NinjectHotelDataProvider : NinjectModule
    {
        public override void Load()
        {
            Bind<IXC_HotelRefPointInfoDataProvider>().To<XC_HotelRefPointInfoDataProvider>();
            Bind<IHotelDescriptionDataProvider>().To<HotelDescriptionDataProvider>();
        }
    }
}
