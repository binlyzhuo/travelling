using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.Domain.Scenery;
using Travelling.TravelInterface.Data;
using Travelling.ViewModel.Dto.Ticket;
using Travelling.ViewModel.Ticket;
using Travelling.ViewModel.Travel;
using Travelling.FrameWork;
using Travelling.DataLayer;

namespace Travelling.DataProvider.Scenery
{
    /// <summary>
    /// 景区详细信息数据
    /// </summary>
    public class SceneryInfoDetailDataProvider : BaseRecord<T_SceneryInfoDetail>, ISceneryInfoDetailDataProvider
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SceneryInfoDetailDataProvider()
        {
            base.defaultDatabase = sceneryDb;
            
        }

        /// <summary>
        /// 获取国内热门景点城市
        /// </summary>
        /// <returns></returns>
        public List<SceneryHotelCityInfo> GetHotSceneryCities()
        {
            string sql = @"select top 12 COUNT(1) as SceneryCount,CityName,CityID,ProvinceID from T_SceneryInfoDetail 
                            GROUP BY CityID,CityName,ProvinceID
                            order by scenerycount desc";
            var items = defaultDatabase.Query<SceneryHotelCityInfo>(sql).ToList();
            return items;

        }


        /// <summary>
        /// 获取热门省份景点信息
        /// </summary>
        /// <returns></returns>
        public Tuple<List<SceneryTicketPrimaryInfo>, List<SceneryProvinceDetailInfo>> HotSceneryForProvinces()
        {
            string executeSql = string.Format("exec {0}",SceneryTicketDataStore.HotSceneryForProvinces);
            var items = defaultDatabase.FetchMultiple<SceneryTicketPrimaryInfo, SceneryProvinceDetailInfo>(executeSql);
            return items;
        }

        /// <summary>
        /// 获取热门省份景点信息
        /// </summary>
        /// <returns></returns>
        public Tuple<List<SceneryTicketPrimaryInfo>, List<SceneryProvinceDetailInfo>> HotSceneryForProvincesByGrade()
        {
            string executeSql = string.Format("exec {0}", SceneryTicketDataStore.HotSceneryForProvincesByGrade);
            var items = defaultDatabase.FetchMultiple<SceneryTicketPrimaryInfo, SceneryProvinceDetailInfo>(executeSql);
            return items;
        }

        /// <summary>
        /// 获取景区信息
        /// </summary>
        /// <param name="provinceId"></param>
        /// <param name="themeId"></param>
        /// <param name="startLevel"></param>
        /// <param name="keyWords"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<SceneryTicketPrimaryInfo> SceneryInfoQuery(int provinceId, int themeId, int startLevel, string keyWords, int page, int pageSize)
        {
            var sceneryInfos = defaultDatabase.Fetch<SceneryTicketPrimaryInfo>(string.Format("exec {0} @provinceid,@themeid,@startlevel,@keyword,@page,@pagesize", SceneryTicketDataStore.SceneryInfoSearch), new { provinceid = provinceId, themeid = themeId, startlevel = startLevel, keyword = keyWords, page = page, pagesize = pageSize });
            return sceneryInfos;
        }

        /// <summary>
        /// 获取景区主要信息
        /// </summary>
        /// <param name="sceneryIds"></param>
        /// <returns></returns>
        public List<SceneryTicketPrimaryInfo> GetSceneryInfoByIdList(List<int> sceneryIds)
        {
            string sql = string.Format("select top 12 SceneryID,SceneryName,AmountAdvice,ImgBaseUrl,Imgs,ProvinceId,CityName from T_SceneryInfoDetail with(NOLOCK) where SceneryID in({0})", sceneryIds.Join(","));
            var items = defaultDatabase.Query<SceneryTicketPrimaryInfo>(sql).ToList();
            return items;
        }

        /// <summary>
        /// 根据城市id获取推荐景区信息
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<SceneryTicketPrimaryInfo> GetRecommendSceneryForCity(int cityId,int top = 10)
        {
            string sql = string.Format(@"select top {0} SceneryID,SceneryName,AmountAdvice,ImgBaseUrl,Imgs from T_SceneryInfoDetail where CityID={1}
                                         order by GradeId DESC,AmountAdvice desc",top,cityId);
            var items = defaultDatabase.Query<SceneryTicketPrimaryInfo>(sql).ToList();
            return items;
        }

        /// <summary>
        /// 获取景区信息lucene
        /// </summary>
        /// <param name="topCount"></param>
        /// <returns></returns>
        public List<T_SceneryInfoDetail> GetSceneryInfoForLuceneIndex(int topCount=100)
        {
            Sql whereSql = Sql.Builder.Where("IsIndex=0");
            var items = Top(topCount, whereSql).ToList();
            return items;
        }

        /// <summary>
        /// 初始化索引状态为未索引
        /// </summary>
        public void InitSceneryIndexLuceneState()
        {
            string updateSql = "update T_SceneryInfoDetail set IsIndex=0";
            defaultDatabase.Execute(updateSql);
        }

        /// <summary>
        /// 修改索引状态为未索引
        /// </summary>
        /// <param name="sceneryIds"></param>
        public void UpdateLuceneState(List<int> sceneryIds)
        {
            string sceneryIdStr = sceneryIds.Join(",");
            string updateSql = string.Format("update T_SceneryInfoDetail set IsIndex=1 where SceneryID in ({0})", sceneryIdStr);
            defaultDatabase.Execute(updateSql);
        }

        /// <summary>
        /// 根据省份id获取景区信息
        /// </summary>
        /// <param name="provinceId"></param>
        /// <returns></returns>
        public Tuple<List<SceneryInfoDetail>, List<SceneryProvinceDetailInfo>> GetSceneryInfoByProvinceId(int provinceId)
        {
            string sql = string.Format(@"select * from (
                            select ROW_NUMBER() over(PARTITION BY d.CityID order by d.GradeId DESC) num,d.* from T_SceneryInfoDetail d
                            inner join T_SceneryProvinceDetailInfo p on d.ProvinceID =p.ID
                            where p.ID={0}) t0
                            WHERE t0.num<=16;
                            select top 10  * from T_SceneryProvinceDetailInfo where ParentID={0} order by SceneryCount desc;", provinceId);

            var sceneryinfos = defaultDatabase.FetchMultiple<SceneryInfoDetail, SceneryProvinceDetailInfo>(sql);
            return sceneryinfos;
        }

        public List<T_SceneryInfoDetail> GetSceneryInfosBycCoordinate(string lat,string lng,decimal distance=1,int topCount=15)
        {
            string sql = string.Format("execute {0} @lat,@lng,@distance,@topcount", "SP_GetNearSceneryInfos");
            var items = defaultDatabase.Fetch<T_SceneryInfoDetail>(sql, new { lat=lat,lng=lng,distance=distance,topcount=topCount });
            return items;
        }
    }
}
