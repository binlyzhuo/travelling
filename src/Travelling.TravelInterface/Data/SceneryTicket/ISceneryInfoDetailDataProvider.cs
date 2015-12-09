using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.Domain.Scenery;
using Travelling.ViewModel.Dto.Ticket;
using Travelling.ViewModel.Ticket;
using Travelling.ViewModel.Travel;

namespace Travelling.TravelInterface.Data
{
    /// <summary>
    /// 景区详细信息接口
    /// </summary>
    public interface ISceneryInfoDetailDataProvider : IDataProvider<T_SceneryInfoDetail>
    {
        List<SceneryHotelCityInfo> GetHotSceneryCities();

        

        
        Tuple<List<SceneryTicketPrimaryInfo>, List<SceneryProvinceDetailInfo>> HotSceneryForProvinces();

        List<SceneryTicketPrimaryInfo> SceneryInfoQuery(int provinceId, int themeId, int startLevel, string keyWords, int page, int pageSize);

        /// <summary>
        /// 根据景区id获取景区主要信息
        /// </summary>
        /// <param name="sceneryIds"></param>
        /// <returns></returns>
        List<SceneryTicketPrimaryInfo> GetSceneryInfoByIdList(List<int> sceneryIds);

        /// <summary>
        /// 
        /// 获取推荐景区信息
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        List<SceneryTicketPrimaryInfo> GetRecommendSceneryForCity(int cityId, int top = 10);

        /// <summary>
        /// sceneryinfo foe lucene
        /// </summary>
        /// <param name="topCount"></param>
        /// <returns></returns>
        List<T_SceneryInfoDetail> GetSceneryInfoForLuceneIndex(int topCount = 100);

        /// <summary>
        /// 初始化索引状态
        /// </summary>
        void InitSceneryIndexLuceneState();

        /// <summary>
        /// 修改索引状态为未索引
        /// </summary>
        /// <param name="sceneryIds"></param>
        void UpdateLuceneState(List<int> sceneryIds);

        /// <summary>
        /// 根据省份ID获取周边城市景点信息
        /// </summary>
        /// <param name="provinceId"></param>
        /// <returns></returns>
        Tuple<List<SceneryInfoDetail>, List<SceneryProvinceDetailInfo>> GetSceneryInfoByProvinceId(int provinceId);

        Tuple<List<SceneryTicketPrimaryInfo>, List<SceneryProvinceDetailInfo>> HotSceneryForProvincesByGrade();

        List<T_SceneryInfoDetail> GetSceneryInfosBycCoordinate(string lat, string lng, decimal distance = 1, int topCount = 15);

    }
}
