using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.HotelSyncRecord;

namespace Travelling.TravelInterface.Data.HotelSyncRecord
{
    public interface IXC_HotelRoomRatePlanDataProvider : IDataProvider<T_XC_HotelRoomRatePlan>
    {
        /// <summary>
        /// 创建价格计划表
        /// </summary>
        /// <param name="cityIdList"></param>
        void CreateRoomRateForCity(List<int> cityIdList);

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="items"></param>
        /// <param name="tableName"></param>
        //void BulkInsertItems(List<T_XC_HotelRoomRatePlan> items, string tableName);

        
        /// <summary>
        /// 清空酒店价格计划数据
        /// </summary>
        /// <param name="cityIdList"></param>
        void TruncateHotelRoomRateData(List<int> cityIdList);

        /// <summary>
        /// 查询待同步酒店价格计划
        /// </summary>
        /// <param name="cityId">城市个数</param>
        /// <param name="topCount">查询个数</param>
        /// <returns></returns>
        List<T_XC_HotelRoomRatePlan> HotelSyncRoomRateGetToImportOnline(int cityId, int topCount = 500);

        /// <summary>
        /// 更改酒店价格计划同步状态
        /// </summary>
        /// <param name="roomRateIdList"></param>
        /// <param name="cityId"></param>
        /// <returns></returns>
        bool HotelSyncRoomRateUpdatSyncState(List<int> roomRateIdList, int cityId);

        /// <summary>
        /// 删除过期数据
        /// </summary>
        /// <param name="cityIdList"></param>
        void DeleteOverdueRoomRateData(List<int> cityIdList);

        /// <summary>
        /// 删除城市归属错误的酒店价格计划
        /// </summary>
        /// <param name="cityIdList"></param>
        void DeleteErrorCityRoomRatePlans(List<int> cityIdList);
    }
}
