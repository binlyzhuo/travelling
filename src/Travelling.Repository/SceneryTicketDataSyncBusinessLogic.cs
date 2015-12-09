using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.TravelInterface.Data;
using Travelling.TravelInterface.Repository;
using Ninject;
using Travelling.OpenApiLogic;
using Travelling.CommonLibrary;
using System.Threading;
using Travelling.OpenApiEntity.Scenery;
using Travelling.TravelInterface.Data.SceneryTicket;
using Travelling.Domain.Scenery;
using Newtonsoft;
using Newtonsoft.Json;

namespace Travelling.Repository
{
    /// <summary>
    /// 景区信息同步业务处理
    /// </summary>
    public class SceneryTicketDataSyncBusinessLogic : BaseTicketLogic, ISceneryTicketDataSyncBusinessLogic
    {
        private readonly ISceneryInfoSyncRecordDataProvider sceneryinfoSyncData;
       
        private readonly ISceneryTicketPriceDataProvider ticketPriceData;
        private readonly ISceneryProvinceDetailInfoDataProvider provinceData;
       
        private readonly ISceneryInfoDetailDataProvider sceneryInfoDetailData;
        private readonly ISceneryImgInfoDataProvider sceneryImgData;
        
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public SceneryTicketDataSyncBusinessLogic()
        {
            sceneryinfoSyncData = kernel.Get<ISceneryInfoSyncRecordDataProvider>();
            
            ticketPriceData = kernel.Get<ISceneryTicketPriceDataProvider>();

            provinceData = kernel.Get<ISceneryProvinceDetailInfoDataProvider>();
            sceneryInfoDetailData = kernel.Get<ISceneryInfoDetailDataProvider>();
            sceneryImgData = kernel.Get<ISceneryImgInfoDataProvider>();
        }

        /// <summary>
        /// 景区详细信息同步
        /// </summary>
        /// <param name="action"></param>
        public void SceneryInfoDetailSync(Action<string> action)
        {
            try
            {
                SceneryDetailSync(action);
            }
            catch(Exception ex)
            {
                LogHelper.Error(ex);
                Thread.Sleep(10);
                SceneryDetailSync(action);
            }
            
        }

        /// <summary>
        /// 景区详细信息同步
        /// </summary>
        /// <param name="action"></param>
        private void SceneryDetailSync(Action<string> action)
        {
            var items = sceneryinfoSyncData.GetRecordForSceneryDetailSync(1).SingleOrDefault();

            T_SceneryInfoDetail model;
            while (items != null && items.SceneryId > 0)
            {
                model = new T_SceneryInfoDetail();
                
                var rep = SceneryTicketServiceLogic.GetSceneryDetail(items.SceneryId);
                if(rep.RspCode=="0000")
                {
                    model.Address = rep.address;
                    model.AmountAdvice = (int)rep.amountAdvice;
                    model.BuyNotice = rep.buyNotice;
                    model.CityID = rep.cityId;
                    model.CityName = rep.cityName;
                    model.GradeId = rep.grade;
                    model.GradeInt = string.IsNullOrEmpty(rep.grade) ? 0 : rep.grade.Trim().Length;
                    model.IfUseCard = rep.ifUseCard;
                    model.Intro = rep.intro;
                    model.Lat = rep.lat;
                    model.Lon = rep.lon;
                    model.PayMode = rep.payMode;
                    model.ProvinceID = rep.provinceId;
                    model.ProvinceName = rep.provinceName;
                    model.SceneryAlias = rep.sceneryName;
                    model.SceneryID = rep.sceneryId;
                    model.SceneryName = rep.sceneryName;
                    model.ScenerySummary = items.ScenerySummary;
                    model.Suitherds = items.Suitherds ?? "";
                    model.ImgBaseUrl = items.ImgBaseUrl;
                    model.Imgs = items.Imgs;
                    model.BookFlag = items.BookFlag;
                    model.Distance = items.Distance;
                    model.UpdateTime = DateTime.Now;
                    model.Themes = items.Themes ?? "";
                    model.Impressions = items.Impressions ?? "";

                    items.DetailSyncState = 1;
                    
                    items.UpdateTime = DateTime.Now;
                    string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    action(msg);

                    sceneryInfoDetailData.Insert(model);
                }
                else if(rep.RspCode=="0001")
                {
                    items.DetailSyncState = 2;
                }
                sceneryinfoSyncData.Update(items);
                items = sceneryinfoSyncData.GetRecordForSceneryDetailSync(1).SingleOrDefault();
            }
        }

