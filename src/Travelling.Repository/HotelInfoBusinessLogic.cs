using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Travel;
using Travelling.DataProvider;
using Travelling.TravelInterface.Data;
using Travelling.Domain;
using Ninject;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using AutoMapper;
using Travelling.OpenApiLogic;
using Travelling.FrameWork;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.TravelInterface.Data.Hotel;
using Travelling.Caching;
using Travelling.Domain.Hotel;
using Travelling.ViewModel.Hotel;
using Travelling.OpenApiEntity.Ctrip.Hotel.Module;
using Travelling.ViewModel.Lucene;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.Domain.HotelSyncRecord;
using System.Data.SqlClient;
using Travelling.Lucene;


namespace Travelling.Repository
{
    /// <summary>
    /// 酒店业务信息处理
    /// </summary>
    public class HotelInfoBusinessLogic : BaseLogic, IHotelInfoBusinessLogic
    {
        
        private readonly IXC_HotelPriceDataProvider hotelPriceDataProvider;
        private readonly IXC_HotelRoomInfoDataProvider roomInfoData;

        private readonly IHotelBookingOrderDataProvider hotelBookingOrderData;
        
        private readonly IHotelDescriptionDataProvider hotelDescData;
        private readonly IXC_HotelRefPointInfoDataProvider refPointData;
        private readonly IXC_HotelLocationDataProvider locationData;
        private readonly IXC_HotelAreaInfoDataProvider areaInfoData;
        
       
        private readonly IHotelBookingOrderDataProvider hotelOrderData;
        private readonly IXC_HotelBrandDetailInfoDataProvider brandDetailInfoData;
        private readonly IXC_HotelCityDetailInfoDataProvider hotelCityDetailInfoData;
        private readonly IXC_HotelDescriptionDataProvider xcHotelDescriptionData;
        private readonly IHotelInfoDataProvider hotelData;

        private readonly ICityInfoDataProvider cityinfoData;
        private readonly ILocationInfoDataProvider locationInfoData;
        private readonly IHotelBrandDataProvider hotelBrandData;

        
        /// <summary>
        /// 构造函数
        /// </summary>
        public HotelInfoBusinessLogic()
        {
            
            hotelPriceDataProvider = kernel.Get<IXC_HotelPriceDataProvider>();
            roomInfoData = kernel.Get<IXC_HotelRoomInfoDataProvider>();
            hotelBookingOrderData = kernel.Get<IHotelBookingOrderDataProvider>();
            
            hotelDescData = kernel.Get<IHotelDescriptionDataProvider>();
            refPointData = kernel.Get<IXC_HotelRefPointInfoDataProvider>();
            locationData = kernel.Get<IXC_HotelLocationDataProvider>();
            areaInfoData = kernel.Get<IXC_HotelAreaInfoDataProvider>();
            
            
            hotelOrderData = kernel.Get<IHotelBookingOrderDataProvider>();
            brandDetailInfoData = kernel.Get<IXC_HotelBrandDetailInfoDataProvider>();
            hotelCityDetailInfoData = kernel.Get<IXC_HotelCityDetailInfoDataProvider>();

            xcHotelDescriptionData = kernel.Get<IXC_HotelDescriptionDataProvider>();
            hotelData = kernel.Get<IHotelInfoDataProvider>();

            cityinfoData = kernel.Get<ICityInfoDataProvider>();
            locationInfoData = kernel.Get<ILocationInfoDataProvider>();
            hotelBrandData = kernel.Get<IHotelBrandDataProvider>();

        }

        
        /// <summary>
        /// 获取酒店品牌信息
        /// </summary>
        /// <returns></returns>
        public List<HotelBrandDetailInfo> HotelBrandDetailInfoGet()
        {
            var brandDetailInfosDto = cacheProvider.GetCacheItem<List<HotelBrandDetailInfo>>(CacheKeys.HotelBrandDetailInfos);
            if(brandDetailInfosDto==null)
            {
                brandDetailInfosDto = AutoMapper.Mapper.Map<List<T_XC_HotelBrandDetailInfo>, List<HotelBrandDetailInfo>>(brandDetailInfoData.All());
                cacheProvider.InsertCacheItems(CacheKeys.HotelBrandDetailInfos,brandDetailInfosDto);
            }
            return brandDetailInfosDto;
        }

