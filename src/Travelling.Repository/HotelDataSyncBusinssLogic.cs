using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Data;
using Travelling.Domain;
using Ninject;
using Travelling.TravelInterface.Repository;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using Travelling.OpenApiEntity.Ctrip.Hotel;
using Travelling.FrameWork;
using Travelling.OpenApiLogic;
using Travelling.OpenApiEntity.Ctrip.Hotel.Module;
using Travelling.CommonLibrary;
using System.Threading;
using Newtonsoft.Json;
using AutoMapper;
using Travelling.Domain.HotelSyncRecord;
using Travelling.OpenApiEntity.Ctrip.Enums;
using Travelling.Domain.Hotel;
using Travelling.TravelInterface.Data.Hotel;
using Travelling.ViewModel.Dto.HotelSyncRecord;
using Travelling.ViewModel.Dto.User;


namespace Travelling.Repository
{
    /// <summary>
    /// 酒店信息同步
    /// </summary>
    public class HotelDataSyncBusinssLogic : BaseLogic, IHotelDataSyncBusinssLogic
    {

        
        
       
        // 酒店城市
        
        private readonly IXC_HotelSearchInfoDataProvider hotelSyncInfoData;
        private readonly IXC_HotelDescriptionDataProvider hotelSyncDescriptionData;
        private readonly IXC_HotelLocationDataProvider locationData;

        private readonly IXC_HotelRefPointInfoDataProvider refpointData;
        
        
        private readonly IHotelCityBusinessLogic ctripCityBusiness;
        
        
        private readonly IHotelDescriptionDataProvider hotelInfoData;
        
        private readonly IXC_HotelRoomInfoDataProvider roomInfoData;
        
        private readonly IXC_HotelPriceDataProvider hotelPriceData;
       
        private readonly IXC_HotelAreaInfoDataProvider cityAreaInfoData;
        private readonly IXC_HotelRoomRateJobSchedulerDataProvider hotelSyncSchedulerData;
        
