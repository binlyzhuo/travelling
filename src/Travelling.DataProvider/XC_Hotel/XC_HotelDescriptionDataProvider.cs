using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.HotelSyncRecord;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.DataLayer;
using Travelling.ViewModel.Lucene;
using Travelling.ViewModel.Hotel;
using Travelling.ViewModel.Travel;
using Travelling.ViewModel.Dto.Hotel;

namespace Travelling.DataProvider.HotelSyncRecord
{
    public class XC_HotelDescriptionDataProvider : BaseRecord<T_XC_HotelDescription>, IXC_HotelDescriptionDataProvider
    {
        private readonly string tableName;

        public new List<T_XC_HotelDescription> All()
        {
            throw new Exception("error sql execute");
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public XC_HotelDescriptionDataProvider()
        {
            this.defaultDatabase = OTA_HotelDatabase;
            tableName = "T_XC_HotelDescription";
        }

        public List<T_XC_HotelDescription> GetHotelInfoBySyncState(bool syncState,int topCount)
        {
            Sql buildSql = Sql.Builder.Where("SyncState = 0");
            return Top(topCount, buildSql).ToList();
        }

        public void UpdateSyncState(List<int> hotelIdList,bool syncState)
        {
            string idString = string.Join(",", hotelIdList);
            string sql = string.Format("update {2} set SyncState = {1} where HotelID in ({0})", idString, syncState?1:0,tableName);
            defaultDatabase.Execute(sql);
        }

        /// <summary>
        /// 获取待lucene索引数据
        /// </summary>
        /// <returns></returns>
        public List<HotelLuceneIndexInfo> GetHotelInfoByIndexState()
        {
            string sql = string.Format("exec {0}", HotelSyncRecordDataStore.HotelLuceneIndexRecord);
            var records = defaultDatabase.FetchMultiple<HotelLuceneIndexInfo, HotelRefPointPrimaryInfo>(sql);

            if (records.Item1 == null || records.Item1.Count == 0)
                return null;
            records.Item1.ForEach(u => {
                u.RefPoints = records.Item2 != null ? string.Join(",", records.Item2.Where(u2 => { return u2.HotelId == u.HotelID.ToString(); }).ToList().Select(u3 => { return u3.Name; }).ToList()) : "";
            });
            return records.Item1;
        }

        public bool UpdateIndexState(List<int> hotelids)
        {
            string updateSql = string.Format("update {1} set IsIndex=1 where HotelId in({0})",string.Join(",",hotelids),tableName);
            return defaultDatabase.Execute(updateSql)>0;
        }

        public int WaitIndexRecordCount()
        {
            Sql countSql = Sql.Builder.Where("IsIndex=0");
            return Count(countSql);
        }

        public void InitHotelInfoLuceneIndexRecord()
        {
            string updateSql = string.Format("update {0} set IsIndex=0",tableName);
            defaultDatabase.Execute(updateSql);
        }

        public void UpdateSyncState(bool syncState)
        {
            string updateSql = string.Format("update {1} set SyncState={0}",syncState?1:0,tableName);
            defaultDatabase.Execute(updateSql);
        }

        /*
          ui
         */
        /// <summary>
        /// 获取热门城市酒店信息
        /// </summary>
        /// <returns></returns>
        public Tuple<List<HotelPrimaryInfo>, List<HotelCityDetailInfo>> GetHotCityHotelInfos()
        {
            string executeSql = string.Format("exec {0}", HotelDatabaseStore.HotCityHotelInfos);

            return defaultDatabase.FetchMultiple<HotelPrimaryInfo, HotelCityDetailInfo>(executeSql);

        }


        /// <summary>
        /// 获取精选城市酒店信息
        /// </summary>
        /// <returns></returns>
        public Tuple<List<HotelPrimaryInfo>, List<HotelCityDetailInfo>> GetChoiceCityHotelInfos()
        {
            string executeSql = string.Format("exec {0}", HotelDatabaseStore.ChoiceHotelCityInfos);
            return defaultDatabase.FetchMultiple<HotelPrimaryInfo, HotelCityDetailInfo>(executeSql);

        }

        /// <summary>
        /// 获取附近酒店
        /// </summary>
        /// <param name="hotelid"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public List<HotelPrimaryInfo> GetNearHotelInfos(int hotelid, float distance)
        {
            var items = defaultDatabase.Query<HotelPrimaryInfo>(string.Format("exec {0} @hotelid,@distance", HotelDatabaseStore.HotelNearHotelInfos), new { hotelid = hotelid, distance = distance });
            return items.ToList();
        }

        public List<HotelQueryPrimaryInfo> HotelQueryResult()
        {
            //ExecuteProc(HotelDatabaseStore.HotelFullQuery);
            string executeSql = string.Format("exec {0}", HotelDatabaseStore.HotelFullQuery);
            return defaultDatabase.Query<HotelQueryPrimaryInfo>(executeSql).ToList();
        }

        public List<HotelRoomRatePlanInfo> HotelRoomPlanQuery()
        {
            string executeSql = string.Format("exec {0}", HotelDatabaseStore.HotelRoomPriceQuery);
            return defaultDatabase.Query<HotelRoomRatePlanInfo>(executeSql).ToList();
        }

        /// <summary>
        /// 获取待Lucene索引酒店信息
        /// </summary>
        /// <param name="topCount"></param>
        /// <returns></returns>
        public List<T_XC_HotelDescription> GetRecordForLuceneIndex(int topCount = 100)
        {
            Sql sqlCount = Sql.Builder.Where("IsIndex = 0");
            return base.Top(topCount, sqlCount).ToList();
        }

        
        /// <summary>
        /// 获取推荐酒店-按照价格差排名
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public List<HotelPrimaryInfo> HotelPracticalForCity(int cityId)
        {
            string executeSql = string.Format("exec {0} @cityid", HotelDatabaseStore.HotelPracticalForCity);
            var hotelinfos = defaultDatabase.Query<HotelPrimaryInfo>(executeSql, new { cityid = cityId }).ToList();
            return hotelinfos;
        }

        /// <summary>
        /// 同步酒店价格
        /// </summary>
        /// <returns></returns>
        public bool UpdateHotelMinPrice()
        {
            string sql = @"update T_HotelDescription set TrueAmount = p.AmountBeforeTax,ListAmount = p.ListAmount
                           from T_HotelPrice p where p.HotelID = T_HotelDescription.HotelID ";

            return defaultDatabase.Execute(sql) > 0;
        }

        /// <summary>
        /// 酒店品牌统计信息
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃")]
        public List<HotelBrandSummaryInfo> HotelBrandSummaryInfos()
        {
            string sql = @"select t0.HotelCount,t0.HotelCityCode,t0.CityName,t0.CityEName,t0.BrandName,t0.BrandID,UPPER(SUBSTRING(t0.CityEName,1,1)) OrderFlag from (
                            select count(h.HotelID) HotelCount,h.HotelCityCode,h.CityName,c.CityEName,b.BrandName,b.BrandID from T_XC_HotelDescription h WITH(NOLOCK)
                            inner join T_XC_HotelCityDetailInfo c WITH(NOLOCK) on c.CityID = h.HotelCityCode
                            inner join T_XC_HotelBrandDetailInfo b WITH(NOLOCK) on h.BrandCode = b.BrandID
                            GROUP by h.HotelCityCode,b.BrandID,b.BrandName,h.CityName,c.CityEName) t0 where t0.CityEName!=''";
            var items = defaultDatabase.Fetch<HotelBrandSummaryInfo>(sql);
            return items;
        }