        public List<HotelPrimaryInfo> GetRecommendHotels()
        {
            return hotelPriceDataProvider.HotHotels();
        }

        public List<HotelRoomInfo> HotelRoomInfoGetByHotelId(int hotelId)
        {
            var hotelRoomInfoDomain = roomInfoData.GetHotelRoomsByHotelID(hotelId);
            var hotelRoomInfoDto = AutoMapper.Mapper.Map<List<T_XC_HotelRoomInfo>, List<HotelRoomInfo>>(hotelRoomInfoDomain);
            
            return hotelRoomInfoDto;
        }

        public HotelRoomPrimaryInfo GetHotelRoomInfoByRoomTypeCode(int roomTypeCode)
        {
            var roomInfoModel = roomInfoData.GetHotelRoomInfoByRoomTypeCode(roomTypeCode);
            var roomInfp = AutoMapper.Mapper.DynamicMap<HotelRoomPrimaryInfo>(roomInfoModel);
            return roomInfp;
        }

        public HotelRoomPrimaryInfo GetHotelRoomInfo(int hotelid, int roomTypeCode,int cityId)
        {
            var roominfo = roomInfoData.GetHotelRoomInfo(hotelid, roomTypeCode,cityId);
            return roominfo;
        }



        public void HotelRoomRatePlanChanges(int cityId, int hotelId)
        {
            var rep = OTAHotelServiceLogic.OTA_HotelCacheChange(cityId, hotelId, DateTime.Now.Date);

        }

        


