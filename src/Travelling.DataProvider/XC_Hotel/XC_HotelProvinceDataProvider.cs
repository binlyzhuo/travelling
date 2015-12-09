using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.Domain;
using Travelling.TravelInterface.Data;

namespace Travelling.DataProvider
{
    /// <summary>
    /// 省份信息
    /// </summary>
    public class XC_HotelProvinceDataProvider : BaseRecord<T_XC_HotelProvince>, IXC_HotelProvinceDataProvider
    {
        public XC_HotelProvinceDataProvider()
        {
            this.defaultDatabase = OTA_HotelDatabase;
        }
    }
}
