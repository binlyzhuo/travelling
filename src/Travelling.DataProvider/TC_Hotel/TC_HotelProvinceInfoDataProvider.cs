using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.TC_Hotel;
using Travelling.TravelInterface.Data.TC_Hotel;

namespace Travelling.DataProvider.TC_Hotel
{
    public class TC_HotelProvinceInfoDataProvider : BaseRecord<TC_HotelProvinceInfo>, ITC_HotelProvinceInfoDataProvider
    {
        public TC_HotelProvinceInfoDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }
    }
}
