using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.TC_Hotel;
using Travelling.TravelInterface.Data.TC_Hotel;

namespace Travelling.DataProvider.TC_Hotel
{
    public class TC_HotelSectionInfoDataProvider : BaseRecord<TC_HotelSectionInfo>, ITC_HotelSectionInfoDataProvider
    {
        public TC_HotelSectionInfoDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }
    }
}
