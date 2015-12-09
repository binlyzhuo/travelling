using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.TravelInterface.Data;

namespace Travelling.DataProvider
{
    /// <summary>
    /// 酒店主题
    /// </summary>
    public class XC_HotelThemeDataProvider : BaseRecord<T_XC_HotelTheme>, IXC_HotelThemeDataProvider
    {
        public XC_HotelThemeDataProvider()
        {
            this.defaultDatabase = OTA_HotelDatabase;
        }
    }
}
