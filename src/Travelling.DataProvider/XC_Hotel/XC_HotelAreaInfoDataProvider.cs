using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Hotel;
using Travelling.Domain.HotelSyncRecord;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.DataLayer;
using Travelling.ViewModel.Hotel;

namespace Travelling.DataProvider.HotelSyncRecord
{
    public class XC_HotelAreaInfoDataProvider : BaseRecord<T_XC_HotelAreaInfo>, IXC_HotelAreaInfoDataProvider
    {
        private readonly string tableName;
        public XC_HotelAreaInfoDataProvider()
        {
            this.defaultDatabase = OTA_HotelDatabase;
            tableName = "T_XC_HotelAreaInfo";
        }

        public void InitAreaTypeCode()
        {
            ExecuteProc(HotelSyncRecordDataStore.CityAreaInfoSettingTypeCode);
        }

        public List<T_XC_HotelAreaInfo> GetAreaInfoToSync(int topCount=100)
        {
            Sql executeSql = Sql.Builder.Where("SyncState=0");
            return Top(topCount, executeSql).ToList();
        }

        public bool UpdateSyncState(List<int> idList)
        {
            string sql = string.Format("Update {1} set SyncState=1 where ID in ({0})",string.Join(",",idList),tableName);
            return Execute(sql)>0;
        }

        public bool InitSyncState()
        {
            return false;
        }

        public List<CityAreaPrimaryInfo> GetCityAreaSummaryInfo()
        {
            string sql = string.Format(@"select Name as AreaName,TypeCode,CityID,AreaID from {0}
                           group by CityID,TypeCode,AreaID,Name",tableName);

            var items = defaultDatabase.Query<CityAreaPrimaryInfo>(sql).ToList();
            return items;
        }
        
        
       

        public List<T_XC_HotelAreaInfo> GetCityAreaInfoForLuceneIndex(int topCount = 200)
        {
            Sql topSql = Sql.Builder.Where("IsIndex=0");
            return Top(topCount, topSql).ToList();
        }

        /// <summary>
        /// 获取国内城市热门区域信息
        /// </summary>
        /// <returns></returns>
        public List<CityAreaPrimaryInfo> CityAreaInfoGetDistinct()
        {
            string sql = "select DISTINCT(AreaID), Name as AreaName,TypeCode,CityID from T_XC_HotelAreaInfo WITH(NOLOCK)";
            return defaultDatabase.Query<CityAreaPrimaryInfo>(sql).ToList();
        }
        
    }
}
