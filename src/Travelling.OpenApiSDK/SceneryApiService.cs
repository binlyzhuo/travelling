using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Travelling.CommonLibrary;
using Travelling.OpenApiEntity.Scenery;
using Travelling.OpenApiEntity.Scenery.Module;
using Travelling.OpenApiEntity.TC;
using Travelling.FrameWork;

namespace Travelling.OpenApiSDK
{
    /// <summary>
    /// 同程景区门票接口
    /// </summary>
    public class SceneryTicketService : TCApiServiceBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SceneryTicketService()
        {

        }


        /// <summary>
        /// 根据输入的条件搜索符合条件的景区返回列表,用于景区搜索页
        /// </summary>
        /// <returns></returns>
        public GetSceneryListReturnEntity GetSceneryList(GetSceneryListCallEntity callEntity)
        {
            GetSceneryListReturnEntity repEntity = new GetSceneryListReturnEntity();
            StringBuilder reqXml = new StringBuilder();
            reqXml.AppendFormat("<clientIp>{0}</clientIp>", callEntity.ClientIp);
            if (callEntity.ProvinceId != null)
            {
                reqXml.AppendFormat("<provinceId>{0}</provinceId>", callEntity.ProvinceId);
            }
            if (callEntity.CityId != null)
            {
                reqXml.AppendFormat("<cityId>{0}</cityId>", callEntity.CityId);
            }

            reqXml.AppendFormat("<page>{0}</page>", callEntity.Page);
            reqXml.AppendFormat("<pageSize>{0}</pageSize>", callEntity.PageSize);
            if (callEntity.SortType != null)
            {
                reqXml.AppendFormat("<sortType>{0}</sortType>", callEntity.SortType);
            }
            if (!string.IsNullOrEmpty(callEntity.Keyword))
            {
                reqXml.AppendFormat("<keyword>{0}</keyword>", callEntity.Keyword);
            }
            if (!string.IsNullOrEmpty(callEntity.SearchFields))
            {
                reqXml.AppendFormat("<searchFields>{0}</searchFields>", callEntity.SearchFields);
            }
            if (!string.IsNullOrEmpty(callEntity.GradeId))
            {
                reqXml.AppendFormat("<gradeId>{0}</gradeId>", callEntity.GradeId);
            }
            if (!string.IsNullOrEmpty(callEntity.ThemeId))
            {
                reqXml.AppendFormat("<themeId>{0}</themeId>", callEntity.ThemeId);
            }
            if (!string.IsNullOrEmpty(callEntity.PriceRange))
            {
                reqXml.AppendFormat("<priceRange>{0}</priceRange>", callEntity.PriceRange);
            }
            if (!string.IsNullOrEmpty(callEntity.CS))
            {
                reqXml.AppendFormat("<cs>{0}</cs>", callEntity.CS);
            }
            if (!string.IsNullOrEmpty(callEntity.Longitude))
            {
                reqXml.AppendFormat("<longitude>{0}</longitude>", callEntity.Longitude);
            }
            if (!string.IsNullOrEmpty(callEntity.Latitude))
            {
                reqXml.AppendFormat("<latitude>{0}</latitude>", callEntity.Latitude);
            }
            if (!string.IsNullOrEmpty(callEntity.Radius))
            {
                reqXml.AppendFormat("<radius>{0}</radius>", callEntity.Radius);
            }

            var returnEntity = SceneryInfoQuery(reqXml.ToString(), "GetSceneryList");
            var xmlDoc = returnEntity.RepXmlContent;
            LogHelper.Info(xmlDoc.InnerXml);
            List<SceneryViewModel> sceneryList = new List<SceneryViewModel>();
            var sceneryListNode = xmlDoc.SelectSingleNode("rep/sceneryList");
            if (sceneryListNode == null)
            {
                return repEntity;
            }
            repEntity.page = sceneryListNode.ToXmlElement().GetAttribute("page").Trim().ToInt32();
            repEntity.pageSize = sceneryListNode.ToXmlElement().GetAttribute("pageSize").Trim().ToInt32();
            repEntity.totalCount = sceneryListNode.ToXmlElement().GetAttribute("totalCount").Trim().ToInt32();
            repEntity.totalPage = sceneryListNode.ToXmlElement().GetAttribute("totalPage").Trim().ToInt32();
            repEntity.imgbaseURL = sceneryListNode.ToXmlElement().GetAttribute("imgbaseURL").Trim();

            var sceneryNodes = sceneryListNode.SelectNodes("scenery");
            SceneryViewModel scenery;
            foreach (XmlNode sn in sceneryNodes)
            {
                scenery = new SceneryViewModel();
                scenery.blogCount = sn.SelectSingleNode("blogCount").InnerText.Trim().ToInt32();
                scenery.BookFlag = sn.SelectSingleNode("bookFlag").InnerText.Trim().ToInt32();
                scenery.CityId = sn.SelectSingleNode("cityId").InnerText.Trim().ToInt32();
                scenery.CityName = sn.SelectSingleNode("cityName").InnerText.Trim();
                scenery.commentCount = sn.SelectSingleNode("commentCount").InnerText.Trim().ToInt32();
                scenery.Distance = sn.SelectSingleNode("distance").InnerText.Trim().ToDecimal();
                scenery.GradeId = sn.SelectSingleNode("gradeId").InnerText.Trim();
                scenery.ImgPath = sn.SelectSingleNode("imgPath").InnerText.Trim();
                scenery.Lat = sn.SelectSingleNode("lat").InnerText.Trim();
                scenery.Lon = sn.SelectSingleNode("lon").InnerText.Trim();
                scenery.ProvinceId = sn.SelectSingleNode("provinceId").InnerText.Trim().ToInt32();
                scenery.ProvinceName = sn.SelectSingleNode("provinceName").InnerText.Trim();
                scenery.CountryID = sn.SelectSingleNode("countyId")==null ? 0 : sn.SelectSingleNode("countyId").InnerText.Trim().ToInt32();
                scenery.CountryName = sn.SelectSingleNode("countyName") == null ? "" : sn.SelectSingleNode("countyName").InnerText.Trim();
                scenery.adviceAmount = sn.SelectSingleNode("adviceAmount").InnerText.Trim().ToInt32();
                scenery.AmountAdvice = sn.SelectSingleNode("amountAdv").InnerText.Trim().ToInt32();

                scenery.sceneryAmount = sn.SelectSingleNode("sceneryAmount").InnerText.Trim().ToInt32();
                scenery.questionCount = sn.SelectSingleNode("questionCount").InnerText.Trim().ToInt32();
                if (sn.SelectSingleNode("sceneryAddress") != null)
                {
                    scenery.SceneryAddress = sn.SelectSingleNode("sceneryAddress").InnerText.Trim();
                }
                else
                {
                    scenery.SceneryAddress = "";
                }
                //
                scenery.SceneryId = sn.SelectSingleNode("sceneryId").InnerText.Trim().ToInt32();
                scenery.SceneryName = sn.SelectSingleNode("sceneryName").InnerText.Trim();
                if (sn.SelectSingleNode("scenerySummary") != null)
                {
                    scenery.ScenerySummary = sn.SelectSingleNode("scenerySummary").InnerText.Trim();
                }
                else
                {
                    scenery.ScenerySummary = "";
                }
                scenery.viewCount = sn.SelectSingleNode("viewCount").InnerText.Trim().ToInt32();
                var themeNodes = sn.SelectNodes("themeList/theme");
                List<SceneryTheme> themes = new List<SceneryTheme>();
                SceneryTheme theme;
                foreach (XmlNode tn in themeNodes)
                {
                    theme = new SceneryTheme();
                    theme.ThemeId = tn.SelectSingleNode("themeId").InnerText.Trim().ToInt32();
                    theme.ThemeName = tn.SelectSingleNode("themeName").InnerText.Trim();
                    themes.Add(theme);
                }
                scenery.SceneryThemes = themes;

                var impressions = new List<Impression>();
                var impressionNodes = sn.SelectNodes("impressionList/impression");
                Impression impression;
                foreach (XmlNode im in impressionNodes)
                {
                    impression = new Impression();
                    impression.ImpressionId = im.SelectSingleNode("impressionId").InnerText.Trim().ToInt32();
                    impression.ImpressionName = im.SelectSingleNode("impressionName").InnerText.Trim();
                    impressions.Add(impression);
                }
                scenery.Impressions = impressions;

                var Suitherds = new List<Suitherd>();
                var SuitherdNodes = sn.SelectNodes("suitherdList/suitherd");
                Suitherd suitherd;
                foreach (XmlNode un in SuitherdNodes)
                {
                    suitherd = new Suitherd();
                    suitherd.suitherdId = un.SelectSingleNode("suitherdId").InnerText.Trim().ToInt32();
                    suitherd.suitherdName = un.SelectSingleNode("suitherdName").InnerText.Trim();
                    Suitherds.Add(suitherd);
                }
                scenery.Suitherds = Suitherds;
                sceneryList.Add(scenery);
            }
            repEntity.SceneryList = sceneryList;
            return repEntity;
        }