        /// <summary>
        /// 景区门票价格同步
        /// </summary>
        /// <param name="action"></param>
        public void SceneryTicketPriceSync(Action<string> action)
        {
            var items = sceneryinfoSyncData.GetRecordForPriceSync(1).SingleOrDefault();
            List<T_SceneryTicketPrice> ticketPriceList;
            T_SceneryTicketPrice model;
            while (items != null && items.SceneryId > 0)
            {
                ticketPriceList = new List<T_SceneryTicketPrice>();
                items.PriceSyncState = 1;
                var rep = SceneryTicketServiceLogic.GetSceneryPrice(items.SceneryId);
                if (rep.RspCode == "0000")
                {
                    if (rep.SceneryPrices != null && rep.SceneryPrices.Count>0&&rep.SceneryPrices[0] != null && rep.SceneryPrices[0].Policies != null)
                    {
                        foreach (var p in rep.SceneryPrices[0].Policies)
                        {
                            model = new T_SceneryTicketPrice();
                            model.AddTime = DateTime.Now;
                            model.BeginDate = p.bDate;
                            model.EndDate = p.eDate;
                            model.PolicyID = p.PolicyId;
                            model.PolicyName = p.PolicyName;
                            model.Price = p.price;
                            model.TCPrice = p.tcPrice;
                            model.TicketId = p.ticketId;
                            model.SceneryID = items.SceneryId;
                            model.TicketName = p.ticketName;
                            model.GetMode = p.gMode;
                            model.MaxTickets = p.maxT;
                            model.MinTickets = p.minT;
                            model.Notes = "";
                            model.PayMode = p.pMode;
                            model.RealName = p.realName;
                            model.Remark = p.Remark;
                            model.UseCard = p.useCard;
                            model.OrderUrl = p.orderUrl;
                            ticketPriceList.Add(model);
                        }
                        items.PriceSyncState = 1;

                        var sceneryDetail = sceneryInfoDetailData.SingleOrDefault(items.SceneryId);

                        if (sceneryDetail != null && sceneryDetail.SceneryID>0)
                        {
                            sceneryDetail.HasPricePolicy = 1;
                            sceneryInfoDetailData.Update(sceneryDetail);
                        }
                        
                    }
                }
                else if (rep.RspCode == "0001")
                {
                    items.PriceSyncState = 2;
                }
                else
                {
                    items.PriceSyncState = 3;
                }
                ticketPriceData.InsertBulk(ticketPriceList);
                sceneryinfoSyncData.Update(items);
                action(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "剩余:" + sceneryinfoSyncData.SceneryInfoCountToSyncPrice().ToString());
                items = sceneryinfoSyncData.GetRecordForPriceSync(1).SingleOrDefault();

            }

            action("价格信息同步完成");
        }

