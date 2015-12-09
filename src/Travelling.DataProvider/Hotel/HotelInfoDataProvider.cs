using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Hotel;
using Travelling.TravelInterface.Data.Hotel;
using Travelling.ViewModel.Lucene;
using Travelling.FrameWork;
using Travelling.DataLayer;
using Travelling.ViewModel.Travel;

namespace Travelling.DataProvider.Hotel
{
    /// <summary>
    /// 酒店资源数据源
    /// </summary>
    public class HotelInfoDataProvider : BaseRecord<T_HotelInfo>, IHotelInfoDataProvider
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public HotelInfoDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }

        public List<HotelLuceneIndexInfo> HotelsToLucene()
        {
            string sql = string.Format("execute {0}", "P_HotelInfoToIndex");
            var items = defaultDatabase.Fetch<HotelLuceneIndexInfo>(sql);
            return items;
        }

        public void InitHotelInfoIndexState()
        {
            string sql = "update OTA_TCHotel.dbo.T_HotelInfo set IndexState=0";
            defaultDatabase.Execute(sql);
        }

        public void UpdateIndexState(List<int> idList)
        {
            string sql = string.Format("update OTA_TCHotel.dbo.T_HotelInfo set IndexState=1 where ID in({0})", idList.Join(","));
            defaultDatabase.Execute(sql);
        }

        public int GetHotelIndexCount(bool isIndex)
        {
            Sql countSql = Sql.Builder.Where("indexstate=@0", isIndex?1:0);
            return Count(countSql);
        }

        /// <summary>
        /// 酒店品牌统计信息
        /// </summary>
        /// <returns></returns>
        public List<HotelBrandSummaryInfo> HotelBrandSummaryInfos()
        {
            string sql = string.Format("execute {0}", "P_HotelCityBrandSummary");
            var items = defaultDatabase.Fetch<HotelBrandSummaryInfo>(sql);
            return items;
        }

        public List<HotelCitySummaryInfo> HotelCitySummaryInfos()
        {
            string sql = string.Format("execute {0}", "P_HotelBrandCitySummary");
            var items = defaultDatabase.Fetch<HotelCitySummaryInfo>(sql);
            return items;
        }
    }
}
