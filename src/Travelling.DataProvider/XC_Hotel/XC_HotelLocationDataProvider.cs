using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.TravelInterface.Data;
using Travelling.DataLayer;

namespace Travelling.DataProvider
{
    /// <summary>
    /// 国内行政区域
    /// </summary>
    public class XC_HotelLocationDataProvider : BaseRecord<T_XC_HotelLocation>, IXC_HotelLocationDataProvider
    {
        public XC_HotelLocationDataProvider()
        {
            this.defaultDatabase = OTA_HotelDatabase;

        }

        public List<T_XC_HotelLocation> GetLocationByCityID(int cityID)
        {
            Sql buildSql = Sql.Builder.Where("LocationCityID=@0", cityID);
            return defaultDatabase.Query<T_XC_HotelLocation>(buildSql).ToList();
        }
    }
}
