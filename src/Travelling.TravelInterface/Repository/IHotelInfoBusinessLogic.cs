using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.ViewModel.Hotel;
using Travelling.ViewModel.Lucene;
using Travelling.ViewModel.Travel;

namespace Travelling.TravelInterface.Repository
{
    /// <summary>
    /// 酒店业务接口
    /// </summary>
    public interface IHotelInfoBusinessLogic : IHotelBrandBusinessLogic
    {
        
        /// <summary>
        /// 获取酒店主要信息
        /// </summary>
        /// <returns></returns>
        List<HotelPrimaryInfo> GetRecommendHotels();


        /// <summary>
        /// 根据城市信息获取酒店信息
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        List<HotelRoomInfo> HotelRoomInfoGetByHotelId(int hotelId);

        /// <summary>
        /// 获取酒店可预定房型信息
        /// </summary>
        /// <param name="hotelId">酒店ID</param>
        /// <param name="cityId">城市</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        List<HotelRoomPrimaryInfo> GetHotelRoomInfosAndRatePlans(int hotelId,int cityId, DateTime start, DateTime end);

        /// <summary>
        /// 根据房型编码获取酒店信息
        /// </summary>
        /// <param name="roomTypeCode"></param>
        /// <returns></returns>
        HotelRoomPrimaryInfo GetHotelRoomInfoByRoomTypeCode(int roomTypeCode);

        /// <summary>
        /// 根据城市和房型获取房间信息
        /// </summary>
        /// <param name="hotelid"></param>
        /// <param name="roomTypeCode"></param>
        /// <param name="cityId"></param>
        /// <returns></returns>
        HotelRoomPrimaryInfo GetHotelRoomInfo(int hotelid, int roomTypeCode,int cityId);

        void HotelRoomRatePlanChanges(int cityId, int hotelId);

        HotelRoomBookResult BookRooms(HotelRoomBookInfo bookInfo);


        //=========================================================

        /// <summary>
        /// 获取热门酒店以及城市信息
        /// </summary>
        /// <returns></returns>
        Tuple<List<HotelPrimaryInfo>, List<HotelCityDetailInfo>> GetHotCityHotelInfos();

        /// <summary>
        /// 获取酒店静态信息
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        HotelDetailInfo GetHotelDescriptionByHotelId(int hotelId);

        /// <summary>
        /// 获取酒店附近酒店
        /// </summary>
        /// <param name="hotelid"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        List<HotelPrimaryInfo> GetNearHotelInfos(int hotelid, float distance = 1);

        List<HotelRefPointInfo> GetRefPointsByHotelID(int hotelId);

        List<HotelRefPointInfo> GetRefPointsByCityID(int cityID);

        

        List<LocationInfo> GetLocationInfoByCityID(int cityID);

        /// <summary>
        /// 根据城市ID获取热门区域信息
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        List<CityAreaPrimaryInfo> GetCityAreaInfoByCityId(int cityID);

        List<HotelQueryPrimaryInfo> HotelQueryResult();

        List<HotelRoomRatePlanInfo> HotelRoomPlanQuery();

        List<CityAreaPrimaryInfo> GetCityAreaSummaryInfo(int cityId=0);

        

       
        Tuple<List<HotelLuceneIndexInfo>, List<HotelRoomPriceInfo>,int> HotelRoomInfoQuery(HotelInfoQuery query);

        List<HotelPrimaryInfo> HotelPracticalForCity(int cityId);

        

        /// <summary>
        /// 根据订单号查询订单信息
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        HotelBookingOrder GetHotelBookOrderBySerial(string orderno);

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="orderno"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        HotelBookingOrder GetBookOrderByOrderNoAndTel(string orderno, string tel);

        /// <summary>
        /// 取消酒店订单
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        bool HotelOrderCancel(string orderno);

        /// <summary>
        /// 获取酒店品牌详细信息
        /// </summary>
        /// <returns></returns>
        List<HotelBrandDetailInfo> HotelBrandDetailInfoGet();

        /// <summary>
        /// 获取酒店城市详细信息
        /// </summary>
        /// <param name="searchType"></param>
        /// <returns></returns>
        List<HotelCityDetailInfo> HotelCityDetailInfoGetAll(HotelCityDetailSearchType searchType);

        /// <summary>
        /// 酒店查询推荐数据
        /// </summary>
        /// <returns></returns>
        string HotelCityDetailInfoGetJsonData();

        /// <summary>
        /// 精选酒店以及城市信息
        /// </summary>
        /// <returns></returns>
        Tuple<List<HotelPrimaryInfo>, List<HotelCityDetailInfo>> GetChoiceCityHotelInfos();

        /// <summary>
        /// 获取酒店推荐城市以及酒店推荐品牌
        /// </summary>
        /// <returns></returns>
        Tuple<List<HotelCityDetailInfo>, List<HotelBrandDetailInfo>> HotelRecommendCityAndBrandInfos();

        /// <summary>
        /// 酒店品牌信息统计
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃")]
        //List<HotelBrandSummaryInfo> HotelBrandSummaryInfos();

        List<HotelCitySummaryInfo> HotelCitySummaryInfos();

        List<CityAreaPrimaryInfo> GetCityAreaInfo();

        /// <summary>
        /// 最惠酒店信息
        /// </summary>
        /// <returns></returns>
        List<HotelPrimaryInfo> HotelMostPractical();

        /// <summary>
        /// 根据城市ID获取酒店信息
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        List<HotelLuceneIndexInfo> HotelDescriptionGetByCityId(int cityId);

        /// <summary>
        /// 根据城市ID集合获取酒店信息
        /// </summary>
        /// <param name="cityIdList"></param>
        /// <returns></returns>
        List<HotelLuceneIndexInfo> HotelDescriptionGetByCityIdList(List<int> cityIdList);

        /// <summary>
        /// 经济型酒店信息
        /// </summary>
        /// <returns></returns>
        List<HotelPrimaryInfo> HotelCheapMost();

        //======================================
        void HotelInfoToIndex();

        List<HotelBrandSummaryInfo> HotelBrandSummaryInfos();
    }
}
