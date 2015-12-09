using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.TravelInterface.Data.Zhuna;

namespace Travelling.DataProvider.Zhuna_Hotel
{
    public class Zhuna_CityLableInfoDataProvider : BaseRecord<Zhuna_CityLableInfo>, IZhuna_CityLableInfoDataProvider
    {
        public Zhuna_CityLableInfoDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }
    }
}
