using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.TravelInterface.Data;
using Travelling.TravelInterface.Repository;
using Ninject;
using Travelling.FrameWork;
using Travelling.OpenApiEntity.Scenery;
using Travelling.OpenApiLogic;
using Travelling.ViewModel.Travel;
using Travelling.Domain.Scenery;
using Travelling.DataProvider.Scenery;
using Travelling.OpenApiEntity.Scenery.Module;
using Travelling.ViewModel.Ticket;
using Travelling.ViewModel.Dto.Ticket;
using Travelling.Caching;
using Travelling.TravelInterface.Data.SceneryTicket;
using Travelling.ViewModel;
using Travelling.ViewModel.Lucene;
using Travelling.ViewModel.Admin;
using Travelling.Lucene;

namespace Travelling.Repository
{
    /// <summary>
    /// 景区门票相关业务
    /// </summary>
    public class SceneryTicketInfoBusinessLogic : BaseTicketLogic, ISceneryTicketInfoBusinessLogic
    {
        
        private readonly ISceneryThemeDataProvider sceneryThemeData;
        
        private readonly ISceneryInfoSyncRecordDataProvider sceneryInfoSyncData;
        
        private readonly ISceneryInfoDetailDataProvider sceneryInfoDetailData;
        private readonly ISceneryImgInfoDataProvider sceneryImgData;
        private readonly ISceneryTicketPriceDataProvider ticketData;
        private readonly ISceneryTicketOrderDataProvider ticketOrderData;
        private readonly ISceneryProvinceDetailInfoDataProvider provinceInfoData;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SceneryTicketInfoBusinessLogic()
        {
           
            sceneryThemeData = kernel.Get<ISceneryThemeDataProvider>();
            
            sceneryInfoSyncData = kernel.Get<ISceneryInfoSyncRecordDataProvider>();
            
            sceneryInfoDetailData = kernel.Get<SceneryInfoDetailDataProvider>();
            sceneryImgData = kernel.Get<ISceneryImgInfoDataProvider>();
            ticketData = kernel.Get<ISceneryTicketPriceDataProvider>();
            ticketOrderData = kernel.Get<ISceneryTicketOrderDataProvider>();
            provinceInfoData = kernel.Get<ISceneryProvinceDetailInfoDataProvider>();
        }

        /// <summary>
        /// 初始化景区省份信息
        /// </summary>
        /// <param name="provinces"></param>
        public void AddProvinces(List<T_SceneryProvinceDetailInfo> provinces)
        {
            provinceInfoData.Truncate();
            provinceInfoData.InsertBulk(provinces);
        }

        /// <summary>
        /// 初始化景区主题信息
        /// </summary>
        /// <param name="themes"></param>
        public void AddSceneryTheme(List<T_SceneryTheme> themes)
        {
            sceneryThemeData.Truncate();
            sceneryThemeData.InsertBulk(themes);
        }

        /// <summary>
        /// 获取景区详细信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        public SceneryInfoDetail GetSceneryInfoByID(int sceneryId)
        {
            var sceneryinfo = (from it in GetAllSceneryInfoDetails()
                               where it.SceneryID == sceneryId
                               select it).SingleOrDefault();
            return sceneryinfo;
        }

        /// <summary>
        /// 获取景区图片信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        public List<SceneryImgInfo> GetSceneryImgInfos(int sceneryId)
        {
            //var rep = SceneryTicketServiceLogic.GetSceneryImageList(sceneryId);
            //List<SceneryImgInfo> imgInfos = new List<SceneryImgInfo>();
            //var imgs = rep.ImgList.GetRange(0, 10);
            //SceneryImgInfo imgInfo;
            //imgs.ForEach(u =>
            //{
            //    imgInfo = new SceneryImgInfo();
            //    string smallImgSize = rep.SizeCodeList[rep.SizeCodeList.Count - 1].SizeValue;
            //    string bigImgSize = rep.SizeCodeList[rep.SizeCodeList.Count - 1].SizeValue;
            //    //imgInfo. = string.Format("{0}{1}/{2}", rep.imageBaseUrl, bigImgSize, u);
            //    //imgInfo.SmallImgUrl = string.Format("{0}{1}/{2}", rep.imageBaseUrl, smallImgSize, u);
            //    imgInfos.Add(imgInfo);
            //});
            //return imgInfos;

            var imgInfos = sceneryImgData.GetSceneryImgs(sceneryId);
            List<SceneryImgInfo> imgInfosDto = AutoMapper.Mapper.Map<List<T_SceneryImgInfo>, List<SceneryImgInfo>>(imgInfos);
            return imgInfosDto;
        }