        /// <summary>
        /// 根据景区Id查询景区详情,景区Id根据[获取景区列表]等接口得到
        /// </summary>
        /// <returns></returns>
        public GetSceneryDetailReturnEntity GetSceneryDetail(int sceneryId)
        {
            GetSceneryDetailReturnEntity repEntity = new GetSceneryDetailReturnEntity();
            StringBuilder reqBody = new StringBuilder();
            reqBody.AppendFormat("<sceneryId>{0}</sceneryId>", sceneryId);
            var returnEntity = SceneryInfoQuery(reqBody.ToString(), "GetSceneryDetail");
            repEntity.RspCode = returnEntity.RspCode;
            if(returnEntity.RspCode=="0000")
            {
                var xmlDoc = returnEntity.RepXmlContent;
                var sceneryNode = xmlDoc.SelectSingleNode("rep/scenery");
                repEntity.sceneryId = sceneryNode.SelectSingleNode("sceneryId").InnerText.Trim().ToInt32();
                repEntity.sceneryName = sceneryNode.SelectSingleNode("sceneryName").InnerText.Trim();
                repEntity.grade = sceneryNode.SelectSingleNode("grade").InnerText.Trim();
                repEntity.address = sceneryNode.SelectSingleNode("address").InnerText.Trim();
                repEntity.cityId = sceneryNode.SelectSingleNode("city").ToXmlElement().GetAttribute("id").Trim().ToInt32();
                repEntity.cityName = sceneryNode.SelectSingleNode("city").InnerText.Trim();
                repEntity.provinceId = sceneryNode.SelectSingleNode("province").ToXmlElement().GetAttribute("id").Trim().ToInt32();
                repEntity.provinceName = sceneryNode.SelectSingleNode("province").InnerText.Trim();
                repEntity.intro = sceneryNode.SelectSingleNode("intro").InnerText.Trim();
                repEntity.payMode = sceneryNode.SelectSingleNode("payMode").InnerText.Trim();
                repEntity.amountAdvice = sceneryNode.SelectSingleNode("amountAdvice").InnerText.Trim().ToDecimal();
                repEntity.lon = sceneryNode.SelectSingleNode("lon").InnerText.Trim();
                repEntity.lat = sceneryNode.SelectSingleNode("lat").InnerText.Trim();
                repEntity.buyNotice = sceneryNode.SelectSingleNode("buyNotice").InnerText.Trim();
                
            }
            
            return repEntity;
        }