        /// <summary>
        /// 酒店预定
        /// </summary>
        /// <param name="bookInfo"></param>
        /// <returns></returns>
        public HotelRoomBookResult BookRooms(HotelRoomBookInfo bookInfo)
        {
            DateTime now = DateTime.Now;//当前时间
            DateTime checkInDate = bookInfo.InRoomDate;// 入住日期
            DateTime checkOutDate = bookInfo.OffRoomDate;// 离店日期

            HotelRoomBookResult bookResult = new HotelRoomBookResult() { Success = false };

            TimeSpan dateBlock = checkOutDate - checkInDate;
            int bightCount = dateBlock.Days;

            string checkinDateTimeString = string.Format("{0} {1}", checkInDate.ToString("yyyy-MM-dd"), bookInfo.BeforeCheckInTime);// checkInDate.ToString("yyyy-MM-dd");
            string lastCheckInDateTimeString = string.Format("{0} {1}", checkInDate.ToString("yyyy-MM-dd"), bookInfo.LastCheckInTime);
            string checkoutDateTimeString = checkOutDate.ToString("yyyy-MM-dd");

            DateTime beforeCheckinDateTime;
            DateTime lastCheckinDateTime;

            bool convertResult = DateTime.TryParseExact(checkinDateTimeString, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out beforeCheckinDateTime);
            bool convertResult2 = DateTime.TryParseExact(lastCheckInDateTimeString, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out lastCheckinDateTime);

            bookInfo.BeforeCheckInTime = beforeCheckinDateTime.ToCtripDateFormat();
            bookInfo.LastCheckInTime = lastCheckinDateTime.ToCtripDateFormat();

            bookInfo.InRoomDate = beforeCheckinDateTime;
            bookInfo.OffRoomDate = checkOutDate;

            
            var rep = OTAHotelServiceLogic.BookHotelRoom(bookInfo);
            string orderNo = "";
            if (rep != null && !string.IsNullOrEmpty(rep.ResIDValue))
            {
                bookResult.Success = true;
                bookResult.OrderSerial = rep.ResIDValue;
                T_HotelBookingOrder bookOrderInfo = new T_HotelBookingOrder()
                {
                    AddDate = DateTime.Now,
                    Amount = rep.AmountAfterTax,
                    Channel = 0,
                    ContactEmail = bookInfo.ContactEmail ?? "",
                    ContactPerson = bookInfo.ContactName,
                    ContactPhone = bookInfo.MobilePhone,
                    Flag = 0,
                    HotelID = bookInfo.HotelCode,
                    RoomTypeCode = bookInfo.RoomTypeCode,
                    SerialNo = rep.ResIDValue,
                    UserID = 0, 
                    CheckInDate = bookInfo.InRoomDate, 
                    CheckOffDate = bookInfo.OffRoomDate, 
                    HotelAddress = bookInfo.HotelAddress, 
                    HotelName = bookInfo.HotelName, 
                    LateArrivalTime = lastCheckinDateTime, 
                    RatePlanCategory = 16, 
                    RoomTypeName = bookInfo.RoomTypeName, RoomCount = bookInfo.RoomCount, Customers = bookInfo.Customers.Join(",")
                    
                };
                int id = hotelBookingOrderData.Save(bookOrderInfo);
                orderNo = rep.ResIDValue;

                //OTAHotelServiceLogic.OTA_CancelHotelBookOrder(orderNo);
            }
            else if (rep.Error != null)
            {
                bookResult.Success = false;
                bookResult.FailReason = rep.Error.Text;
                bookResult.Code = rep.Error.Code;
            }

            return bookResult;
        }

        
        ////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 获取热门城市酒店信息
        /// </summary>
        /// <returns></returns>
        public Tuple<List<HotelPrimaryInfo>, List<HotelCityDetailInfo>> GetHotCityHotelInfos()
        {
            var hotelInfos = cacheProvider.GetCacheItem<Tuple<List<HotelPrimaryInfo>, List<HotelCityDetailInfo>>>(CacheKeys.HotelHotCityInfos);
            if (hotelInfos == null)
            {
                hotelInfos = xcHotelDescriptionData.GetHotCityHotelInfos();
                cacheProvider.InsertCacheItems(CacheKeys.HotelHotCityInfos, hotelInfos);
            }
            return hotelInfos;
        }

        /// <summary>
        /// 获取酒店详细静态信息
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public HotelDetailInfo GetHotelDescriptionByHotelId(int hotelId)
        {
            var hotelDescription = hotelDescData.SingleOrDefault(hotelId);
            HotelDescription hotelDescDto = AutoMapper.Mapper.Map<T_XC_HotelDescription, HotelDescription>(hotelDescription);
            HotelDetailInfo detailInfo = new HotelDetailInfo();
            hotelDescDto.UnionID = 0;
            detailInfo.HotelDescription = hotelDescDto;
            List<HotelServiceInfo> hotelServices = new List<HotelServiceInfo>();
            if (!string.IsNullOrEmpty(hotelDescDto.Services))
            {
                detailInfo.HotelServices = JsonConvert.DeserializeObject<List<HotelServiceInfo>>(hotelDescDto.Services);
            }
            if (!string.IsNullOrEmpty(hotelDescDto.PolicyInfo))
            {
                detailInfo.PolicyInfo = JsonConvert.DeserializeObject<HotelPolicyInfo>(hotelDescDto.PolicyInfo);
            }

            if (!string.IsNullOrEmpty(hotelDescDto.TextItems))
            {
                detailInfo.TextDescriptions = JsonConvert.DeserializeObject<List<HotelMediaTextDescription>>(hotelDescDto.TextItems);
            }
            if (!string.IsNullOrEmpty(hotelDescDto.MediaItems))
            {
                detailInfo.ImgDescriptions = JsonConvert.DeserializeObject<List<HotelMediaImgDescription>>(hotelDescDto.MediaItems);
            }
            
            return detailInfo;
        }