        /// <summary>
        /// 统计城市酒店
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃")]
        public List<HotelCitySummaryInfo> HotelCitySummaryInfos()
        {
            string sql = @"select d.HotelName,d.HotelID,d.BrandCode,d.BrandName,d.CityName,d.HotelCityCode from T_XC_HotelDescription d with(NOLOCK) 
                           inner join T_XC_HotelBrandDetailInfo h WITH(NOLOCK) on d.BrandCode = h.BrandID";
            var items = defaultDatabase.Fetch<HotelCitySummaryInfo>(sql);
            return items;

        }

        /// <summary>
        /// 最优惠酒店信息
        /// </summary>
        /// <returns></returns>
        public List<HotelPrimaryInfo> HotelMostPractical()
        {
            string executeSql = string.Format("exec {0}", HotelDatabaseStore.HotelMostPractical);
            var items = defaultDatabase.Fetch<HotelPrimaryInfo>(executeSql);
            return items;
        }

        /// <summary>
        /// 经济型酒店信息
        /// </summary>
        /// <returns></returns>
        public List<HotelPrimaryInfo> HotelCheapMost()
        {
            string executeSql = string.Format("exec {0}", HotelDatabaseStore.HotelCheapMost);
            var items = defaultDatabase.Fetch<HotelPrimaryInfo>(executeSql);
            return items;
        }

    }
}
