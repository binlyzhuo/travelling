using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.HotelSyncRecord;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.DataLayer;
using Travelling.ViewModel.Travel;

namespace Travelling.DataProvider.HotelSyncRecord
{
    public class XC_HotelRoomInfoDataProvider : BaseRecord<T_XC_HotelRoomInfo>, IXC_HotelRoomInfoDataProvider
    {
        private readonly string roomTableName;
        private readonly string roomRateTableName;
        public XC_HotelRoomInfoDataProvider()
        {
            this.defaultDatabase = OTA_HotelDatabase;
            roomTableName = "T_XC_HotelRoomInfo";
            roomRateTableName = "T_XC_HotelRoomRatePlan";
        }

        public List<T_XC_HotelRoomInfo> GetHotelRoomsByHotelID(int hotelID)
        {
            Sql buildSql = Sql.Builder.Where("HotelId=@0", hotelID);
            var items = defaultDatabase.Query<T_XC_HotelRoomInfo>(buildSql).ToList();
            return items;
        }

        /// <summary>
        /// 获取酒店可预定房型
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="cityId"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<HotelRoomPrimaryInfo> GetHotelRoomInfosAndRatePlan(int hotelId, int cityId, DateTime start, DateTime end)
        {
            
            string executeSql = string.Format(@"select * from (
                                select ROW_NUMBER() over(PARTITION by ro.RoomTypeCode order by ro.AddDate DESC ) num, ro.HotelId as HotelCode,ro.Floor,ro.Facility,ro.RoomTypeName,ro.RoomTypeCode,rp.StartTime,rp.AmountBeforeTax,rp.NumberOfBreakfast,ro.Size,
                                ro.BedTypeCode,ro.Quantity,rp.CancelAmount,ro.RoomSize,ro.NonSmoking from T_HotelRoomInfo ro
                                left join T_HotelRoomRatePlanForCity_{0} rp on ro.RoomTypeCode = rp.RoomTypeCode
                                where ro.HotelId = {1} and rp.StartTime>='{2}' and rp.StartTime<='{3}' ) t0
                                where t0.num<=1", cityId, hotelId, start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"));
            var items = defaultDatabase.Query<HotelRoomPrimaryInfo>(executeSql, hotelId, start, end).ToList();
            return items;
        }

        public T_XC_HotelRoomInfo GetHotelRoomInfoByRoomTypeCode(int roomTypeCode)
        {
            Sql buildSql = Sql.Builder.Where("RoomTypeCode=@0", roomTypeCode);
            return defaultDatabase.SingleOrDefault<T_XC_HotelRoomInfo>(buildSql);
        }

        public HotelRoomPrimaryInfo GetHotelRoomInfo(int hotelId, int roomTypeCode, int cityId = 0)
        {
            //string executeSql = string.Format("execute {0} @0,@1", HotelDatabaseStore.HotelRoomInfo);
            string executeSql = string.Format(@"select top 1 hi.HotelName,hi.AreaID,hi.AddressLine,hi.CityName,ro.RoomTypeName,ro.BedTypeCode,ro.Floor,ro.RoomSize,ro.Facility,ro.Quantity,rp.AmountBeforeTax,hi.HotelCode from T_HotelDescription hi
                                                inner join T_HotelRoomInfo ro on hi.HotelID = ro.HotelId
                                                inner JOIN T_HotelRoomRatePlanForCity_{2} rp on rp.RoomTypeCode = ro.RoomTypeCode
                                                where hi.HotelID={0} and ro.RoomTypeCode={1}", hotelId, roomTypeCode, cityId);
            return defaultDatabase.SingleOrDefault<HotelRoomPrimaryInfo>(executeSql, hotelId, roomTypeCode);
        }

        public List<HotelRoomPriceInfo> HotelRoomInfoQuery(string hotelids, int cityId, DateTime start, DateTime end)
        {
            ///string executeSql = string.Format("execute {0} @0,@1,@2", HotelDatabaseStore.HotelRoomInfoPriceQuery, hotelids,start,end);
            ///
            string executeSql = string.Format(@"select * from (
                                select ROW_NUMBER() over(PARTITION by ro.RoomTypeCode order by ro.AddDate DESC ) num, ro.HotelId as HotelCode,ro.Floor,ro.Facility,ro.RoomTypeName,ro.RoomTypeCode,rp.StartTime,rp.AmountBeforeTax,rp.NumberOfBreakfast,ro.Size,
                                ro.BedTypeCode,ro.Quantity,rp.CancelAmount,ro.RoomSize,ro.NonSmoking from T_HotelRoomInfo ro
                                left join T_HotelRoomRatePlanForCity_{0} rp on ro.RoomTypeCode = rp.RoomTypeCode
                                where ro.HotelId = {1} and rp.StartTime>='{2}' and rp.StartTime<='{3}' ) t0
                                where t0.num<=1", cityId, hotelids, start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"));
            var items = defaultDatabase.Query<HotelRoomPriceInfo>(executeSql).ToList();
            return items;
        }

        public List<HotelRoomPriceInfo> HotelRoomInfoPriceQuery(string hotelids, DateTime start, DateTime end, int cityId)
        {
            string querySql = string.Format(@"
                                select * from (
                                select ROW_NUMBER() OVER(PARTITION BY rm.RoomTypeCode ORDER by rp.AmountBeforeTax asc) num,rm.HotelId,rm.RoomTypeName,
                                rm.BedTypeCode,isnull(rp.Breakfast,0) Breakfast,isnull(rp.NumberOfBreakfast,0) NumberOfBreakfast,isnull(rp.AmountBeforeTax,0) AmountBeforeTax,isnull(rp.ListPrice,0) ListPrice from {4} rm
                                INNER join {5}_{2} rp on rp.RoomTypeCode = rm.RoomTypeCode and rp.AmountBeforeTax>0
                                and rp.RatePlanCategory=16 
                                and rp.StartTime>='{0}' and rp.StartTime<='{1}'
                                where rm.HotelId in({3}) ) t0 where t0.num<2", start.ToString("yyyy-MM-dd"), end.AddDays(1).ToString("yyyy-MM-dd"), cityId, hotelids, roomTableName, roomRateTableName);

            var roomInfos = defaultDatabase.Query<HotelRoomPriceInfo>(querySql).ToList();
            return roomInfos;
        }
    }
}