        /// <summary>
        /// 获取酒店房间可预订信息
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<HotelRoomPrimaryInfo> GetHotelRoomInfosAndRatePlans(int hotelId,int cityid, DateTime start, DateTime end)
        {
            var roomInfoItems = roomInfoData.GetHotelRoomInfosAndRatePlan(hotelId,cityid, start, end);
            return roomInfoItems;
        }

        /// <summary>
        /// 获取酒店附近其他酒店
        /// </summary>
        /// <param name="hotelid"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public List<HotelPrimaryInfo> GetNearHotelInfos(int hotelid, float distance = 1)
        {
            var hotels = xcHotelDescriptionData.GetNearHotelInfos(hotelid, distance);
            return hotels;
        }

        public List<HotelRefPointInfo> GetRefPointsByHotelID(int hotelId)
        {
            var refPoints = refPointData.GetRefPointByHotelId(hotelId);
            List<HotelRefPointInfo> refPointsDto = AutoMapper.Mapper.Map<List<T_XC_HotelRefPointInfo>, List<HotelRefPointInfo>>(refPoints);
            return refPointsDto;
        }

        public List<HotelRefPointInfo> GetRefPointsByCityID(int cityID)
        {
            var refPoints = refPointData.GetRefPointByCityId(cityID);
            List<HotelRefPointInfo> refPointsDto = AutoMapper.Mapper.Map<List<T_XC_HotelRefPointInfo>, List<HotelRefPointInfo>>(refPoints);
            return refPointsDto;
        }

        public List<LocationInfo> GetLocationInfoByCityID(int cityID)
        {
            var locations = locationData.GetLocationByCityID(cityID);
            List<LocationInfo> locationsDto = AutoMapper.Mapper.Map<List<T_XC_HotelLocation>, List<LocationInfo>>(locations);
            return locationsDto;
        }

        /// <summary>
        /// 获取酒店城市热门区域
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public List<CityAreaPrimaryInfo> GetCityAreaInfoByCityId(int cityID)
        {
            var areainfos = GetCityAreaInfo().Where(u => u.CityID == cityID).ToList();
            return areainfos;
        }

        public List<HotelQueryPrimaryInfo> HotelQueryResult()
        {
            return xcHotelDescriptionData.HotelQueryResult();
        }

        public List<HotelRoomRatePlanInfo> HotelRoomPlanQuery()
        {
            return xcHotelDescriptionData.HotelRoomPlanQuery();
        }

        /// <summary>
        /// 根据CityID查询城市热门区域
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public List<CityAreaPrimaryInfo> GetCityAreaSummaryInfo(int cityId)
        {
            var areaInfo = cacheProvider.GetCacheItem<List<CityAreaPrimaryInfo>>(CacheKeys.CityAreaInfosSummary);
            if(areaInfo==null)
            {
                areaInfo = areaInfoData.GetCityAreaSummaryInfo();
                cacheProvider.InsertCacheItems(CacheKeys.CityAreaInfosSummary, areaInfo);
            }
            return areaInfo.Where(u => { return u.CityID == cityId; }).ToList();
        }


