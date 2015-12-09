using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.TravelInterface.Data.Zhuna;

namespace Travelling.DataProvider.Zhuna_Hotel
{
    public class Zhuna_CityAreaInfoDataProvider : BaseRecord<Zhuna_CityAreaInfo>, IZhuna_CityAreaInfoDataProvider
    {
        public Zhuna_CityAreaInfoDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }
    }
}
