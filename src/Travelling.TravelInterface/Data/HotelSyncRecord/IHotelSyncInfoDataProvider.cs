using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.HotelSyncRecord;

namespace Travelling.TravelInterface.Data.HotelSyncRecord
{
    /// <summary>
    /// 酒店详细信息同步记录接口
    /// </summary>
    public interface IXC_HotelSearchInfoDataProvider : IDataProvider<T_XC_HotelSearchInfo>
    {
        /// <summary>
        /// 获取待同步信息
        /// </summary>
        /// <param name="syncState"></param>
        /// <param name="topCount"></param>
        /// <returns></returns>
        List<T_XC_HotelSearchInfo> GetHotelSyncInfoByState(bool syncState, int topCount);

        /// <summary>
        /// 更改同步状态
        /// </summary>
        /// <param name="hotelIds"></param>
        /// <returns></returns>
        bool UpdateSyncState(List<int> hotelIds);


        /// <summary>
        /// 更改酒店价格信息同步状态
        /// </summary>
        /// <param name="hotelIds"></param>
        /// <returns></returns>
        bool UpdatePriceSyncState(List<int> hotelIds);


        /// <summary>
        /// 获取酒店价格同步记录
        /// </summary>
        /// <param name="syncState"></param>
        /// <param name="topCount"></param>
        /// <returns></returns>
        List<T_XC_HotelSearchInfo> GetHotelSyncInfoByPriceState(bool syncState, int topCount);

        /// <summary>
        /// 初始化酒店信息同步状态
        /// </summary>
        /// <returns></returns>
        int UpdateSyncStateWaitSync();

        /// <summary>
        /// 初始化酒店价格信息同步状态
        /// </summary>
        /// <returns></returns>
        int UpdatePriceSyncStateWaitSync();

        /// <summary>
        /// 获取酒店待同步记录个数
        /// </summary>
        /// <param name="syncState"></param>
        /// <returns></returns>
        int GetDescriptionSyncCount(bool? syncState);

        /// <summary>
        /// 获取酒店价格同步个数
        /// </summary>
        /// <param name="syncState"></param>
        /// <returns></returns>
        int GetHotelRoomRatePlanSyncCount(bool? syncState);
    }
}