        /// <summary>
        /// 获取景区价格策略
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        public SceneryTicketPolicyInfo GetSceneryTicketPolicyInfo(int sceneryId)
        {
            var rep = SceneryTicketServiceLogic.GetSceneryPrice(sceneryId);
            SceneryTicketPolicyInfo policyInfo = new SceneryTicketPolicyInfo();
            policyInfo.SceneryId = sceneryId;

            policyInfo.Policys = AutoMapper.Mapper.Map<List<SceneryPolicy>, List<TicketPolicyInfo>>(rep.SceneryPrices[0].Policies);
            return policyInfo;
        }

        /// <summary>
        /// 获取国内景点热门城市
        /// </summary>
        /// <returns></returns>
        public List<SceneryHotelCityInfo> GetHotSceneryCities()
        {
            List<SceneryHotelCityInfo> items = cacheProvider.GetCacheItem<List<SceneryHotelCityInfo>>(CacheKeys.SceneryHotCityInfos);
            if(items==null)
            {
                items = sceneryInfoDetailData.GetHotSceneryCities();
                cacheProvider.InsertCacheItems(CacheKeys.SceneryHotCityInfos,items);
            }
            return items;
        }


        public Tuple<List<SceneryTicketPrimaryInfo>, List<SceneryProvinceDetailInfo>> HotSceneryForProvinces()
        {
            var hotSceneries = cacheProvider.GetCacheItem<Tuple<List<SceneryTicketPrimaryInfo>, List<SceneryProvinceDetailInfo>>>(CacheKeys.HotProvinceSceneryInfos);
            if(hotSceneries==null)
            {
                hotSceneries =  sceneryInfoDetailData.HotSceneryForProvinces();
                cacheProvider.InsertCacheItems(CacheKeys.HotProvinceSceneryInfos, hotSceneries);
            }
            return hotSceneries;
        }

        public Tuple<List<SceneryTicketPrimaryInfo>, List<SceneryProvinceDetailInfo>> HotSceneryForProvincesByGrade()
        {
            var hotSceneries = cacheProvider.GetCacheItem<Tuple<List<SceneryTicketPrimaryInfo>, List<SceneryProvinceDetailInfo>>>(CacheKeys.HotSceneryForProvincesByGrade);
            if (hotSceneries == null)
            {
                hotSceneries = sceneryInfoDetailData.HotSceneryForProvincesByGrade();
                cacheProvider.InsertCacheItems(CacheKeys.HotSceneryForProvincesByGrade, hotSceneries);
            }
            return hotSceneries;
        }

        /// <summary>
        /// 获取景区主题信息
        /// </summary>
        /// <returns></returns>
        public List<SceneryThemeInfo> GetSceneryThemes()
        {
            var themesData = cacheProvider.GetCacheItem<List<SceneryThemeInfo>>(CacheKeys.SceneryThemeInfos);
            if(themesData==null)
            {
                themesData = AutoMapper.Mapper.Map<List<T_SceneryTheme>, List<SceneryThemeInfo>>(sceneryThemeData.All());
                cacheProvider.InsertCacheItems(CacheKeys.SceneryThemeInfos, themesData);
            }
            return themesData;
        }

        public string GetSceneryThemeByThemeId(int themeId)
        {
            var theme = GetSceneryThemes().Where(u => u.ID == themeId).SingleOrDefault();
            return theme != null ? theme.Name : "";
        }

        /// <summary>
        /// 景区主要信息
        /// </summary>
        /// <param name="provinceId"></param>
        /// <param name="themeId"></param>
        /// <param name="starLevel"></param>
        /// <param name="keyWords"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<SceneryTicketPrimaryInfo> SceneryInfoSearch(int provinceId, int themeId, int starLevel, string keyWords, int page)
        {
           return  sceneryInfoDetailData.SceneryInfoQuery(provinceId,themeId,starLevel,keyWords,page,10);
        }

        /// <summary>
        /// 根据景区id获取景区价格信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        public List<SceneryTicketPrice> GetTicketPriceBySceneryId(int sceneryId)
        {
            var ticketPrices = ticketData.GetTicketPriceBySceneryId(sceneryId);
            var ticketPricesDto = AutoMapper.Mapper.Map<List<T_SceneryTicketPrice>, List<SceneryTicketPrice>>(ticketPrices);
            return ticketPricesDto;
        }

