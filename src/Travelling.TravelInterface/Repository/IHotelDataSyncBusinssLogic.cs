using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.Domain.HotelSyncRecord;
using Travelling.ViewModel.Dto.HotelSyncRecord;
using Travelling.ViewModel.Dto.User;

namespace Travelling.TravelInterface.Repository
{
    /// <summary>
    /// 酒店数据同步相关功能接口
    /// </summary>
    public interface IHotelDataSyncBusinssLogic
    {
        

        /// <summary>
        /// 酒店查询信息同步
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        int ImportHotelSyncInfos(Action<string> action,bool isInitData);

        /// <summary>
        /// 同步酒店静态信息
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        int ImportHotelDescriptionSyncInfos(Action<string> action,bool isInit);

        /// <summary>
        /// 导入价格计划
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="action"></param>
        void ImportHotelSyncRoomRate(DateTime startDate, DateTime endDate, Action<string> action);

       
        /// <summary>
        /// 初始化酒店查询信息
        /// </summary>
        void InitHotelSyncInfoData();

        /// <summary>
        /// 初始化酒店静态信息同步数据
        /// </summary>
        void InitHotelDescriptionSyncData();

        

        /// <summary>
        /// 酒店最低价格获取
        /// </summary>
        /// <param name="action"></param>
        void HotelLowestPriceGet(Action<string> action);

        /// <summary>
        /// 导入酒店最低价格
        /// </summary>
        /// <returns></returns>
        bool ImportHotelMinPrice();

        /// <summary>
        /// 城市热点类型设置
        /// </summary>
        /// <param name="action"></param>
        void CityAreaInfoSettingTypeCode(Action<string> action);

        void InitAreaInfoSyncOnlineState();

        void ImportHotelSyncRoomRateOnline(DateTime startDate, DateTime endDate, Action<string> action);

        void CreateHotelRoomRateTablesForCities(Action<string> action);

        void HotelSyncRoomRate(Action<string> action,bool isClear);

        /// <summary>
        /// 删除过期酒店价格数据
        /// </summary>
        void DeleteOverdueRoomRatePlanDateOfCity();

        HotelRoomRateJobScheduler HotelRoomRateJobSchedulerGetRecordToExecute();

    }
}