        /// <summary>
        /// 酒店信息查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Tuple<List<HotelLuceneIndexInfo>,List<HotelRoomPriceInfo>,int> HotelRoomInfoQuery(HotelInfoQuery query)
        {
            
            int totalRecord = 0;
            var hotelinfos = HotelSearchLucene.GetInstance().HotelSearch(query, out totalRecord);
            if(hotelinfos==null||hotelinfos.Count==0)
            {
                return new Tuple<List<HotelLuceneIndexInfo>,List<HotelRoomPriceInfo>,int>(new List<HotelLuceneIndexInfo>(),new List<HotelRoomPriceInfo>(),0);
            }
            
            string hotelids = string.Join(",",hotelinfos.Where(u=>u.UnionId==0).Select(u => { return u.HotelID; }).ToList());
            List<HotelRoomPriceInfo> roominfos;
            if(string.IsNullOrEmpty(hotelids))
            {
                roominfos = new List<HotelRoomPriceInfo>();
            }
            else
            {
                roominfos = roomInfoData.HotelRoomInfoPriceQuery(hotelids, query.StartDate, query.EndDate, query.CityId);
            }
            
            var queryResult = Tuple.Create<List<HotelLuceneIndexInfo>, List<HotelRoomPriceInfo>,int>(hotelinfos, roominfos,totalRecord);
            return queryResult;
        }

        
        /// <summary>
        /// 获取推荐酒店
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public List<HotelPrimaryInfo> HotelPracticalForCity(int cityId)
        {
            var hotels = xcHotelDescriptionData.HotelPracticalForCity(cityId);
            return hotels;
        }

        