        /// <summary>
        /// 景区查询信息同步
        /// </summary>
        /// <param name="action"></param>
        /// <param name="all"></param>
        public void SceneryInfoSync(Action<string> action, bool all = false)
        {


            var record = provinceData.GetCityRecordToSearchSync();
            if (record == null)
                return;
            GetSceneryListReturnEntity rep;
            int page = 1;
            int pageSize = 50;
            int pageCount = 1;
            rep = SceneryTicketServiceLogic.SceneryInfoSync(record.ID, page, pageSize);
            List<T_SceneryInfoSyncRecord> sceneryInfos;
            while (record != null)
            {
                rep = SceneryTicketServiceLogic.SceneryInfoSync(record.ID, 1, pageSize);
                pageCount = rep.totalPage;
                sceneryInfos = new List<T_SceneryInfoSyncRecord>();

                for (int index = 1; index <= pageCount; index++)
                {
                    rep = SceneryTicketServiceLogic.SceneryInfoSync(record.ID, index, pageSize);
                    if (rep != null && rep.SceneryList != null && rep.SceneryList.Count > 0)
                    {
                        foreach (var s in rep.SceneryList)
                        {
                            List<int> themeIds = new List<int>();
                            if (s.SceneryThemes != null)
                            {
                                s.SceneryThemes.ForEach(u2 =>
                                {
                                    themeIds.Add(u2.ThemeId);
                                });
                            }

                            List<int> impressionIds = new List<int>();
                            if (s.Impressions != null)
                            {
                                s.Impressions.ForEach(u3 =>
                                {
                                    impressionIds.Add(u3.ImpressionId);
                                });
                            }

                            List<int> suitIds = new List<int>();
                            if (s.Suitherds != null)
                            {
                                s.Suitherds.ForEach(u4 =>
                                {
                                    suitIds.Add(u4.suitherdId);
                                });
                            }

                            T_SceneryInfoSyncRecord info = new T_SceneryInfoSyncRecord();

                            info.AddTime = DateTime.Now;
                            info.BookFlag = s.BookFlag;
                            info.CityId = s.CityId;
                            info.CityName = s.CityName ?? "";
                            info.Distance = s.Distance;
                            info.Lat = s.Lat;
                            info.Lon = s.Lon;
                            info.ProvinceId = s.ProvinceId;
                            info.ProvinceName = s.ProvinceName ?? "";
                            info.UpdateTime = DateTime.Parse("1900-1-1");
                            info.SceneryAddress = s.SceneryAddress ?? "";
                            info.SceneryId = s.SceneryId;
                            info.SceneryName = s.SceneryName ?? "";
                            info.ScenerySummary = s.ScenerySummary ?? "";
                            info.Themes = string.Join(",", themeIds);
                            info.GradeId = s.GradeId ?? "";
                            info.Impressions = string.Join(",", impressionIds);
                            info.Suitherds = string.Join(",", suitIds);
                            info.Imgs = s.ImgPath ?? "";
                            info.BookFlag = s.BookFlag;
                            info.ImgBaseUrl = rep.imgbaseURL;
                            info.CommentCount = s.commentCount;
                            info.ViewCount = s.viewCount;
                            info.SceneryAmount = s.sceneryAmount;

                            info.CountyId = s.CountryID;
                            info.CountyName = s.CountryName;
                            info.QuestionCount = s.questionCount;
                            info.AdviceAmount = s.adviceAmount;
                            sceneryInfos.Add(info);


                        }
                    }

                }

                record.SyncState = 1;
                record.LastSyncDate = DateTime.Now;
                record.SceneryCount = rep.totalCount;
                int updateId = provinceData.Update(record);
                action(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                record = provinceData.GetCityRecordToSearchSync();
                sceneryinfoSyncData.InsertBulk(sceneryInfos);
            }
            action("同步完成");
        }

        /// <summary>
        /// 获取景区城市同步记录个数
        /// </summary>
        /// <param name="syncState"></param>
        /// <returns></returns>
        public int GetSceneryCitySyncRecordCount(bool? syncState)
        {
            return provinceData.GetCityCountToSearchSync();
        }

        /// <summary>
        /// 初始化景区城市查询信息
        /// </summary>
        public void InitSceneryCitySyncRecord()
        {
            provinceData.InitScenerySearchState();
            sceneryinfoSyncData.Truncate();
        }

        /// <summary>
        /// 初始化景区城市查询信息
        /// </summary>
        public void InitSceneryInfoSyncRecord()
        {
            //sceneryCitySyncRecordData.UpdateSceneryInfoSyncState(false);
            //sceneryinfoSyncData.Truncate();
        }

        /// <summary>
        /// 初始化景区详细信息数据
        /// </summary>
        public void InitSceneryDetailInfoSyncRecord()
        {
            sceneryinfoSyncData.UpdateSceneryDetailInfoSyncState();
            sceneryInfoDetailData.Truncate();
        }

        /// <summary>
        /// 初始化景区价格同步信息
        /// </summary>
        public void InitSceneryTicketPriceSyncData()
        {
            ticketPriceData.Truncate();
            sceneryinfoSyncData.UpdateSceneryPriceInfoSyncState();
        }

        /// <summary>
        /// 初始化景区图片同步状态
        /// </summary>
        public void InitSceneryImgsSyncDate()
        {
            sceneryinfoSyncData.UpdateSceneryImgInfoSyncState();

        }

        /// <summary>
        /// 获取景区图片信息
        /// </summary>
        /// <param name="action"></param>
        public void SceneryImgSyncRecord(Action<string> action)
        {
            var record = sceneryinfoSyncData.GetRecordForSceneryImgsSync(1).SingleOrDefault();
            GetSceneryImageListReturnEntity apiRep;
            List<T_SceneryImgInfo> imgList;
            T_SceneryImgInfo imgInfo;
            while(record!=null&&record.SceneryId>0)
            {
                apiRep = SceneryTicketServiceLogic.GetSceneryImageList(record.SceneryId);
                imgList = new List<T_SceneryImgInfo>();
                action(string.Format("{0}-{1}",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),record.SceneryName));
                apiRep.ImgList.ForEach(u => {
                    imgInfo = new T_SceneryImgInfo();
                    imgInfo.ImgBaseUrl = apiRep.imageBaseUrl;
                    imgInfo.ImgUrl = u;
                    imgInfo.IsValid = 1;
                    imgInfo.SceneryID = record.SceneryId;
                    imgInfo.SizeInfo = JsonConvert.SerializeObject(apiRep.SizeCodeList);
                    imgList.Add(imgInfo);
                });
                sceneryImgData.InsertBulk(imgList);
                record.ImgSyncState = 1;
                sceneryinfoSyncData.Update(record);
                record = sceneryinfoSyncData.GetRecordForSceneryImgsSync(1).SingleOrDefault();
            }

            action("同步完成");
        }

    }
}