        /// <summary>
        /// 获取景点交通指南信息GetSceneryTrafficInfo
        /// 根据景区Id查询景区交通指南信息,景区Id根据[获取景区列表]等接口得到
        /// </summary>
        /// <param name="reqEntity"></param>
        /// <returns></returns>
        public GetSceneryTrafficInfoReturnEntity GetSceneryTrafficInfo(GetSceneryTrafficInfoCallEntity reqEntity)
        {
            GetSceneryTrafficInfoReturnEntity repEntity = new GetSceneryTrafficInfoReturnEntity();
            StringBuilder reqBody = new StringBuilder();
            reqBody.AppendFormat("<sceneryId>{0}</sceneryId>", reqEntity.SceneryId);
            var returnEntity = SceneryInfoQuery(reqBody.ToString(), "GetSceneryTrafficInfo");
            var xmlDoc = returnEntity.RepXmlContent;
            var sceneryNode = xmlDoc.SelectSingleNode("rep/scenery");
            repEntity.sceneryId = sceneryNode.SelectSingleNode("sceneryId").InnerText.Trim().ToInt32();
            repEntity.latitude = sceneryNode.SelectSingleNode("latitude").InnerText.Trim();
            repEntity.longitude = sceneryNode.SelectSingleNode("longitude").InnerText.Trim();
            repEntity.traffic = sceneryNode.SelectSingleNode("traffic").InnerText.Trim();
            return repEntity;
        }