        /// <summary>
        /// 根据酒店订单号查询订单信息
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public HotelBookingOrder GetHotelBookOrderBySerial(string orderno)
        {
            var order = hotelOrderData.GetBookOrderByOrderSerial(orderno);
            var orderDto = AutoMapper.Mapper.Map<T_HotelBookingOrder, HotelBookingOrder>(order);
            return orderDto;
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="orderno"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        public HotelBookingOrder GetBookOrderByOrderNoAndTel(string orderno, string tel)
        {
            var order = hotelOrderData.GetBookOrderByOrderNoAndTel(orderno,tel);
            var orderDto = AutoMapper.Mapper.Map<T_HotelBookingOrder, HotelBookingOrder>(order);
            return orderDto;
        }

        /// <summary>
        /// 酒店订单取消
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public bool HotelOrderCancel(string orderno)
        {
            bool apiCancelResult = OTAHotelServiceLogic.OTA_CancelHotelBookOrder(orderno);
            if(apiCancelResult)
            {
                var order = hotelOrderData.GetBookOrderByOrderSerial(orderno);
                order.Flag = (int)HotelOrderType.Cancel;
                return hotelOrderData.Update(order) > 0;
            }
            return false;
            
        }

        ///// <summary>
        ///// 获取酒店城市信息
        ///// </summary>
        ///// <returns></returns>
        //[Obsolete("转移到CityBusiness")]
        private List<HotelCityDetailInfo> HotelCityDetailInfoGetAll()
        {
            var hotelCityInfosDto = cacheProvider.GetCacheItem<List<HotelCityDetailInfo>>(CacheKeys.HoteCitylDetailInfos);
            if (hotelCityInfosDto == null)
            {
                hotelCityInfosDto = AutoMapper.Mapper.Map<List<T_XC_HotelCityDetailInfo>, List<HotelCityDetailInfo>>(hotelCityDetailInfoData.All());
                cacheProvider.InsertCacheItems(CacheKeys.HoteCitylDetailInfos, hotelCityInfosDto);
            }
            return hotelCityInfosDto;
        }

        ///// <summary>
        ///// 获取酒店城市详细信息
        ///// </summary>
        ///// <param name="searchType"></param>
        ///// <returns></returns>
        public List<HotelCityDetailInfo> HotelCityDetailInfoGetAll(HotelCityDetailSearchType searchType)
        {
            switch (searchType)
            {
                case HotelCityDetailSearchType.All:
                    return HotelCityDetailInfoGetAll();
                case HotelCityDetailSearchType.SearchRecommend:
                    return HotelCityDetailInfoGetAll().Where(u => u.IsSearch == 1).ToList();

                case HotelCityDetailSearchType.HotRecommmend:
                    return HotelCityDetailInfoGetAll().Where(u => u.IsRecommendCity == 1).ToList();
                case HotelCityDetailSearchType.IsHot:
                    return HotelCityDetailInfoGetAll().Where(u => u.IsHotCity == 1).ToList();
                case HotelCityDetailSearchType.IsChoice:
                    return HotelCityDetailInfoGetAll().Where(u => u.IsChoiceCity == 1).ToList();
            }
            return null;
        }

        

        /// <summary>
        /// 获取查询推荐酒店信息
        /// </summary>
        /// <returns></returns>
        public string HotelCityDetailInfoGetJsonData()
        {
            var cityInfos = HotelCityDetailInfoGetAll().Where(u=>u.HotelCount>0);
            StringBuilder jsonData = new StringBuilder();
            int index=0;
            foreach(var city in cityInfos)
            {
                if(index==0)
                {
                    jsonData.AppendFormat("{0}|{1}|{2}",city.CityEName,city.CityName,city.CityID);
                }
                else
                {
                    jsonData.AppendFormat("@|{0}|{1}|{2}", city.CityEName, city.CityName, city.CityID);
                }
            }
            jsonData.Append("@");
            return jsonData.ToString();
        }

        /// <summary>
        /// 精选酒店以及城市信息
        /// </summary>
        /// <returns></returns>
        public Tuple<List<HotelPrimaryInfo>, List<HotelCityDetailInfo>> GetChoiceCityHotelInfos()
        {
            var hotelinfos = cacheProvider.GetCacheItem<Tuple<List<HotelPrimaryInfo>, List<HotelCityDetailInfo>>>(CacheKeys.HotelChoiceCityInfos);
            if(hotelinfos==null)
            {
                hotelinfos = xcHotelDescriptionData.GetChoiceCityHotelInfos();
                cacheProvider.InsertCacheItems(CacheKeys.HotelChoiceCityInfos, hotelinfos);
            }
            return hotelinfos;
        }

        /// <summary>
        /// 获取推荐酒店城市以及推荐酒店品牌
        /// </summary>
        /// <returns></returns>
        public Tuple<List<HotelCityDetailInfo>,List<HotelBrandDetailInfo>> HotelRecommendCityAndBrandInfos()
        {
            var infos = new Tuple<List<HotelCityDetailInfo>, List<HotelBrandDetailInfo>>(HotelCityDetailInfoGetAll(HotelCityDetailSearchType.HotRecommmend),HotelBrandDetailInfoGet().Where(u=>u.IsHotBrand==1).ToList());
            return infos;
        }

        /// <summary>
        /// 获取酒店城市热门区域信息
        /// </summary>
        /// <returns></returns>
        public List<CityAreaPrimaryInfo> GetCityAreaInfo()
        {
            
            var cityAreas = cacheProvider.GetCacheItem<List<CityAreaPrimaryInfo>>(CacheKeys.XC_HotelCityAreas);
            if(cityAreas==null)
            {
                cityAreas = areaInfoData.CityAreaInfoGetDistinct();
                cacheProvider.InsertCacheItems(CacheKeys.XC_HotelCityAreas, cityAreas);
            }
            return cityAreas;
        }

        public List<HotelBrandSummaryInfo> HotelBrandSummaryInfos()
        {
            var brandSummarys = cacheProvider.GetCacheItem<List<HotelBrandSummaryInfo>>(CacheKeys.HotelBrandSummaryInfos);
            if(brandSummarys==null)
            {
                brandSummarys = hotelData.HotelBrandSummaryInfos();
                cacheProvider.InsertCacheItems(CacheKeys.HotelBrandSummaryInfos, brandSummarys);
            }
            return brandSummarys;
        }


        public List<HotelCitySummaryInfo> HotelCitySummaryInfos()
        {
            var items = cacheProvider.GetCacheItem<List<HotelCitySummaryInfo>>(CacheKeys.HotelCitySummaryInfos);
            if(items==null)
            {
                //items = xcHotelDescriptionData.HotelCitySummaryInfos();
                items = hotelData.HotelCitySummaryInfos();
                cacheProvider.InsertCacheItems(CacheKeys.HotelCitySummaryInfos, items);
            }
            return items;
        }

        public List<HotelPrimaryInfo> HotelMostPractical()
        {
            var items = cacheProvider.GetCacheItem<List<HotelPrimaryInfo>>(CacheKeys.HotelMostPractical);
            if(items==null)
            {
                items = xcHotelDescriptionData.HotelMostPractical();
                cacheProvider.InsertCacheItems(CacheKeys.HotelMostPractical, items);
            }
            return items;
        }

        /// <summary>
        /// 获取酒店静态信息
        /// </summary>
        /// <returns></returns>
        private List<HotelLuceneIndexInfo> HotelDescriptionGet()
        {
            var items = cacheProvider.GetCacheItem<List<HotelLuceneIndexInfo>>(CacheKeys.HotelDescriptionInfoCache);
            if(items==null||items.Count==0)
            {
                items = HotelSearchLucene.GetInstance().HotelInfoPrimaryInfos();
                cacheProvider.InsertCacheItems(CacheKeys.HotelDescriptionInfoCache, items);
            }
            return items;
        }

        /// <summary>
        /// 根据城市ID获取酒店信息
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public List<HotelLuceneIndexInfo> HotelDescriptionGetByCityId(int cityId)
        {
            var items = HotelDescriptionGet().Where(u => u.HotelCityCode == cityId).ToList();
            return items;
        }

        /// <summary>
        /// 根据城市id集合获取酒店信息
        /// </summary>
        /// <param name="cityIdList"></param>
        /// <returns></returns>
        public List<HotelLuceneIndexInfo> HotelDescriptionGetByCityIdList(List<int> cityIdList)
        {
            var allHotels = HotelDescriptionGet();
            var cityHotels = (from it in allHotels
                              from cityid in cityIdList
                              where it.HotelCityCode == cityid
                              select it).ToList();
            return cityHotels;
        }

        /// <summary>
        /// 经济型酒店信息
        /// </summary>
        /// <returns></returns>
        public List<HotelPrimaryInfo> HotelCheapMost()
        {
            var items = cacheProvider.GetCacheItem<List<HotelPrimaryInfo>>(CacheKeys.HotelCheapMost);
            if(items==null)
            {
                items = xcHotelDescriptionData.HotelCheapMost();
                cacheProvider.InsertCacheItems(CacheKeys.HotelCheapMost, items);
            }
            return items;
        }

        //===========================================
        // 整合后酒店以及城市数据
        // 2015-02-04
        //===========================================

        public void HotelInfoToIndex()
        {
            var items = hotelData.HotelsToLucene();
        }

        /// <summary>
        /// 获取酒店品牌信息
        /// </summary>
        /// <returns></returns>
        public List<HotelBrandDto> HotelBrandsGet()
        {
            var hotelBrands = cacheProvider.GetCacheItem<List<HotelBrandDto>>(CacheKeys.HotelBrandsInfoCacheKey);
            if(hotelBrands==null)
            {
                hotelBrands = AutoMapper.Mapper.Map<List<T_HotelBrand>,List<HotelBrandDto>>(hotelBrandData.All());
                cacheProvider.InsertCacheItems(CacheKeys.HotelBrandsInfoCacheKey, hotelBrands);
            }

            return hotelBrands;
        }

        /// <summary>
        /// 获取酒店品牌信息
        /// </summary>
        /// <param name="brandid"></param>
        /// <returns></returns>
        public HotelBrandDto HotelBrandsGet(int brandid)
        {
            var brand = HotelBrandsGet().SingleOrDefault(u => u.BrandID == brandid);
            return brand;
        }

        //public List<HotelBrandSummaryInfo> HotelBrandSummaryInfos()
        //{
        //    var items = hotelData.HotelBrandSummaryInfos();
        //    return items;
        //}

    }
}
