using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.TravelInterface.Data;
using Travelling.ViewModel.Travel;
using Travelling.DataLayer;

namespace Travelling.DataProvider
{
    /// <summary>
    /// 景区信息
    /// </summary>
    public class SceneryInfoSyncRecordDataProvider : BaseRecord<T_SceneryInfoSyncRecord>, ISceneryInfoSyncRecordDataProvider
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SceneryInfoSyncRecordDataProvider()
        {
            this.defaultDatabase = sceneryDb;
        }

        public List<SceneryRecommendViewModel> SceneryHotForProvinces()
        {
//            string sql = @"select s.SceneryID,s.ProvinceName,s.ProvinceID,s.CityID,s.SceneryName,s.AmountAdvice,s.ImgBaseUrl,s.Imgs,s.CityName from t_sceneryinfodetail s
//                            where 10>(select count(*) from t_sceneryinfodetail where s.ProvinceID=ProvinceID and SceneryID<s.SceneryID)
//                            and s.provinceid in (select provinceid from t_sceneryhotprovince)
//                            order by s.ProvinceName";
//            var items = defaultDatabase.Query<SceneryRecommendViewModel>(sql).ToList();
//            return items;
            return new List<SceneryRecommendViewModel>();
        }

        /// <summary>
        /// 获取待同步景区记录
        /// </summary>
        /// <param name="topCount"></param>
        /// <returns></returns>
        public List<T_SceneryInfoSyncRecord> GetRecordForSceneryDetailSync(int topCount=5)
        {
            Sql buildSql = Sql.Builder.Where("DetailSyncState=@0", 0);
            var items = Top(topCount, buildSql).ToList();
            return items;
        }

        /// <summary>
        /// 获取待同步景区价格信息
        /// </summary>
        /// <param name="topCount"></param>
        /// <returns></returns>
        public List<T_SceneryInfoSyncRecord> GetRecordForPriceSync(int topCount = 5)
        {
            Sql buildSql = Sql.Builder.Where("PriceSyncState=@0", 0);
            var items = Top(topCount, buildSql).ToList();
            return items;
        }

        /// <summary>
        /// 获取待同步景区图片记录
        /// </summary>
        /// <param name="topCount"></param>
        /// <returns></returns>
        public List<T_SceneryInfoSyncRecord> GetRecordForSceneryImgsSync(int topCount = 5)
        {
            Sql buildSql = Sql.Builder.Where("ImgSyncState=@0", 0);
            var items = Top(topCount, buildSql).ToList();
            return items;
        }

        /// <summary>
        /// 更新景区详细信息同步状态
        /// </summary>
        public void UpdateSceneryDetailInfoSyncState()
        {
            string sql = "update T_SceneryInfoSyncRecord set DetailSyncState = 0";
            Execute(sql);

        }

        /// <summary>
        /// 设置价格同步状态
        /// </summary>
        public void UpdateSceneryPriceInfoSyncState()
        {
            string sql = "update T_SceneryInfoSyncRecord set PriceSyncState = 0";
            Execute(sql);
        }

        /// <summary>
        /// 设置图片同步状态
        /// </summary>
        public void UpdateSceneryImgInfoSyncState()
        {
            string sql = "update T_SceneryInfoSyncRecord set ImgSyncState = 0";
            Execute(sql);
        }

        public int SceneryInfoCountToSyncPrice()
        {
            Sql where = Sql.Builder.Where("PriceSyncState=0");
            return Count(where);
        }
    }
}
