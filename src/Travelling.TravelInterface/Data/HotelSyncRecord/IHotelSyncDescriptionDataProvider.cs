using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.HotelSyncRecord;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.ViewModel.Hotel;
using Travelling.ViewModel.Lucene;
using Travelling.ViewModel.Travel;

namespace Travelling.TravelInterface.Data.HotelSyncRecord
{
    /// <summary>
    /// 酒店lucene索引接口
    /// </summary>
    public interface IXC_HotelDescriptionDataProvider : IDataProvider<T_XC_HotelDescription>
    {
        List<T_XC_HotelDescription> GetHotelInfoBySyncState(bool syncState,int topCount);

        void UpdateSyncState(List<int> hotelIdList, bool syncState);

        /// <summary>
        /// 获取待索引数据
        /// </summary>
        /// <returns></returns>
        List<HotelLuceneIndexInfo> GetHotelInfoByIndexState();

        bool UpdateIndexState(List<int> hotelIdList);

        int WaitIndexRecordCount();

        void InitHotelInfoLuceneIndexRecord();

        void UpdateSyncState(bool syncState);

        /*
         * ui
         */
        /// <summary>
        /// 获取热门城市酒店信息
        /// </summary>
        /// <returns></returns>
        Tuple<List<HotelPrimaryInfo>, List<HotelCityDetailInfo>> GetHotCityHotelInfos();

        /// <summary>
        /// 精选酒店以及城市信息
        /// </summary>
        /// <returns></returns>
        Tuple<List<HotelPrimaryInfo>, List<HotelCityDetailInfo>> GetChoiceCityHotelInfos();

        /// <summary>
        /// 获取酒店附近酒店信息
        /// </summary>
        /// <param name="hotelid"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        List<HotelPrimaryInfo> GetNearHotelInfos(int hotelid, float distance);

        /// <summary>
        /// 酒店信息查询结果
        /// </summary>
        /// <returns></returns>
        List<HotelQueryPrimaryInfo> HotelQueryResult();

        /// <summary>
        /// 酒店价格计划查询
        /// </summary>
        /// <returns></returns>
        List<HotelRoomRatePlanInfo> HotelRoomPlanQuery();

        /// <summary>
        /// 获取待lucene索引酒店信息
        /// </summary>
        /// <param name="topCount"></param>
        /// <returns></returns>
        List<T_XC_HotelDescription> GetRecordForLuceneIndex(int topCount = 100);

        /// <summary>
        /// 获取推荐酒店信息
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        List<HotelPrimaryInfo> HotelPracticalForCity(int cityId);

        /// <summary>
        /// 同步酒店最低价格
        /// </summary>
        /// <returns></returns>
        bool UpdateHotelMinPrice();

        /// <summary>
        /// 酒店品牌信息统计
        /// </summary>
        /// <returns></returns>
        List<HotelBrandSummaryInfo> HotelBrandSummaryInfos();

        List<HotelCitySummaryInfo> HotelCitySummaryInfos();

        /// <summary>
        /// 最优惠酒店信息
        /// </summary>
        /// <returns></returns>
        List<HotelPrimaryInfo> HotelMostPractical();

        /// <summary>
        /// 经济型酒店信息
        /// </summary>
        /// <returns></returns>
        List<HotelPrimaryInfo> HotelCheapMost();
    }
}
