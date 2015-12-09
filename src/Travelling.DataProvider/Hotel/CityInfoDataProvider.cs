using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Hotel;
using Travelling.TravelInterface.Data.Hotel;

namespace Travelling.DataProvider.Hotel
{
    /// <summary>
    /// 酒店城市相关数据
    /// </summary>
    public class CityInfoDataProvider : BaseRecord<T_CityInfo>, ICityInfoDataProvider
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CityInfoDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }

        /// <summary>
        /// 设置城市数据
        /// </summary>
        public void SettingCityData()
        {
            ExecuteProc("P_SettingCityData");
        }
    }
}
