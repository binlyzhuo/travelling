using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.TC_Hotel;
using Travelling.TravelInterface.Data.TC_Hotel;

namespace Travelling.DataProvider.TC_Hotel
{
    public class TC_HotelCityInfoDataProvider : BaseRecord<TC_HotelCityInfo>, ITC_HotelCityInfoDataProvider
    {
        public TC_HotelCityInfoDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }
    }
}
