using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.HotelSyncRecord;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.DataLayer;

namespace Travelling.DataProvider.HotelSyncRecord
{
    public class XC_HotelSearchInfoDataProvider : BaseRecord<T_XC_HotelSearchInfo>, IXC_HotelSearchInfoDataProvider
    {
        private readonly string tableName;
        public XC_HotelSearchInfoDataProvider()
        {
            this.defaultDatabase = OTA_HotelDatabase;
            tableName = "T_XC_HotelSearchInfo";
        }

        public List<T_XC_HotelSearchInfo> GetHotelSyncInfoByState(bool syncState, int topCount)
        {
            string sql = string.Format("select top {0} * from {2} where SyncSate={1} ORDER by HotelID asc",topCount,syncState?1:0,tableName);
            return Query(sql).ToList();
        }

        public List<T_XC_HotelSearchInfo> GetHotelSyncInfoByPriceState(bool syncState, int topCount)
        {
            string sql = string.Format("select top {0} * from {1} where PriceSyncState={2} ORDER by CityID asc", topCount, tableName, syncState ? 1 : 0);
            return Query(sql).ToList();
        }

        public bool UpdateSyncState(List<int> hotelIds)
        {
            string idString = string.Join(",",hotelIds);
            string sql = string.Format("update {1} set SyncSate=1 where HotelID in ({0})", idString,tableName);
            int updateResult = defaultDatabase.Execute(sql);
            return updateResult > 0;
        }

        public bool UpdatePriceSyncState(List<int> hotelIds)
        {
            string idString = string.Join(",", hotelIds);
            string sql = string.Format("update {1} set PriceSyncState=1 where HotelID in ({0})", idString,tableName);
            int updateResult = defaultDatabase.Execute(sql);
            return updateResult > 0;
        }

        public int UpdateSyncStateWaitSync()
        {
            string sql = string.Format("update {0} set SyncSate=0",tableName);
            int updateResult = defaultDatabase.Execute(sql);
            return updateResult;
        }

        public int UpdatePriceSyncStateWaitSync()
        {
            string sql = string.Format("update {0} set PriceSyncState=0",tableName);
            int updateResult = defaultDatabase.Execute(sql);
            return updateResult;
        }

        public int GetDescriptionSyncCount(bool? syncState)
        {
            if (syncState == null)
                return this.Count();

            Sql countSql = Sql.Builder.Where("SyncSate=@0",(bool)syncState?1:0);
            return Count(countSql);
        }

        public int GetHotelRoomRatePlanSyncCount(bool? syncState)
        {
            if (syncState == null)
                return this.Count();

            Sql countSql = Sql.Builder.Where("PriceSyncState=@0", (bool)syncState ? 1 : 0);
            return Count(countSql);
        }
    }
}