        /// <summary>
        /// 获取景点图片列表 GetSceneryImageList
        /// 根据景区Id查询景点图片列表,景区Id根据[获取景区列表]等接口得到
        /// </summary>
        /// <returns></returns>
        public GetSceneryImageListReturnEntity GetSceneryImageList(GetSceneryImageListCallEntity callEntity)
        {
            GetSceneryImageListReturnEntity repEntity = new GetSceneryImageListReturnEntity();
            StringBuilder reqBody = new StringBuilder();
            reqBody.AppendFormat("<sceneryId>{0}</sceneryId>", callEntity.SceneryId);
            reqBody.AppendFormat("<page>{0}</page>", callEntity.Page);
            reqBody.AppendFormat("<pageSize>{0}</pageSize>", callEntity.PageSize);
            var returnEntity = SceneryInfoQuery(reqBody.ToString(), "GetSceneryImageList");
            
            var xmlDoc = returnEntity.RepXmlContent;
            //LogHelper.Info(xmlDoc.InnerXml);

            var imgListNode = xmlDoc.SelectSingleNode("rep/imageList");
            if (imgListNode==null)
            {
                return repEntity;
            }
            repEntity.page = imgListNode.ToXmlElement().GetAttribute("page").Trim().ToInt32();
            repEntity.pageSize = imgListNode.ToXmlElement().GetAttribute("pageSize").Trim().ToInt32();
            repEntity.totalCount = imgListNode.ToXmlElement().GetAttribute("totalCount").Trim().ToInt32();
            repEntity.totalPage = imgListNode.ToXmlElement().GetAttribute("totalPage").Trim().ToInt32();
            var imgNodes = imgListNode.SelectNodes("image/imagePath");
            List<string> imgList = new List<string>();
            foreach (XmlNode im in imgNodes)
            {
                imgList.Add(im.InnerText.Trim());
            }
            repEntity.ImgList = imgList;
            XmlNode imageBaseUrlNode = xmlDoc.SelectSingleNode("rep/extInfoOfImageList/imageBaseUrl");
            repEntity.imageBaseUrl = imageBaseUrlNode.InnerText.Trim();
            var imgSizeNodes = xmlDoc.SelectNodes("rep/extInfoOfImageList/sizeCodeList/sizeCode");
            List<ImgSizeCode> imgSizeCodes = new List<ImgSizeCode>();
            ImgSizeCode imgSizeCode;
            foreach (XmlNode sn in imgSizeNodes)
            {
                imgSizeCode = new ImgSizeCode();
                imgSizeCode.Size = sn.ToXmlElement().GetAttribute("size").Trim().ToInt32();
                imgSizeCode.SizeValue = sn.InnerText.Trim();
                imgSizeCode.IsDefault = sn.ToXmlElement().GetAttribute("isDefault") != null ? sn.ToXmlElement().GetAttribute("isDefault").Trim() : "";
                imgSizeCodes.Add(imgSizeCode);
            }
            repEntity.SizeCodeList = imgSizeCodes;
            return repEntity;
        }

        /// <summary>
        /// 获取周边景点GetNearbyScenery
        /// 根据景区Id查询景点周边热门景点列表,景区Id根据[获取景区列表]等接口得到
        /// </summary>
        /// <param name="callEntity"></param>
        /// <returns></returns>
        public GetNearbySceneryReturnEntity GetNearbyScenery(GetNearbySceneryCallEntity callEntity)
        {
            GetNearbySceneryReturnEntity repEntity = new GetNearbySceneryReturnEntity();
            StringBuilder reqBody = new StringBuilder();
            reqBody.AppendFormat("<sceneryId>{0}</sceneryId>", callEntity.SceneryId);
            reqBody.AppendFormat("<page>{0}</page>", callEntity.Page);
            reqBody.AppendFormat("<pageSize>{0}</pageSize>", callEntity.PageSize);
            var returnEntity = SceneryInfoQuery(reqBody.ToString(), "GetNearbyScenery");
            var xmlDoc = returnEntity.RepXmlContent;
            var sceneryListNode = xmlDoc.SelectSingleNode("rep/sceneryList");
            if (sceneryListNode == null)
            {
                return repEntity;
            }
            repEntity.page = sceneryListNode.ToXmlElement().GetAttribute("page").Trim().ToInt32();
            repEntity.pageSize = sceneryListNode.ToXmlElement().GetAttribute("pageSize").Trim().ToInt32();
            repEntity.totalCount = sceneryListNode.ToXmlElement().GetAttribute("totalCount").Trim().ToInt32();
            repEntity.totalPage = sceneryListNode.ToXmlElement().GetAttribute("totalPage").Trim().ToInt32();
            var sceneryNodes = sceneryListNode.SelectNodes("scenery");
            List<SceneryNearInfo> sceneryList = new List<SceneryNearInfo>();
            SceneryNearInfo scenery;
            foreach (XmlNode sn in sceneryNodes)
            {
                scenery = new SceneryNearInfo();
                scenery.SceneryId = sn.SelectSingleNode("id").InnerText.Trim().ToInt32();
                scenery.SceneryName = sn.SelectSingleNode("name").InnerText.Trim();
                scenery.AmountAdvice = sn.SelectSingleNode("amount").InnerText.Trim().ToInt32();
                scenery.GradeId = sn.SelectSingleNode("grade").InnerText.Trim().ToInt32();
                sceneryList.Add(scenery);
            }
            repEntity.SceneryList = sceneryList;
            return repEntity;
        }

