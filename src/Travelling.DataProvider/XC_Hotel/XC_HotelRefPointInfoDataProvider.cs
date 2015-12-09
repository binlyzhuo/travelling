using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.HotelSyncRecord;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.DataLayer;

namespace Travelling.DataProvider.HotelSyncRecord
{
    public class XC_HotelRefPointInfoDataProvider : BaseRecord<T_XC_HotelRefPointInfo>, IXC_HotelRefPointInfoDataProvider
    {
        private readonly string tableName;
        public XC_HotelRefPointInfoDataProvider()
        {
            this.defaultDatabase = OTA_HotelDatabase;
            tableName = "T_XC_HotelRefPointInfo"; 
        }

        //public List<T_XC_HotelRefPointInfo> GetHotelRefPointSyncInfoBySyncState(int topCount,bool syncState)
        //{
        //    Sql buildSql = Sql.Builder.Where("SyncState=@0", syncState?1:0);
        //    return Top(topCount, buildSql).ToList();
        //}

        //public void UpdateSyncState(List<int> idList,bool syncState)
        //{
        //    string idString = string.Join(",", idList);
        //    string updateSql = string.Format("UPDATE {2} set SyncState = {1} where id in ({0})", idString,syncState ? 1 : 0,tableName);
        //    defaultDatabase.Execute(updateSql);
        //}

        public List<T_XC_HotelRefPointInfo> GetRefPointByHotelId(int hotelId)
        {
            Sql executeSql = Sql.Builder.Where("HotelId=@0", hotelId);
            return defaultDatabase.Query<T_XC_HotelRefPointInfo>(executeSql).ToList();
        }

        public List<T_XC_HotelRefPointInfo> GetRefPointByCityId(int cityId)
        {
            Sql executeSql = Sql.Builder.Where("CityId=@0", cityId);
            return defaultDatabase.Query<T_XC_HotelRefPointInfo>(executeSql).ToList();
        }
    }
}
