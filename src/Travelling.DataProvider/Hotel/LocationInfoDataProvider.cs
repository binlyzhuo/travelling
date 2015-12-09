using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Hotel;
using Travelling.TravelInterface.Data.Hotel;

namespace Travelling.DataProvider.Hotel
{
    public class LocationInfoDataProvider : BaseRecord<T_LocationInfo>, ILocationInfoDataProvider
    {
        public LocationInfoDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }

        public void SettingLocationData()
        {
            ExecuteProc("P_SettingLocationData");
        }
    }
}