        /// <summary>
        /// 获取价格搜索接口 GetSceneryPrice
        /// 根据景区Id,获取价格搜索接口
        /// </summary>
        /// <returns></returns>
        public GetSceneryPriceReturnEntity GetSceneryPrice(GetSceneryPriceCallEntity callEntity)
        {
            var repEntity = new GetSceneryPriceReturnEntity();
            StringBuilder reqBody = new StringBuilder();
            reqBody.AppendFormat("<showDetail>{0}</showDetail>", callEntity.ShowDetail);
            reqBody.AppendFormat("<sceneryIds>{0}</sceneryIds>", callEntity.SceneryIds);
            reqBody.AppendFormat("<useCache>{0}</useCache>", callEntity.UseCache);
            var returnEntity = SceneryInfoQuery(reqBody.ToString(), "GetSceneryPrice");
            repEntity.RspCode = returnEntity.RspCode;
            var xmlDoc = returnEntity.RepXmlContent;
            //LogHelper.Info(xmlDoc.InnerXml);
            var sceneryNodes = xmlDoc.SelectNodes("rep/sceneryList/scenery");
            List<SceneryPriceInfo> SceneryPrices = new List<SceneryPriceInfo>();
            SceneryPriceInfo price;
            foreach (XmlNode sn in sceneryNodes)
            {
                price = new SceneryPriceInfo();
                price.SceneryId = sn.SelectSingleNode("sceneryId").InnerText.Trim().ToInt32();
                var policyNodes = sn.SelectNodes("policy/p");
                List<SceneryPolicy> polices = new List<SceneryPolicy>();
                SceneryPolicy policy;
                foreach (XmlNode pn in policyNodes)
                {
                    policy = new SceneryPolicy();
                    policy.PolicyId = pn.SelectSingleNode("policyId").InnerText.Trim().ToInt32();
                    policy.PolicyName = pn.SelectSingleNode("policyName").InnerText.Trim();
                    policy.Remark = pn.SelectSingleNode("remark").InnerText.Trim();
                    policy.price = pn.SelectSingleNode("price").InnerText.Trim().ToDecimal();
                    policy.tcPrice = pn.SelectSingleNode("tcPrice").InnerText.Trim().ToDecimal();
                    policy.pMode = pn.SelectSingleNode("pMode").InnerText.Trim().ToInt32();
                    policy.gMode = pn.SelectSingleNode("gMode").InnerText.Trim();
                    policy.minT = pn.SelectSingleNode("minT").InnerText.Trim().ToInt32();
                    policy.maxT = pn.SelectSingleNode("maxT").InnerText.Trim().ToInt32();
                    policy.dpPrize = pn.SelectSingleNode("dpPrize").InnerText.Trim().ToDecimal();
                    policy.orderUrl = pn.SelectSingleNode("orderUrl").InnerText.Trim();
                    policy.realName = pn.SelectSingleNode("realName").InnerText.Trim().ToInt32();
                    policy.useCard = pn.SelectSingleNode("useCard").InnerText.Trim().ToInt32();
                    policy.ticketId = pn.SelectSingleNode("ticketId").InnerText.Trim().ToInt32();
                    policy.ticketName = pn.SelectSingleNode("ticketName").InnerText.Trim();
                    policy.bDate = pn.SelectSingleNode("bDate").InnerText.Trim().ToDateTime();
                    policy.eDate = pn.SelectSingleNode("eDate").InnerText.Trim().ToDateTime();
                    policy.openDateType = pn.SelectSingleNode("openDateType").InnerText.Trim().ToInt32();
                    policy.openDateValue = pn.SelectSingleNode("openDateValue").InnerText.Trim();
                    policy.closeDate = pn.SelectSingleNode("closeDate").InnerText.Trim();
                    policy.SceneryId = price.SceneryId;
                    polices.Add(policy);
                }
                price.Policies = polices;

                var noticeNodes = sn.SelectNodes("notice/n");

                List<SceneryNotice> notices = new List<SceneryNotice>();
                SceneryNotice notice;
                foreach (XmlNode nn in noticeNodes)
                {
                    notice = new SceneryNotice();
                    notice.TypeId = nn.SelectSingleNode("nType").InnerText.Trim().ToInt32();
                    notice.TypeName = nn.SelectSingleNode("nTypeName").InnerText.Trim();

                    var infoNodes = nn.SelectNodes("nInfo/info");
                    List<NoticeInfo> infos = new List<NoticeInfo>();
                    NoticeInfo info;
                    foreach (XmlNode fn in infoNodes)
                    {
                        info = new NoticeInfo();
                        info.Id = fn.SelectSingleNode("nId").InnerText.Trim().ToInt32();
                        info.Name = fn.SelectSingleNode("nName").InnerText.Trim();
                        info.Content = fn.SelectSingleNode("nContent").InnerText.Trim();
                        infos.Add(info);
                    }
                }

                price.Notices = notices;
                SceneryPrices.Add(price);

            }
            repEntity.SceneryPrices = SceneryPrices;
            return repEntity;
        }