        /// <summary>
        /// 获取景区附近景点信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        public List<SceneryTicketPrimaryInfo> GetNearSceneryInfo(int sceneryId)
        {
            var sceneryIdList = SceneryTicketServiceLogic.GetNearbyScenery(sceneryId);
            if (sceneryIdList == null || sceneryIdList.Count == 0)
                return null;
            var sceneryInfos = sceneryInfoDetailData.GetSceneryInfoByIdList(sceneryIdList);
            return sceneryInfos;
        }

        /// <summary>
        /// 获取景区交通信息
        /// </summary>
        /// <param name="sceneryInfo">景区信息接口</param>
        /// <returns></returns>
        public SceneryTrafficInfo GetSceneryTrafficInfo(ISceneryInfo sceneryInfo)
        {
            var traffic = SceneryTicketServiceLogic.GetSceneryTrafficInfo(sceneryInfo.SceneryID);
            var sceneryTrafficInfo = new SceneryTrafficInfo();
            sceneryTrafficInfo.Latitude = traffic.latitude;
            sceneryTrafficInfo.Longitude = traffic.longitude;
            sceneryTrafficInfo.SceneryId = traffic.sceneryId;
            sceneryTrafficInfo.SceneryName = sceneryInfo.SceneryName;
            sceneryTrafficInfo.Traffic = traffic.traffic;
            sceneryTrafficInfo.Address = sceneryInfo.Address;
            return sceneryTrafficInfo;
        }

        /// <summary>
        /// 根据城市获取景区信息
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<SceneryTicketPrimaryInfo> GetSceneryInfoByCityId(int cityId,int top = 10)
        {
            var items = sceneryInfoDetailData.GetRecommendSceneryForCity(cityId, top);
            return items;
        }

        /// <summary>
        /// 获取待索引景区信息
        /// </summary>
        /// <param name="topCount"></param>
        /// <returns></returns>
        public List<SceneryInfoDetail> GetSceneryInfoForLucene(int topCount)
        {
            var sceneryinfos = sceneryInfoDetailData.GetSceneryInfoForLuceneIndex(topCount);
            var sceneryinfosDto = AutoMapper.Mapper.Map<List<T_SceneryInfoDetail>, List<SceneryInfoDetail>>(sceneryinfos);
            return sceneryinfosDto;
        }

        /// <summary>
        /// 初始化lucene索引状态
        /// </summary>
        public void InitSceneryInfoLuceneState()
        {
            sceneryInfoDetailData.InitSceneryIndexLuceneState();
        }
        
        /// <summary>
        /// 修改景区信息lucene索引状态
        /// </summary>
        /// <param name="sceneryIdList"></param>
        public void UpdateLuceneState(List<int> sceneryIdList)
        {
            sceneryInfoDetailData.UpdateLuceneState(sceneryIdList);
        }

