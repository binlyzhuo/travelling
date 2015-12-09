using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.HotelSyncRecord;

namespace Travelling.TravelInterface.Data.HotelSyncRecord
{
    public interface IXC_HotelRefPointInfoDataProvider : IDataProvider<T_XC_HotelRefPointInfo>
    {
        //List<T_XC_HotelRefPointInfo> GetHotelRefPointSyncInfoBySyncState(int topCount, bool syncState);

        //void UpdateSyncState(List<int> idList, bool syncState);

        /// <summary>
        /// 获取酒店附近热点信息
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        List<T_XC_HotelRefPointInfo> GetRefPointByHotelId(int hotelId);

        /// <summary>
        /// 根据CityId获取热点区域信息
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        List<T_XC_HotelRefPointInfo> GetRefPointByCityId(int cityId);
    }
}
