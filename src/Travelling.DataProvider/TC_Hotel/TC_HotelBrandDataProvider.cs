using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.TC_Hotel;
using Travelling.TravelInterface.Data.TC_Hotel;

namespace Travelling.DataProvider.TC_Hotel
{
    public class TC_HotelBrandDataProvider : BaseRecord<TC_HotelBrand>, ITC_HotelBrandDataProvider
    {
        public TC_HotelBrandDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }
    }
}