        /// <summary>
        /// 景区lucene文件创建
        /// </summary>
        /// <param name="action"></param>
        public void SceneryInfoLuceneIndexCreate(Action<string> action)
        {
            var sceneryinfos = GetSceneryInfoForLucene(500);
            SceneryTicketSearchLucene ticketLucene = new SceneryTicketSearchLucene();
            while(sceneryinfos!=null&&sceneryinfos.Count>0)
            {
                ticketLucene.CreateSceneryLuceneIndex(sceneryinfos);
                action(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                UpdateLuceneState(sceneryinfos.Select(u=>u.SceneryID).ToList());
                sceneryinfos = GetSceneryInfoForLucene(500);
            }

            action("索引完毕");
        }

        /// <summary>
        /// 景区信息查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Tuple<List<SceneryInfoDetail>,List<SceneryTicketPrice>,int> SceneryInfoQuery(SceneryQueryInfo query)
        {
            SceneryTicketSearchLucene ticketLucene = new SceneryTicketSearchLucene();
            int totalRecord=0;
            var sceneryinfos = ticketLucene.SceneryLuceneIndexSearch(query, out totalRecord);
            if (sceneryinfos==null||sceneryinfos.Count==0)
            return new Tuple<List<SceneryInfoDetail>,List<SceneryTicketPrice>,int>(null,null,0);
            var ticketPrices = ticketData.GetTicketPriceBySceneryId(sceneryinfos.Select(u=>u.SceneryID).ToList());
            var ticketPricesDto = AutoMapper.Mapper.Map<List<T_SceneryTicketPrice>, List<SceneryTicketPrice>>(ticketPrices);
            return Tuple.Create<List<SceneryInfoDetail>, List<SceneryTicketPrice>, int>(sceneryinfos, ticketPricesDto, totalRecord);
        }

        /// <summary>
        /// 获取景区门票信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <param name="ticketId"></param>
        /// <param name="bookdate"></param>
        /// <returns></returns>
        public SceneryTicketPrice GetSceneryTicketPriceInfo(int sceneryId,int ticketId,DateTime bookdate)
        {
            var ticketPrice = ticketData.GetTicketPriceByTicket(sceneryId,ticketId,bookdate);
            var ticketPriceDto = AutoMapper.Mapper.Map<T_SceneryTicketPrice, SceneryTicketPrice>(ticketPrice);
            return ticketPriceDto;
        }

        /// <summary>
        /// 根据景区城市名称获取相关酒店
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public List<HotelLuceneIndexInfo> GetHotelInfoBySceneryName(string cityName)
        {
            var hotelinfos = HotelSearchLucene.GetInstance().HotelInfoQueryNearScenery(cityName);
            return hotelinfos;
        }

        /// <summary>
        /// 根据城市名称获取景区信息
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public List<SceneryInfoDetail> GetSceneryInfoByCityName(string cityName)
        {
            SceneryTicketSearchLucene ticketLucene = new SceneryTicketSearchLucene();
            var sceneryinfos = ticketLucene.SceneryLuceneIndexSearch(cityName);
            return sceneryinfos;
        }

        /// <summary>
        /// 景区门票预定
        /// </summary>
        /// <param name="sceneryId">景区Id</param>
        /// <param name="policyId">价格策略</param>
        /// <param name="ticketCount">门票张数</param>
        /// <param name="bookDate">游玩日期</param>
        /// <param name="linkMan">联系人</param>
        /// <param name="linkTel">联系电话</param>
        /// <param name="remark">备注</param>
        /// <param name="totalAmount">金额</param>
        /// <returns></returns>
        public SceneryTicketBookResult SceneryOrder(int sceneryId, int policyId, int ticketCount, DateTime bookDate, string linkMan, string linkTel, string remark, int totalAmount,string sceneryName)
        {
            var rep=SceneryTicketServiceLogic.SubmitSceneryOrder(sceneryId,linkMan,linkTel,linkMan,linkTel,policyId,ticketCount,bookDate);
            SceneryTicketBookResult bookResult = new SceneryTicketBookResult() { Success = false };
            if(rep.RspCode=="0000")
            {
                T_SceneryTicketOrder orderInfo = new T_SceneryTicketOrder();
                orderInfo.AddDate = DateTime.Now;
                orderInfo.LinkMan = linkMan;
                orderInfo.LinkTel = linkTel;
                orderInfo.PolicyID = policyId;
                orderInfo.SceneryID = sceneryId;
                orderInfo.SceneryName = sceneryName;
                orderInfo.SerialNo = rep.SerialId;
                orderInfo.State = 0;
                orderInfo.TicketCount = ticketCount;
                orderInfo.TotalAmount = totalAmount;
                orderInfo.TravelDate = bookDate;

                ticketOrderData.Insert(orderInfo);

                bookResult.Success = true;
                bookResult.OrderNo = rep.SerialId;
                return bookResult;
            }
            else
            {
                bookResult.Success = false;
                bookResult.ErrorCode = rep.RspCode;
                bookResult.ErrorMsg = rep.RspDesc;
                return bookResult;
            }
        }

        /// <summary>
        /// 根据订单号获取订单信息
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public SceneryTicketOrder GetSceneryRicketOrderByOrderNo(string orderNo)
        {
            var order = ticketOrderData.GetSceneryOrderBySerial(orderNo);
            var orderDto = AutoMapper.Mapper.Map<T_SceneryTicketOrder, SceneryTicketOrder>(order);
            return orderDto;
        }

        /// <summary>
        /// 获取所有景区信息放入缓存
        /// </summary>
        /// <returns></returns>
        private List<SceneryInfoDetail> GetAllSceneryInfoDetails()
        {
            var sceneryinfos = cacheProvider.GetCacheItem<List<SceneryInfoDetail>>(CacheKeys.SceneryInfoDetailsCache);
            if(sceneryinfos==null)
            {
                sceneryinfos = AutoMapper.Mapper.Map<List<T_SceneryInfoDetail>, List<SceneryInfoDetail>>(sceneryInfoDetailData.All());
                cacheProvider.InsertCacheItems(CacheKeys.SceneryInfoDetailsCache, sceneryinfos);
            }
            return sceneryinfos;
        }

        /// <summary>
        /// 获取省份城市信息
        /// </summary>
        /// <returns></returns>
        public List<SceneryProvinceDetailInfo> GetSceneryProvincesAndCities()
        {
            var sceneryProvinces = cacheProvider.GetCacheItem<List<SceneryProvinceDetailInfo>>(CacheKeys.SceneryProvincesCache);
            if (sceneryProvinces == null)
            {
                sceneryProvinces = AutoMapper.Mapper.Map<List<T_SceneryProvinceDetailInfo>, List<SceneryProvinceDetailInfo>>(provinceInfoData.All());
                cacheProvider.InsertCacheItems(CacheKeys.SceneryInfoDetailsCache, sceneryProvinces);
            }
            return sceneryProvinces;
        }

        /// <summary>
        /// 获取景区省份信息
        /// </summary>
        /// <returns></returns>
        public List<SceneryProvinceDetailInfo> GetSceneryProvinces()
        {
            var provinces = GetSceneryProvincesAndCities().Where(u => u.ParentID == 0).ToList();
            return provinces;
        }

        /// <summary>
        /// 根据省份id获取周边景区信息
        /// </summary>
        /// <param name="provinceId"></param>
        /// <returns></returns>
        public Tuple<List<SceneryInfoDetail>, List<SceneryProvinceDetailInfo>> GetSceneryInfoByProvinceId(int provinceId)
        {

            // todo:add cache
            var items = sceneryInfoDetailData.GetSceneryInfoByProvinceId(provinceId);
            return items;
        }

        /// <summary>
        /// 根据酒店所在城市获取附近啊景点信息
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public List<SceneryInfoDetail> GetSceneryInfoByHotelCityName(string cityName)
        {
            var sceneryinfos = GetAllSceneryInfoDetails().Where(u => u.CityName == cityName).OrderByDescending(u=>u.GradeInt).ToList()??new List<SceneryInfoDetail>();
            sceneryinfos = sceneryinfos.Count > 9 ? sceneryinfos.Range(9) : sceneryinfos;
            return sceneryinfos;
        }

        [Obsolete("废弃")]
        public PageObjectResult<SceneryTicketOrder> SceneryTicketOrderGetPageResult(SceneryTicketOrderSearchModel search)
        {
            return null;
        }

        /// <summary>
        /// 通过接口获取景区门票价格策略
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        public List<SceneryPolicy> SceneryTicketPriceGetOnline(int sceneryId)
        {
            var apiResult = SceneryTicketServiceLogic.GetSceneryPrice(sceneryId);
            List<SceneryPolicy> ticketPrices = new List<SceneryPolicy>();
            if(apiResult.RspCode=="0000")
            {
               return apiResult.SceneryPrices[0].Policies;
            }
            return ticketPrices;
        }

        /// <summary>
        /// 根据省份获取城市信息
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<SceneryProvinceDetailInfo> GetSceneryCityInfoByProvinceId(int pid)
        {
            if(pid==0)
            {
                return new List<SceneryProvinceDetailInfo>();
            }
            var cityinfos = GetSceneryProvincesAndCities().Where(u => u.ParentID == pid).ToList();
            return cityinfos;
        }

        public List<SceneryInfoDetail> GetSceneryInfosBycCoordinate(string lat,string lng,decimal distance=1,int topCount=15)
        {
            var itemsDomain = sceneryInfoDetailData.GetSceneryInfosBycCoordinate(lat, lng, distance, topCount);
            var itemsDto = AutoMapper.Mapper.Map<List<T_SceneryInfoDetail>, List<SceneryInfoDetail>>(itemsDomain);
            return itemsDto;
        }

        /// <summary>
        /// 根据省份id获取省份信息
        /// </summary>
        /// <param name="pid">省份id</param>
        /// <returns></returns>
        public SceneryProvinceDetailInfo GetSceneryProvinceInfoByProvinceID(int pid)
        {
            if (pid == 0)
                return null;
            var provinceinfo = GetSceneryProvincesAndCities().SingleOrDefault(u => u.ID == pid);
            return provinceinfo;
        }
    }
}
