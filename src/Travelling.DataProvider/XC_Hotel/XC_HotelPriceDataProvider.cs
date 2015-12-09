using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.Domain.HotelSyncRecord;
using Travelling.TravelInterface.Data;
using Travelling.ViewModel.Travel;

namespace Travelling.DataProvider
{
    /// <summary>
    /// 酒店价格提供类
    /// </summary>
    public class XC_HotelPriceDataProvider : BaseRecord<T_XC_HotelPrice>, IXC_HotelPriceDataProvider
    {
        public XC_HotelPriceDataProvider()
        {
            this.defaultDatabase = OTA_HotelDatabase;
        }

        public List<HotelPrimaryInfo> RecommendHotels()
        {
            string executeSQL = "execute SP_RcommendHotels";
            var items = defaultDatabase.Query<HotelPrimaryInfo>(executeSQL);
            return items.ToList();
        }

        public List<HotelPrimaryInfo> HotHotels()
        {
            string executeSQL = "execute SP_HotHotels";
            var items = defaultDatabase.Query<HotelPrimaryInfo>(executeSQL);
            return items.ToList();
        }

        public int HotelPriceImport()
        {
            string executeSql = string.Format("execute {0}", HotelDatabaseStore.HotelPriceImport);
            int num = defaultDatabase.Execute(executeSql);
            return num;
        }

        public void HotelLowestPriceImport(List<int> cityIdList)
        {
            StringBuilder getPriceScripts = new StringBuilder();
            string tableName;
            foreach (var cityid in cityIdList)
            {
                tableName = string.Format("T_XC_HotelRoomRatePlan_{0}", cityid);
                getPriceScripts.AppendFormat(@"with cte{0} as(
                                select *,ROW_NUMBER() over(PARTITION by HotelId order by AmountBeforeTax asc) num from {1}
                                ) 
                                INSERT into T_XC_HotelPrice([HotelID]
                                        ,[RoomTypeCode]
                                        ,[AmountBeforeTax]
                                        ,[ListAmount]
                                        ,[AddDate])
                                select [HotelID]
                                        ,[RoomTypeCode]
                                        ,[AmountBeforeTax]
                                        ,[ListPrice]
                                        ,[AddDate] from cte{0} where num<=1;", cityid, tableName);
            }

            defaultDatabase.Execute(getPriceScripts.ToString());
        }

        /// <summary>
        /// 导入酒店最低价格数据
        /// </summary>
        public void ImportHotelMinPriceToDescription()
        {
            string sql = @"update T_XC_HotelDescription  set TrueAmount= p.AmountBeforeTax,ListAmount =p.ListAmount
                           from T_XC_HotelPrice p where p.HotelID = T_XC_HotelDescription.HotelID";

            defaultDatabase.Execute(sql);
        }
    }
}
