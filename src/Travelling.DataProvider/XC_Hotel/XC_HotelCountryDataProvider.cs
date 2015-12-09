using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.TravelInterface.Data;

namespace Travelling.DataProvider
{
    /// <summary>
    /// 相关国家信息
    /// </summary>
    public class XC_HotelCountryDataProvider : BaseRecord<T_XC_HotelCountry>, IXC_HotelCountryDataProvider
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public XC_HotelCountryDataProvider()
        {
            this.defaultDatabase = OTA_HotelDatabase;
        }
    }
}