        /// <summary>
        /// 获取价格日历
        /// </summary>
        /// <returns></returns>
        public GetPriceCalendarReturnEntity GetPriceCalendar(GetPriceCalendarCallEntity callEntity)
        {
            GetPriceCalendarReturnEntity rep = new GetPriceCalendarReturnEntity();

            StringBuilder reqBody = new StringBuilder();
            reqBody.AppendFormat("<policyId>{0}</policyId>",callEntity.policyId);
            reqBody.AppendFormat("<startDate>{0}</startDate>", callEntity.startDate.ToString("yyyy-MM-dd"));
            reqBody.AppendFormat("<endDate>{0}</endDate>", callEntity.endDate.ToString("yyyy-MM-dd"));
            reqBody.AppendFormat("<showDetail>{0}</showDetail>",callEntity.showDetail?1:0);

            var returnEntity = SceneryInfoQuery(reqBody.ToString(), "GetPriceCalendar");
            //var xmlDoc = returnEntity.RepXmlContent;
            //var serialIdNode = xmlDoc.SelectSingleNode("rep/order/serialIdNode");
            //var msecondsNode = xmlDoc.SelectSingleNode("rep/order/mseconds");
            //repEntity.SerialId = serialIdNode.InnerText.Trim();
            //repEntity.Mseconds = msecondsNode.InnerText.Trim();
            //return repEntity;
            return rep;
        }

