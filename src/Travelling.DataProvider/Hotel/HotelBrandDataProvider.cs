using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Hotel;
using Travelling.TravelInterface.Data.Hotel;

namespace Travelling.DataProvider.Hotel
{
    public class HotelBrandDataProvider : BaseRecord<T_HotelBrand>, IHotelBrandDataProvider
    {
        public HotelBrandDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }
    }
}
