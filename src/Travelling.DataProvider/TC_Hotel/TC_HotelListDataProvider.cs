using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.TC_Hotel;
using Travelling.TravelInterface.Data.TC_Hotel;

namespace Travelling.DataProvider.TC_Hotel
{
    public class TC_HotelListDataProvider : BaseRecord<TC_HotelList>, ITC_HotelListDataProvider
    {
        public TC_HotelListDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }

    }
}