        private readonly IXC_HotelRoomRatePlanDataProvider cityRoomRateSyncData;
        private readonly IOperatingLogDataProvider logData;
        private readonly IXC_HotelCityDetailInfoDataProvider hotelCityDetailInfoData;
        private readonly IXC_HotelBrandDetailInfoDataProvider hotelBrandDetailInfoData;
        /// <summary>
        /// 构造函数
        /// </summary>
        public HotelDataSyncBusinssLogic()
        {
            
            
            hotelSyncInfoData = kernel.Get<IXC_HotelSearchInfoDataProvider>();
            hotelSyncDescriptionData = kernel.Get<IXC_HotelDescriptionDataProvider>();
            locationData = kernel.Get<IXC_HotelLocationDataProvider>();
            ctripCityBusiness = kernel.Get<IHotelCityBusinessLogic>();
            
            hotelInfoData = kernel.Get<IHotelDescriptionDataProvider>();
            refpointData = kernel.Get<IXC_HotelRefPointInfoDataProvider>();
            roomInfoData = kernel.Get<IXC_HotelRoomInfoDataProvider>();
            
            hotelPriceData = kernel.Get<IXC_HotelPriceDataProvider>();
            cityAreaInfoData = kernel.Get<IXC_HotelAreaInfoDataProvider>();
            

            hotelSyncSchedulerData = kernel.Get<IXC_HotelRoomRateJobSchedulerDataProvider>();

            

            cityRoomRateSyncData = kernel.Get<IXC_HotelRoomRatePlanDataProvider>();
            logData = kernel.Get<IOperatingLogDataProvider>();
            hotelCityDetailInfoData = kernel.Get<IXC_HotelCityDetailInfoDataProvider>();
            hotelBrandDetailInfoData = kernel.Get<IXC_HotelBrandDetailInfoDataProvider>();
        }

        
        /// <summary>
        /// 酒店查询信息同步
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public int ImportHotelSyncInfos(Action<string> action,bool isInitData)
        {
            // 初始化数据
            if(isInitData)
            {
                InitHotelSyncInfoData();
            }
            var waitSyncCity = hotelCityDetailInfoData.HotelCityDetailInfoToSyncHotelInfo(1);
            OTA_HotelSearchReturnEntity apiRep;
            List<T_XC_HotelSearchInfo> hotelSyncInfos;
            T_XC_HotelSearchInfo hotelSyncInfo;
            List<T_XC_HotelAreaInfo> areaInfos;
            T_XC_HotelAreaInfo areainfo;
            while (waitSyncCity != null && waitSyncCity.CityID > 0)
            {
                action(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  " + waitSyncCity.CityName + " 正在同步" + ",剩余"+hotelCityDetailInfoData.HotelCityDetailInfoGetToSyncStateCount());
                apiRep = OTAHotelServiceLogic.OTA_HotelSearch(true, waitSyncCity.CityID);
                hotelSyncInfos = new List<T_XC_HotelSearchInfo>();
                areaInfos = new List<T_XC_HotelAreaInfo>();
                foreach (var h in apiRep.HotelList)
                {
                    hotelSyncInfo = new T_XC_HotelSearchInfo();
                    hotelSyncInfo.AddDate = DateTime.Now;
                    hotelSyncInfo.HotelID = h.HotelCode;
                    hotelSyncInfo.HotelName = h.HotelName;
                    hotelSyncInfo.SyncDate = DateTime.Parse("1900-01-01");
                    hotelSyncInfo.SyncSate = 0;

                    hotelSyncInfo.CityID = h.HotelCityCode;
                    hotelSyncInfos.Add(hotelSyncInfo);

                    if(h.RelativePositions!=null)
                    {
                       foreach(var r in h.RelativePositions)
                       {
                           areainfo = new T_XC_HotelAreaInfo();
                           areainfo.AddDate = DateTime.Now;
                           areainfo.Distance = r.Distance;
                           areainfo.Name = r.Name;
                           areainfo.UnitOfMeasureCode = r.UnitOfMeasureCode;
                           areainfo.TypeCode = 0;
                           areainfo.HotelID = h.HotelCode;
                           areainfo.CityID = h.HotelCityCode;
                           areaInfos.Add(areainfo);
                       }
                    }

                }

                hotelSyncInfoData.InsertBulk(hotelSyncInfos);
                cityAreaInfoData.InsertBulk(areaInfos);
                waitSyncCity.LastSyncHotelInfoDate = DateTime.Now;
                waitSyncCity.SyncState = 1;
                waitSyncCity.HotelCount = apiRep.HotelList.Count;
                hotelCityDetailInfoData.Update(waitSyncCity);
                waitSyncCity = hotelCityDetailInfoData.HotelCityDetailInfoToSyncHotelInfo(1);


            }
            action("同步完成");
            return 0;
        }

        /// <summary>
        /// 酒店静态信息同步
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public int ImportHotelDescriptionSyncInfos(Action<string> action,bool isInitData)
        {
            if(isInitData)
            {
                InitHotelDescriptionSyncData();
            }
            var hotelSyncInfos = hotelSyncInfoData.GetHotelSyncInfoByState(false, 10);
            List<int> hotelIdList;
            OTA_HotelDescriptiveInfoReturnEntity apiRep;
            List<T_XC_HotelDescription> hotelDescriptionInfos;
            T_XC_HotelDescription hotelSyncDescription;
            T_XC_HotelLocation location;
            T_XC_HotelBrandDetailInfo hotelBrand;

            List<T_XC_HotelRoomInfo> roomInfos;
            T_XC_HotelRoomInfo roomInfo;

            List<T_XC_HotelRefPointInfo> refPoints;
            T_XC_HotelRefPointInfo refPoint;

            var brands = hotelBrandDetailInfoData.All();
            var locations = locationData.All();
            int pageSize = 10;
            int pageNumber = 1;

            while (hotelSyncInfos != null && hotelSyncInfos.Count > 0)
            {
                hotelIdList = hotelSyncInfos.Select(u =>
                {
                    return u.HotelID;
                }).ToList();

                apiRep = OTAHotelServiceLogic.OTA_HotelDescriptiveInfo(hotelIdList, true, true);
                hotelDescriptionInfos = new List<T_XC_HotelDescription>();
                roomInfos = new List<T_XC_HotelRoomInfo>();
                refPoints = new List<T_XC_HotelRefPointInfo>();


                foreach (var h in apiRep.DescriptiveInfos)
                {
                    action(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + h.HotelName + ",剩余" + hotelSyncInfoData.GetDescriptionSyncCount(false));

                    hotelSyncDescription = new T_XC_HotelDescription()
                    {
                        AddDate = DateTime.Now,
                        AddressLine = h.Address,
                        AreaID = h.AreaID,
                        BrandCode = h.BrandCode,
                        HotelCityCode = h.HotelCityCode,
                        CommCleanRate = h.CommCleanRate,
                        CommFacilityRate = h.CommFacilityRate,
                        CommServiceRate = h.CommServiceRate,
                        CommSurroundingRate = h.CommSurroundingRate,
                        CtripCommRate = h.CtripCommRate,
                        CtripStarRate = h.CtripStarRate,
                        CtripUserRate = h.CtripUserRate,
                        HotelCode = h.HotelCode,
                        HotelID = h.HotelId,
                        HotelName = h.HotelName,
                        HotelStarRate = h.HotelStarRate,
                        LastUpdated = h.LastUpdated,
                        Latitude = h.Latitude,
                        Longitude = h.Longitude,
                        PostCode = h.PostCode,
                        ZoneId = h.ZoneId,
                        ZoneName = h.ZoneName,
                        CityName = h.HotelCityName, 
                        SyncState = 0,ListAmount=0,TrueAmount=0
                    };

                    hotelSyncDescription.Description = "";
                    hotelSyncDescription.HotelImg = "";

                    location = (from it in locations
                                where it.LocationID == h.AreaID
                                select it).SingleOrDefault();
                    if (location != null)
                    {
                        hotelSyncDescription.AreaName = location.LocationName;
                    }

                    hotelBrand = (from it in brands
                                  where it.BrandID == h.BrandCode
                                  select it).SingleOrDefault();
                    if (hotelBrand != null)
                    {
                        hotelSyncDescription.BrandName = hotelBrand.BrandName;
                    }

                    hotelSyncDescription.Services = "";
                    if (h.FacilityList != null && h.FacilityList.Count > 0)
                    {
                        hotelSyncDescription.Services = JsonConvert.SerializeObject(h.FacilityList);
                    }
                    hotelSyncDescription.PolicyInfo = "";
                    if (h.PolicyInfo != null)
                    {
                        hotelSyncDescription.PolicyInfo = JsonConvert.SerializeObject(h.PolicyInfo);
                    }

                    hotelSyncDescription.TextItems = "";
                    if (h.MultimediaTextDescriptionList != null)
                    {
                        hotelSyncDescription.TextItems = JsonConvert.SerializeObject(h.MultimediaTextDescriptionList);
                    }
                    hotelSyncDescription.MediaItems = "";
                    if (h.MultimediaImgDescriptionList != null)
                    {
                        hotelSyncDescription.MediaItems = JsonConvert.SerializeObject(h.MultimediaImgDescriptionList);

                        var hotelImg = (from it in h.MultimediaImgDescriptionList
                                        where Convert.ToInt32(it.Category) == (int)HotelPictureCategoryCode.Exteriorview
                                        select it).ToList();
                        if(hotelImg.Count>0)
                        {
                            hotelSyncDescription.HotelImg = hotelImg[0].Url;
                        }
                                       
                        else
                        {
                            hotelImg = (from it in h.MultimediaImgDescriptionList
                                        where Convert.ToInt32(it.Category) == (int)HotelPictureCategoryCode.Lobbyview
                                        select it).ToList();
                            if (hotelImg.Count > 0)
                            {
                                hotelSyncDescription.HotelImg = hotelImg[0].Url;
                            }
                        }
                    }



                    hotelDescriptionInfos.Add(hotelSyncDescription);

                    foreach (var r in h.HotelRoomList)
                    {
                        roomInfo = new T_XC_HotelRoomInfo()
                        {
                            AddDate = DateTime.Now,
                            BedTypeCode = r.BedTypeCode,
                            DescriptiveText = r.DescriptiveText ?? "",
                            EnableBooking = r.EnableBooking ? 1 : 0,
                            Floor = r.Floor,
                            HotelId = h.HotelId,
                            InvBlockCode = r.InvBlockCode,
                            NonSmoking = r.NonSmoking,
                            Quantity = r.Quantity,
                            RoomSize = r.RoomSize,
                            RoomTypeCode = r.RoomTypeCode,
                            RoomTypeName = r.RoomTypeName,
                            Size = r.Size,
                            StandardOccupancy = r.StandardOccupancy,
                            Facility = r.Amenities != null ? JsonConvert.SerializeObject(r.Amenities) : ""
                        };
                        roomInfos.Add(roomInfo);

                    }

                    if (h.AreaInfoList != null)
                    {
                        foreach (var rf in h.AreaInfoList)
                        {
                            refPoint = new T_XC_HotelRefPointInfo()
                            {
                                AddDate = DateTime.Now,
                                DescriptiveText = rf.DescriptiveText,
                                Distance = rf.Distance,
                                HotelID = h.HotelId,
                                Latitude = rf.Latitude,
                                Longitude = rf.Longitude,
                                Name = rf.Name,
                                RefPointCategoryCode = rf.RefPointCategoryCode,
                                RefPointName = rf.RefPointName,
                                UnitOfMeasureCode = rf.UnitOfMeasureCode
                            };

                            refPoints.Add(refPoint);
                        }
                    }

                }

                hotelSyncInfoData.InsertBulk2(hotelDescriptionInfos, refPoints, roomInfos, hotelSyncInfoData.UpdateSyncState, hotelIdList);
                hotelSyncInfos = hotelSyncInfoData.GetHotelSyncInfoByState(false, 10);
            }
            action("同步完成");
            return 0;
        }

        /// <summary>
        /// 导入酒店价格计划
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="action"></param>
        public void ImportHotelSyncRoomRate(DateTime startDate, DateTime endDate, Action<string> action)
        {
            

        }


        /// <summary>
        /// 同步酒店价格计划
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="action"></param>
        [Obsolete("废弃")]
        public void ImportHotelSyncRoomRateOnline(DateTime startDate, DateTime endDate, Action<string> action)
        {
            

        }

        /// <summary>
        /// 同步酒店价格计划
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="action"></param>
        public void HotelSyncRoomRate(Action<string> action,bool isClear)
        {
            if(isClear)
            {
                action("正在初始化数据");
                InitHotelRoomRatePlanSyncDate();
                action("数据初始化完成");
            }
            var hotelSyncInfos = hotelSyncInfoData.GetHotelSyncInfoByPriceState(false, 10);
            var scheduler = hotelSyncSchedulerData.HotelRoomRateJobSchedulerGetRecordToExecute();
            if (scheduler == null)
                return;
            List<int> hotelIdList;
            OTA_HotelRatePlanReturnEntity apiRep;
            List<T_XC_HotelRoomRatePlan> roomRatesSync;
            T_XC_HotelRoomRatePlan roomRate;
            int cityId = 0;
            string tableName = "";

            while (hotelSyncInfos != null && hotelSyncInfos.Count > 0)
            {
                roomRatesSync = new List<T_XC_HotelRoomRatePlan>();
                hotelIdList = hotelSyncInfos.Select(u =>
                {
                    return u.HotelID;
                }).ToList();

                apiRep = OTAHotelServiceLogic.OTA_HotelRatePlan(hotelIdList, scheduler.StartDate, scheduler.EndDate, true);

                foreach (var rp in apiRep.HotelRatePlanList)
                {
                    cityId = (from it in hotelSyncInfos
                              where it.HotelID == rp.HotelCode
                              select it).SingleOrDefault().CityID;
                    tableName = "T_XC_HotelRoomRatePlan_" + cityId;
                    action(string.Format("{0} {2} {1},剩余:{3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), rp.HotelCode, rp.HotelCode, hotelSyncInfoData.GetHotelRoomRatePlanSyncCount(false)));
                    foreach (var rm in rp.RoomRatePlanList)
                    {
                        foreach (var r in rm.RoomRateList)
                        {
                            roomRate = new T_XC_HotelRoomRatePlan()
                            {
                                AmountBeforeTax = r.AmountBeforeTax,
                                AddDate = DateTime.Now,
                                BackAmount = r.BackAmount,
                                BackCode = r.BackCode,
                                BackCurrencyCode = r.BackCurrencyCode,
                                BackDescription = r.BackDescription,
                                Breakfast = r.Breakfast == "false" ? 0 : 1,
                                CancelAmount = r.CancelAmount,
                                CancelCurrencyCode = r.CancelCurrencyCode,
                                CancelPenaltyEndTime = r.CancelPenaltyEndTime,
                                CancelPenaltyStartTime = r.CancelPenaltyStartTime,
                                CurrencyCode = r.CurrencyCode,
                                EndPeriod = r.EndPeriod,
                                EndTime = r.EndTime,
                                GuaranteeCode = r.GuaranteeCode,
                                HoldTime = r.HoldTime.ToDateTime(),
                                HotelId = rp.HotelCode,
                                IsInstantConfirm = r.IsInstantConfirm,
                                ListPrice = r.ListPrice,
                                MarketCode = rm.MarketCode,
                                NumberOfBreakfast = r.NumberOfBreakfast,
                                NumberOfGuests = r.NumberOfGuests,
                                ProgramName = r.ProgramName,
                                RatePlanCategory = rm.RatePlanCategory,
                                RoomTypeCode = rm.HotelRoomCode,
                                StartPeriod = r.StartPeriod,
                                StartTime = r.StartTime,
                                Status = r.Status,
                                UpdateTime = DateTime.Now,
                                Pertain = r.PertainList != null ? JsonConvert.SerializeObject(r.PertainList) : "",
                                //CityID = cityId,
                                
                                SyncState = 0
                            };

                            roomRatesSync.Add(roomRate);
                        }
                    }
                }
                //cityRoomRateData.
                //cityRoomRateData.BulkInsertItems(roomRatesSync, tableName);
                cityRoomRateSyncData.BulkInsertItems<T_XC_HotelRoomRatePlan>(roomRatesSync, tableName);
                //roomRatePlanSyncData.InsertBulk(roomRatesSync);
                hotelSyncInfoData.UpdatePriceSyncState(hotelIdList);

                hotelSyncInfos = hotelSyncInfoData.GetHotelSyncInfoByPriceState(false, 10);
            }

            action("同步完成");
            scheduler.SyncState = 1;
            hotelSyncSchedulerData.Update(scheduler);

        }

        /// <summary>
        /// 初始化酒店查询信息
        /// </summary>
        public void InitHotelSyncInfoData()
        {
            hotelSyncInfoData.Truncate();
            hotelCityDetailInfoData.HotelCityDetailInfoInitSyncState();
            
        }

        /// <summary>
        /// 初始化酒店静态信息同步数据
        /// </summary>
        public void InitHotelDescriptionSyncData()
        {
            hotelSyncDescriptionData.Truncate();
            roomInfoData.Truncate();
            refpointData.Truncate();
            hotelSyncInfoData.UpdateSyncStateWaitSync();
        }

        /// <summary>
        /// 酒店价格策络数据初始化
        /// </summary>
        private void InitHotelRoomRatePlanSyncDate()
        {
            hotelSyncInfoData.UpdatePriceSyncStateWaitSync();
            TruncateHotelRoomRateSyncDataForCity();
            
        }

        /// <summary>
        /// 导入酒店最低价格
        /// </summary>
        public void HotelLowestPriceGet(Action<string> action)
        {
            action("开始获取酒店最低价格");
            var cityInfos = hotelCityDetailInfoData.All();
            var hotelCityInfos = cityInfos.Where(u => u.HotelCount > 0).ToList();
            action("开始清楚城市归属错误的价格数据");
            cityRoomRateSyncData.DeleteErrorCityRoomRatePlans(hotelCityInfos.Select(u=>u.CityID).ToList());
            hotelPriceData.Truncate();
            foreach (var city in hotelCityInfos)
            {
                action(string.Format("导入{0}酒店价格信息", city.CityName));

                hotelPriceData.HotelLowestPriceImport(new List<int> { city.CityID});
            }

            
            action("酒店最低价格获取完毕");
        }

        
        

        /// <summary>
        /// 导入酒店最低价格信息
        /// </summary>
        /// <returns></returns>
        public bool ImportHotelMinPrice()
        {
            var hotelPriceSyncItems = hotelPriceData.All();
            if (hotelPriceSyncItems == null || hotelPriceSyncItems.Count == 0)
                return false;
            var hotelPrices = AutoMapper.Mapper.Map<List<T_XC_HotelPrice>, List<T_XC_HotelPrice>>(hotelPriceSyncItems);
            hotelPriceData.Truncate();
            hotelPriceData.InsertBulk(hotelPrices);
            return true;
        }

        /// <summary>
        /// 设置城市区域类型
        /// </summary>
        /// <param name="action"></param>
        public void CityAreaInfoSettingTypeCode(Action<string> action)
        {
            action("开始同步类型");
            cityAreaInfoData.InitAreaTypeCode();
            action("类型同步完成");
        }


        public void InitAreaInfoSyncOnlineState()
        {
            cityAreaInfoData.InitSyncState(); 
            cityAreaInfoData.Truncate();
        }

       

        /// <summary>
        /// 根据城市拆分酒店价格计划表，每个城市对应一张表
        /// </summary>
        /// <param name="action"></param>
        public void CreateHotelRoomRateTablesForCities(Action<string> action)
        {
            action("开始拆分");
            var cityinfos = hotelCityDetailInfoData.All();
            cityRoomRateSyncData.CreateRoomRateForCity(cityinfos.Select(u=>u.CityID).ToList());

            action("拆分完成");
        }


        /// <summary>
        /// 删除过期
        /// </summary>
        public void DeleteOverdueRoomRatePlanDateOfCity()
        {
            var cityinfos = hotelCityDetailInfoData.All();
            cityRoomRateSyncData.DeleteOverdueRoomRateData(cityinfos.Select(u=>u.CityID).ToList());
        }

        /// <summary>
        /// 清空酒店价格数据
        /// </summary>
        public void TruncateHotelRoomRateSyncDataForCity()
        {
            var cityinfos = hotelCityDetailInfoData.All();
            cityRoomRateSyncData.TruncateHotelRoomRateData(cityinfos.Select(u => u.CityID).ToList());
        }

        /// <summary>
        /// 获取待执行的酒店价格计划记录
        /// </summary>
        /// <returns></returns>
        public HotelRoomRateJobScheduler HotelRoomRateJobSchedulerGetRecordToExecute()
        {
            var hotelRoomPriceJobDomain = hotelSyncSchedulerData.HotelRoomRateJobSchedulerGetRecordToExecute();
            var hotelRoomProceJobDto = AutoMapper.Mapper.Map<T_XC_HotelRoomRateJobScheduler, HotelRoomRateJobScheduler>(hotelRoomPriceJobDomain);
            return hotelRoomProceJobDto;
        }

    }
}
