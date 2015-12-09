using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.Domain.Hotel;
using Travelling.TravelInterface.Data.Hotel;
using Travelling.ViewModel.Admin;
using Travelling.FrameWork;
using Travelling.ViewModel.Hotel;

namespace Travelling.DataProvider.Hotel
{
    /// <summary>
    /// 酒店城市信息
    /// </summary>
    public class XC_HotelCityDetailInfoDataProvider : BaseRecord<T_XC_HotelCityDetailInfo>, IXC_HotelCityDetailInfoDataProvider
    {

        private readonly string tableName;

        /// <summary>
        /// 构造函数
        /// </summary>
        public XC_HotelCityDetailInfoDataProvider()
        {
            this.defaultDatabase = OTA_HotelDatabase;
            tableName = "T_XC_HotelCityDetailInfo";
        }

        /// <summary>
        /// 酒店城市信息查询
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public Page<T_XC_HotelCityDetailInfo> GetHotelCityDetailInfo(HotelCityDetailSearchModel searchModel)
        {
            Sql whereSql = Sql.Builder.Where("1=1");
            if (searchModel.ProvinceId > 0)
            {
                whereSql.Where("ProvinceID=@0", searchModel.ProvinceId);
            }
            if (!string.IsNullOrEmpty(searchModel.CityName))
            {
                whereSql.Where("CityName like @0", "%" + searchModel.CityName + "%");
            }
            if (searchModel.IsRecommend != null)
            {
                whereSql.Where("IsRecommendCity=@0", searchModel.IsRecommend);
            }
            if (searchModel.IsHotcity != null)
            {
                whereSql.Where("IsHotCity=@0", searchModel.IsHotcity);
            }
            if (searchModel.IsSearchRecommend != null)
            {
                //whereSql.Where("IsAutoCompleteCity=@0", searchModel.IsSearchRecommend);
            }
            var pageResult = defaultDatabase.Page<T_XC_HotelCityDetailInfo>(searchModel.PageIndex, searchModel.PageSize, whereSql);
            return pageResult;
        }

        public bool UpdateRecommendState(List<int> cityidList, int state)
        {
            string sql = string.Format("update {2} set IsRecommendCity ={0} where CityID in ({1})", state, cityidList.Join(","),tableName);
            return defaultDatabase.Execute(sql) > 0;
        }

        public bool UpdateHotCityState(List<int> cityidList, int state)
        {
            string sql = string.Format("update {2} set IsHotCity ={0} where CityID in ({1})", state, cityidList.Join(","),tableName);
            return defaultDatabase.Execute(sql) > 0;
        }

        public bool UpdateSearchCityState(List<int> cityidList, int state)
        {
            string sql = string.Format("update {2} set IsAutoCompleteCity ={0} where CityID in ({1})", state, cityidList.Join(","),tableName);
            return defaultDatabase.Execute(sql) > 0;
        }

        public List<T_XC_HotelCityDetailInfo> HotelCityDetailInfoSearch(HotelCityDetailSearchType searchType)
        {
            Sql sqlWhere = Sql.Builder.Where("1=1");
            switch (searchType)
            {
                case HotelCityDetailSearchType.All:
                    return All();
                case HotelCityDetailSearchType.SearchRecommend:
                    sqlWhere.Where("");
                    return defaultDatabase.Fetch<T_XC_HotelCityDetailInfo>(sqlWhere);

            }
            return null;
        }

        public T_XC_HotelCityDetailInfo HotelCityDetailInfoToSyncHotelInfo(int topCount = 1)
        {
            Sql where = Sql.Builder.Where("SyncState=0");
            return Top(topCount, where).SingleOrDefault();
        }

        public bool HotelCityDetailInfoUpdateSyncState(List<int> cityIdList)
        {
            string sql = string.Format("update {2} set SyncState ={0} where CityID in ({1})", 1, cityIdList.Join(","), tableName);
            return defaultDatabase.Execute(sql) > 0;
        }

        /// <summary>
        /// 酒店查询信息初始化
        /// </summary>
        /// <returns></returns>
        public bool HotelCityDetailInfoInitSyncState()
        {
            string sql = string.Format("update {1} set SyncState ={0}", 0, tableName);
            return defaultDatabase.Execute(sql) > 0;
        }

        /// <summary>
        /// 获取未同步城市个数
        /// </summary>
        /// <returns></returns>
        public int HotelCityDetailInfoGetToSyncStateCount()
        {
            Sql where = Sql.Builder.Where("SyncState=0");
            return Count(where);
        }
    }
}
