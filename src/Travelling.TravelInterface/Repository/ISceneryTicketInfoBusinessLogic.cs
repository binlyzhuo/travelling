using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.Domain.Scenery;
using Travelling.ViewModel;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.Ticket;
using Travelling.ViewModel.Lucene;
using Travelling.ViewModel.Ticket;
using Travelling.ViewModel.Travel;

namespace Travelling.TravelInterface.Repository
{
    /// <summary>
    /// 景区业务接口
    /// </summary>
    public interface ISceneryTicketInfoBusinessLogic
    {
        void AddProvinces(List<T_SceneryProvinceDetailInfo> provinces);

        void AddSceneryTheme(List<T_SceneryTheme> themes);

        
        string GetSceneryThemeByThemeId(int themeId);

        /// <summary>
        /// 获取景区详细信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        SceneryInfoDetail GetSceneryInfoByID(int sceneryId);


        /// <summary>
        /// 获取门票价格策略
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        SceneryTicketPolicyInfo GetSceneryTicketPolicyInfo(int sceneryId);



        /// <summary>
        /// 获取热门城市信息
        /// </summary>
        /// <returns></returns>
        List<SceneryHotelCityInfo> GetHotSceneryCities();

        /// <summary>
        /// 获取景区主题信息
        /// </summary>
        /// <returns></returns>
        List<SceneryThemeInfo> GetSceneryThemes();


        
        //===========================================
        Tuple<List<SceneryTicketPrimaryInfo>, List<SceneryProvinceDetailInfo>> HotSceneryForProvinces();

        List<SceneryTicketPrimaryInfo> SceneryInfoSearch(int provinceId, int themeId, int starLevel, string keyWords, int page);

        /// <summary>
        /// 获取景点图片信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        List<SceneryImgInfo> GetSceneryImgInfos(int sceneryId);

        /// <summary>
        /// 获取景区价格信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        List<SceneryTicketPrice> GetTicketPriceBySceneryId(int sceneryId);

        /// <summary>
        /// 获取附近景点信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        List<SceneryTicketPrimaryInfo> GetNearSceneryInfo(int sceneryId);

        /// <summary>
        /// 获取景区交通信息
        /// </summary>
        /// <param name="sceneryInfo"></param>
        /// <returns></returns>
        SceneryTrafficInfo GetSceneryTrafficInfo(ISceneryInfo sceneryInfo);

        /// <summary>
        /// 根据城市获取景区信息
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        List<SceneryTicketPrimaryInfo> GetSceneryInfoByCityId(int cityId, int top = 10);

        /// <summary>
        /// 获取待索引数据
        /// </summary>
        /// <param name="topCount"></param>
        /// <returns></returns>
        List<SceneryInfoDetail> GetSceneryInfoForLucene(int topCount);

        /// <summary>
        /// 初始化索引状态
        /// </summary>
        void InitSceneryInfoLuceneState();

        /// <summary>
        /// 修改索引状态
        /// </summary>
        /// <param name="sceneryIdList"></param>
        void UpdateLuceneState(List<int> sceneryIdList);

        /// <summary>
        /// 创建索引文件
        /// </summary>
        /// <param name="action"></param>
        void SceneryInfoLuceneIndexCreate(Action<string> action);

        /// <summary>
        /// 景区信息查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Tuple<List<SceneryInfoDetail>, List<SceneryTicketPrice>,int> SceneryInfoQuery(SceneryQueryInfo query);

        /// <summary>
        /// 获取景区门票价格信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <param name="ticketId"></param>
        /// <param name="bookdate"></param>
        /// <returns></returns>
        SceneryTicketPrice GetSceneryTicketPriceInfo(int sceneryId, int policyId, DateTime bookdate);

        /// <summary>
        /// 根据景区所在城市获取附近酒店信息
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        List<HotelLuceneIndexInfo> GetHotelInfoBySceneryName(string cityName);

        /// <summary>
        /// 根据城市名获取景区信息
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        List<SceneryInfoDetail> GetSceneryInfoByCityName(string cityName);

        /// <summary>
        /// 景区门票预定
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <param name="policyId"></param>
        /// <param name="ticketCount"></param>
        /// <param name="bookDate"></param>
        /// <param name="linkMan"></param>
        /// <param name="linkTel"></param>
        /// <param name="remark"></param>
        /// <param name="totalAmount"></param>
        /// <returns></returns>
        SceneryTicketBookResult SceneryOrder(int sceneryId, int policyId, int ticketCount, DateTime bookDate, string linkMan, string linkTel, string remark, int totalAmount,string sceneryName);

        /// <summary>
        /// 根据订单号获取订单信息
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        SceneryTicketOrder GetSceneryRicketOrderByOrderNo(string orderNo);

        /// <summary>
        /// 获取景区相关省份城市信息
        /// </summary>
        /// <returns></returns>
        List<SceneryProvinceDetailInfo> GetSceneryProvincesAndCities();

        /// <summary>
        /// 获取景区省份信息
        /// </summary>
        /// <returns></returns>
        List<SceneryProvinceDetailInfo> GetSceneryProvinces();

        /// <summary>
        /// 根据省份id获取周边城市景区信息
        /// </summary>
        /// <param name="provinceId"></param>
        /// <returns></returns>
        Tuple<List<SceneryInfoDetail>, List<SceneryProvinceDetailInfo>> GetSceneryInfoByProvinceId(int provinceId);

        /// <summary>
        /// 获取酒店附近景点信息
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        List<SceneryInfoDetail> GetSceneryInfoByHotelCityName(string cityName);

        PageObjectResult<SceneryTicketOrder> SceneryTicketOrderGetPageResult(SceneryTicketOrderSearchModel search);

        /// <summary>
        /// 根据省份id获取省份城市信息
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        List<SceneryProvinceDetailInfo> GetSceneryCityInfoByProvinceId(int pid);

        Tuple<List<SceneryTicketPrimaryInfo>, List<SceneryProvinceDetailInfo>> HotSceneryForProvincesByGrade();

        List<SceneryInfoDetail> GetSceneryInfosBycCoordinate(string lat, string lng, decimal distance = 1, int topCount = 15);

        /// <summary>
        /// 根据省id获取省份信息
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
       SceneryProvinceDetailInfo GetSceneryProvinceInfoByProvinceID(int pid);
        
    }
}
