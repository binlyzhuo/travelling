using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using Travelling.Domain.HotelSyncRecord;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.FrameWork;


namespace Travelling.DataProvider.HotelSyncRecord
{
    public class XC_HotelRoomRatePlanDataProvider : BaseRecord<T_XC_HotelRoomRatePlan>, IXC_HotelRoomRatePlanDataProvider
    {
        public XC_HotelRoomRatePlanDataProvider()
        {
            this.defaultDatabase = OTA_HotelDatabase;
        }

        private string GetTableName(int cityID)
        {
            return string.Format("T_XC_HotelRoomRatePlan_{0}", cityID);
        }

        public void CreateRoomRateForCity(List<int> cityIdList)
        {
            StringBuilder tableBuildSql = new StringBuilder();
            foreach(int cityid in cityIdList)
            {

                //tableName = string.Format("T_HotelSyncRoomRatePlanForCity_{0}",cityid);
                tableBuildSql.AppendFormat(@"if object_id('{0}') is not null 
                                               drop TABLE {0}
                                               
                                               create table {0}
                                               (ID                   int                  identity,
                                               HotelId              int                  not null,
                                               RoomTypeCode         int                  not null,
                                               AmountBeforeTax      decimal(18,4)        not null default 0,
                                               ListPrice            decimal(18,4)        not null default 0,
                                               BackAmount           decimal(18,4)        not null default 0,
                                               BackCode             nvarchar(100)        not null default '0',
                                               BackCurrencyCode     nvarchar(10)         not null default '',
                                               BackDescription      nvarchar(200)        not null default '',
                                               Breakfast            int                  not null default 0,
                                               NumberOfBreakfast    int                  not null default 0,
                                               CancelAmount         decimal(18,4)        null default 0,
                                               CancelCurrencyCode   nvarchar(10)         null default '',
                                               CancelPenaltyEndTime datetime             null default '1900-1-1',
                                               CancelPenaltyStartTime datetime             null default '1900-1-1',
                                               CurrencyCode         nvarchar(10)         not null default '',
                                               EndPeriod            datetime             not null default '1900-1-1',
                                               EndTime              datetime             not null default '1900-1-1',
                                               GuaranteeCode        nvarchar(10)         not null default '',
                                               HoldTime             datetime             not null default '1900-1-1',
                                               NumberOfGuests       int                  not null default 0,
                                               ProgramName          nvarchar(100)        not null,
                                               StartPeriod          datetime             not null default '1900-1-1',
                                               StartTime            datetime             not null default '1900-1-1',
                                               Status               nvarchar(10)         not null default '',
                                               AddDate              datetime             not null default getdate(),
                                               UpdateTime           datetime             not null default '1900-1-1',
                                               RatePlanCategory     int                  not null default 0,
                                               MarketCode           int                  not null default 0,
                                               IsInstantConfirm     int                  not null default 1,
                                               Pertain              text                 not null default '',
                                               SyncState            int                  not null default 0,
                                               constraint PK_T_HOTELSYNCROOMRATEPLANFORC_{1} primary key (ID)
                                            );", GetTableName(cityid),cityid);

            }

            defaultDatabase.Execute(tableBuildSql.ToString());
        }

        

        /// <summary>
        /// 删除过期数据
        /// </summary>
        /// <param name="cityIdList"></param>
        public void DeleteOverdueRoomRateData(List<int> cityIdList)
        {
            string date = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            StringBuilder deleteScripts = new StringBuilder();
            //string deleteScripts;
            foreach (var cityid in cityIdList)
            {
                deleteScripts.AppendFormat("delete from {0} where StartTime<='{1}';", GetTableName(cityid), date);
            }
            defaultDatabase.Execute(deleteScripts.ToString());
        }

        public List<T_XC_HotelRoomRatePlan> HotelSyncRoomRateGetToImportOnline(int cityId,int topCount=500)
        {
            string tableName = GetTableName(cityId);
            string querySQL = GetQuerySQL(typeof(T_XC_HotelRoomRatePlan),tableName);
            string selectSQL = string.Format("{0} where SyncState=0", querySQL);
            var items = defaultDatabase.Fetch<T_XC_HotelRoomRatePlan>(selectSQL);
            return items;
        }

        public bool HotelSyncRoomRateUpdatSyncState(List<int> roomRateIdList,int cityId)
        {
            string updateSQL = string.Format("update {0} set SyncState=1 where ID in ({1})",GetTableName(cityId),roomRateIdList.Join(","));
            return defaultDatabase.Execute(updateSQL)>0;

        }

        /// <summary>
        /// truncate所有酒店价格数据
        /// </summary>
        /// <param name="cityIdList"></param>
        public void TruncateHotelRoomRateData(List<int> cityIdList)
        {
            StringBuilder truncateScripts = new StringBuilder();
            foreach (var cityid in cityIdList)
            {
                truncateScripts.AppendFormat("truncate table {0};", GetTableName(cityid));
            }

            defaultDatabase.Execute(truncateScripts.ToString());
        }

        /// <summary>
        /// 删除城市归属错误的酒店价格计划
        /// </summary>
        /// <param name="cityIdList"></param>
        public void DeleteErrorCityRoomRatePlans(List<int> cityIdList)
        {
            StringBuilder deleteSql = new StringBuilder();

            cityIdList.ForEach(u => {
                deleteSql.AppendFormat("delete from T_XC_HotelRoomRatePlan_{0} where hotelid in(select hotelid from T_XC_HotelDescription where hotelcitycode!={0});",u);
            });
            defaultDatabase.Execute(deleteSql.ToString());
        }
    }
}