        /// <summary>
        /// 提交订单接口SubmitSceneryOrder
        /// 提交预订信息
        /// </summary>
        /// <param name="callEntity"></param>
        /// <returns></returns>
        public SubmitSceneryOrderReturnEntity SubmitSceneryOrder(SubmitSceneryOrderCallEntity callEntity)
        {
            
            StringBuilder reqBody = new StringBuilder();
            reqBody.AppendFormat("<sceneryId>{0}</sceneryId>", callEntity.SceneryId);
            reqBody.AppendFormat("<bMan>{0}</bMan>", callEntity.Man);
            reqBody.AppendFormat("<bMobile>{0}</bMobile>", callEntity.Mobile);
            reqBody.AppendFormat("<bAddress>{0}</bAddress>", callEntity.Address);
            reqBody.AppendFormat("<bPostCode>{0}</bPostCode>", callEntity.PostCode);
            reqBody.AppendFormat("<bEmail>{0}</bEmail>", callEntity.bEmail);
            reqBody.AppendFormat("<tName>{0}</tName>", callEntity.tName);
            reqBody.AppendFormat("<tMobile>{0}</tMobile>", callEntity.tMobile);
            reqBody.AppendFormat("<policyId>{0}</policyId>", callEntity.PolicyId);
            reqBody.AppendFormat("<tickets>{0}</tickets>", callEntity.Tickets);
            reqBody.AppendFormat("<travelDate>{0}</travelDate>", callEntity.TravelDate.ToString("yyyy-MM-dd"));
            reqBody.AppendFormat("<orderIP>{0}</orderIP>", callEntity.OrderIP);
            reqBody.AppendFormat("<idCard>{0}</idCard>", callEntity.IdCard);
            reqBody.Append("<otherGuest>");

            if (callEntity.Guests != null && callEntity.Guests.Count>0)
            {
                callEntity.Guests.ForEach(u =>
                {
                    reqBody.Append("<guest>");
                    reqBody.AppendFormat("<gName>{0}</gName>", u.gName);
                    reqBody.AppendFormat("<gMobile>{0}</gMobile>", u.gMobile);
                    reqBody.Append("</guest>");
                });
            }

            
            reqBody.Append("</otherGuest>");
            var repEntity = SceneryOrderQuery(reqBody.ToString(), "SubmitSceneryOrder");
            SubmitSceneryOrderReturnEntity returnEntity = new SubmitSceneryOrderReturnEntity();
            GetRepHeaderInfo(repEntity, returnEntity);
            if (repEntity.RspCode == "0000")
            {
                var xmlDoc = repEntity.RepXmlContent;
                var serialIdNode = xmlDoc.SelectSingleNode("rep/order/serialId");
                var msecondsNode = xmlDoc.SelectSingleNode("rep/order/mseconds");
                returnEntity.SerialId = serialIdNode.InnerText.Trim();
                returnEntity.Mseconds = msecondsNode.InnerText.Trim();
            }

            return returnEntity;
        }

        public void GetRepHeaderInfo(TongChengBaseReturnEntity baseReturnEntity,TongChengBaseReturnEntity childReturnentity)
        {
            childReturnentity.RspCode = baseReturnEntity.RspCode;
            childReturnentity.RspDesc = baseReturnEntity.RspDesc;
        }

        /// <summary>
        /// 取消景区订单（如果需要重新修改订单，则采用先取消订单再重新下单方式）
        /// </summary>
        /// <param name="callEntity"></param>
        /// <returns></returns>
        public CancelSceneryOrderReturnEntity CancelSceneryOrder(CancelSceneryOrderCallEntity callEntity)
        {
            CancelSceneryOrderReturnEntity repEntiy = new CancelSceneryOrderReturnEntity();
            StringBuilder reqBody = new StringBuilder();
            reqBody.AppendFormat("<serialId>{0}</serialId>", callEntity.SerialId);
            reqBody.AppendFormat("<cancelReason>{0}</cancelReason>", callEntity.CancelReason);
            var returnEntity = SceneryOrderQuery(reqBody.ToString(), "CancelSceneryOrder");
            var xmlDoc = returnEntity.RepXmlContent;
            repEntiy.IsSuccess = xmlDoc.SelectSingleNode("rep/isSuc").InnerText.Trim();
            repEntiy.ErrorMsg = xmlDoc.SelectSingleNode("rep/errMsg").InnerText.Trim();
            return repEntiy;
        }

        /// <summary>
        /// 获取点评列表，根据景区Id获取相关的点评信息，
        /// 最多返回10条记录
        /// </summary>
        /// <param name="callEntity"></param>
        /// <returns></returns>
        public GetCommentListReturnEntity GetCommentList(GetCommentListCallEntity callEntity)
        {
            GetCommentListReturnEntity repEntity = new GetCommentListReturnEntity();
            StringBuilder reqBody = new StringBuilder();
            reqBody.AppendFormat("<sceneryId>{0}</sceneryId>", callEntity.SceneryId);
            var returnEntity = SceneryCommentQuery(reqBody.ToString(), "GetCommentList");
            var xmlDoc = returnEntity.RepXmlContent;
            var commentNodes = xmlDoc.SelectNodes("rep/commentList/comment");
            List<Comment> comments = new List<Comment>();
            Comment comment;
            foreach (XmlNode cm in commentNodes)
            {
                comment = new Comment();
                comment.CreateDate = cm.SelectSingleNode("createDate").InnerText.Trim().ToDateTime();
                comment.OverallRating = cm.SelectSingleNode("overallRating").InnerText.Trim();
                comment.Content = cm.SelectSingleNode("content").InnerText.Trim();
                comments.Add(comment);
            }
            repEntity.Comments = comments;
            return repEntity;
        }
    }
}
