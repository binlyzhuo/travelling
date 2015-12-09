using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Travelling.OpenApiEntity.TC.Hotel;
using Travelling.FrameWork;
using Travelling.OpenApiEntity.TC.Hotel.Module;

namespace Travelling.OpenApiSDK
{
    /// <summary>
    /// 同程酒店相关接口
    /// </summary>
    public class TCHotelOTAService : TCApiServiceBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public TCHotelOTAService()
        {

        }

        /// <summary>
        /// 同程酒店信息查询
        /// </summary>
        /// <param name="callEntity"></param>
        /// <returns></returns>
        public GetHotelListReturnEntity GetHotelList(GetHotelListCallEntity callEntity)
        {
            GetHotelListReturnEntity repEntity = new GetHotelListReturnEntity();
            StringBuilder reqXml = new StringBuilder();
            reqXml.AppendFormat("<cityId>{0}</cityId>",callEntity.cityId);
            reqXml.AppendFormat("<comeDate>{0}</comeDate>",callEntity.comeDate.ToString("yyyy-MM-dd"));
            reqXml.AppendFormat("<leaveDate>{0}</leaveDate>", callEntity.leaveDate.ToString("yyyy-MM-dd"));
            if(!string.IsNullOrEmpty(callEntity.keyword))
            {
                reqXml.AppendFormat("<keyword>{0}</keyword>",callEntity.keyword);
                reqXml.AppendFormat("<searchFields>{0}</searchFields>", callEntity.searchFields);
            }
            if(callEntity.chainId!=null)
            {
                reqXml.AppendFormat("<chainId>{0}</chainId>",callEntity.chainId);
            }
            reqXml.AppendFormat("<page>{0}</page>", callEntity.Page);
            reqXml.AppendFormat("<pageSize>{0}</pageSize>",callEntity.PageSize);
            reqXml.AppendFormat("<clientIp>{0}</clientIp>","127.0.0.1");
            var returnEntity = HotelInfoQuery(reqXml.ToString(), "GetHotelList");

            XmlDocument docXml = returnEntity.RepXmlContent;
            List<TCHotelInfo> hotels = new List<TCHotelInfo>();
            var hotellistNode = docXml.SelectSingleNode("rep/hotelList");
            repEntity.page = hotellistNode.ToXmlElement().GetAttribute("page").ToInt32();
            repEntity.pageSize = hotellistNode.ToXmlElement().GetAttribute("pageSize").ToInt32();
            repEntity.totalCount = hotellistNode.ToXmlElement().GetAttribute("totalCount").ToInt32();
            repEntity.totalPage = hotellistNode.ToXmlElement().GetAttribute("totalPage").ToInt32();
            repEntity.imageBaseUrl = hotellistNode.ToXmlElement().GetAttribute("imageBaseUrl");

            var hotelNodes = docXml.SelectNodes("rep/hotelList/hotel");
            if (hotelNodes != null && hotelNodes.Count>0)
            {
                
               TCHotelInfo hotel;
               foreach(XmlNode hotelNode in hotelNodes)
               {
                   hotel = new TCHotelInfo();
                   hotel.address = hotelNode.SelectSingleNode("address").InnerText.Trim();
                   //hotel.bizSectionId = hotelNode.SelectSingleNode("bizSection/bizSectionId").InnerText.Trim().ToInt32();
                   hotel.cityId = hotelNode.SelectSingleNode("city/cityId").InnerText.Trim().ToInt32();
                   hotel.cityName = hotelNode.SelectSingleNode("city/cityName").InnerText.Trim();
                   hotel.commentBad = hotelNode.SelectSingleNode("commentCount/commentBad").InnerText.Trim().ToInt32();
                   hotel.commentGood = hotelNode.SelectSingleNode("commentCount/commentGood").InnerText.Trim().ToInt32();
                   hotel.commentMid = hotelNode.SelectSingleNode("commentCount/commentMid").InnerText.Trim().ToInt32();
                   hotel.commentTotal = hotelNode.SelectSingleNode("commentCount/commentTotal").InnerText.Trim().ToInt32();
                   hotel.createDate = hotelNode.SelectSingleNode("createDate").InnerText.Trim();
                   hotel.groupBuy = hotelNode.SelectSingleNode("groupBuy").InnerText.Trim().ToInt32();
                   hotel.highestPrice = hotelNode.SelectSingleNode("highestPrice").InnerText.Trim().ToDecimal();
                   hotel.hotelId = hotelNode.SelectSingleNode("hotelId").InnerText.Trim().ToInt32();
                   hotel.hotelName = hotelNode.SelectSingleNode("hotelName").InnerText.Trim();
                   hotel.img = hotelNode.SelectSingleNode("img").InnerText.Trim();
                   hotel.intro = hotelNode.SelectSingleNode("intro").InnerText.Trim();
                   hotel.latitude = hotelNode.SelectSingleNode("latitude").InnerText.Trim();
                   hotel.longitude = hotelNode.GetChildNodeInnerText("longitude");
                   hotel.lowestPrice = hotelNode.GetChildNodeInnerText("lowestPrice").ToDecimal();
                   hotel.oneWord = hotelNode.GetChildNodeInnerText("oneWord");
                   hotel.recmdLevel = hotelNode.GetChildNodeInnerText("recmdLevel").ToInt32();
                   hotel.remark = hotelNode.GetChildNodeInnerText("remark");
                   hotel.roomType = hotelNode.GetChildNodeInnerText("roomType");
                   hotel.sectionId = hotelNode.GetChildNode("section").GetChildNodeInnerText("sectionId").ToInt32();
                   hotel.sectionName = hotelNode.GetChildNode("section").GetChildNodeInnerText("sectionName");
                   //hotel.starRatedClass = hotelNode.GetChildNode("starRated").GetChildNodeInnerText("starRatedClass");
                  // hotel.starRatedId = hotelNode.GetChildNode("starRated").GetChildNodeInnerText("starRatedId").ToInt32();
                   //hotel.starRatedName = hotelNode.GetChildNode("starRated").GetChildNodeInnerText("starRatedName");
                   //hotel.street = hotelNode.GetChildNodeInnerText("street");
                   //hotel.streetAddr = hotelNode.GetChildNodeInnerText("streetAddr");
                   hotel.viewCount = hotelNode.GetChildNodeInnerText("viewCount").ToInt32();

                   hotels.Add(hotel);
               }
            }
            repEntity.Hotels = hotels;
            return repEntity;
        }

        /// <summary>
        /// 获取酒店详情
        /// </summary>
        /// <param name="callEntity"></param>
        /// <returns></returns>
        public GetHotelDetailReturnEntity GetHotelDetail(GetHotelDetailCallEntity callEntity)
        {
            GetHotelDetailReturnEntity repEntity = new GetHotelDetailReturnEntity();
            StringBuilder reqBody = new StringBuilder();
            reqBody.AppendFormat("<hotelId>{0}</hotelId>",callEntity.HotelId);
            var rep = HotelInfoQuery(reqBody.ToString(), "GetHotelDetail");
            XmlDocument docXml = rep.RepXmlContent;
            TCHotelDetailInfo hotel = new TCHotelDetailInfo();
            XmlNode hotelNode = docXml.SelectSingleNode("rep/hotelInfo");
            hotel.hotelId = hotelNode.SelectSingleNode("hotelId").InnerText.Trim().ToInt32();
            hotel.hotelName = hotelNode.SelectSingleNode("hotelName").InnerText.Trim();
            hotel.starRatedId = hotelNode.GetChildNode("starRated").GetChildNodeInnerText("starRatedId").ToInt32();
            hotel.starRatedName = hotelNode.GetChildNode("starRated").GetChildNodeInnerText("starRatedName");
            hotel.cityId = hotelNode.SelectSingleNode("city/cityId").InnerText.Trim().ToInt32();
            hotel.cityName = hotelNode.SelectSingleNode("city/cityName").InnerText.Trim();
            //hotel.bizSectionId = hotelNode.SelectSingleNode("bizSection/bizSectionId").InnerText.Trim().ToInt32();
            //hotel.bizSectionName = hotelNode.SelectSingleNode("bizSection/bizSectionName").InnerText.Trim();
            hotel.street = hotelNode.GetChildNodeInnerText("street");
            hotel.streetAddr = hotelNode.GetChildNodeInnerText("streetAddr");
            hotel.address = hotelNode.SelectSingleNode("address").InnerText.Trim();
            hotel.nearby = hotelNode.SelectSingleNode("nearby").InnerText.Trim();
            hotel.chainId = hotelNode.GetChildNode("chain").GetChildNode("chainId").InnerText.Trim().ToInt32();
            hotel.chainName = hotelNode.GetChildNode("chain").GetChildNode("chainName").InnerText.Trim();

            XmlNodeList bizSectionNodes = hotelNode.SelectNodes("hotelNode");
            List<TCBizSection> bizSections = new List<TCBizSection>();
            foreach (XmlNode n in bizSectionNodes)
            {
                bizSections.Add(new TCBizSection() {
                    bizSectionId = n.GetChildNode("bizSectionId").InnerText.Trim().ToInt32(),
                    bizSectionName = n.GetChildNode("bizSectionName").InnerText.Trim()
                });
            }
            hotel.bizSection = bizSections;

            XmlNodeList impressItemNodes = hotelNode.SelectNodes("impressList/item");
            List<TCHotelImpress> impressList = new List<TCHotelImpress>();
            
            foreach(XmlNode n in impressItemNodes)
            {
                impressList.Add(new TCHotelImpress() { 
                  Id = n.ToXmlElement().GetAttribute("id").Trim().ToInt32(), Name = n.InnerText.Trim()
                });
            }

            hotel.impressList = impressList;

            hotel.openingDate = hotelNode.GetChildNode("openingDate").InnerText.Trim();
            hotel.decoDate = hotelNode.GetChildNode("decoDate").InnerText.Trim();
            hotel.additionalService = hotelNode.GetChildNode("additionalService").InnerText.Trim();
            hotel.service = hotelNode.GetChildNode("service").InnerText.Trim();
            hotel.facility = hotelNode.GetChildNode("facility").InnerText.Trim();

            List<TCHotelServiceInfo> est2List = new List<TCHotelServiceInfo>();
            XmlNodeList est2Nodes = hotelNode.SelectNodes("est2List/est");
            foreach (XmlNode n in est2Nodes)
            {
                est2List.Add(new TCHotelServiceInfo() { 
                 id = n.GetChildNode("id").InnerText.Trim().ToInt32(), name = n.GetChildNode("name").InnerText.Trim(), type = n.GetChildNode("type").InnerText.Trim()
                });
            }
            hotel.est2List = est2List;
            hotel.catering = hotelNode.GetChildNode("catering").InnerText.Trim();
      
            hotel.recreation = hotelNode.GetChildNodeInnerText("recreation");
            hotel.creditCard = hotelNode.GetChildNodeInnerText("creditCard");
            hotel.intro = hotelNode.GetChildNodeInnerText("intro");
            hotel.latitude = hotelNode.SelectSingleNode("latitude").InnerText.Trim();
            hotel.longitude = hotelNode.GetChildNodeInnerText("longitude");
            hotel.remark = hotelNode.GetChildNodeInnerText("remark");
            hotel.highestPrice = hotelNode.SelectSingleNode("highestPrice").InnerText.Trim().ToDecimal();
            hotel.lowestPrice = hotelNode.GetChildNodeInnerText("lowestPrice").ToDecimal();
            hotel.commentBad = hotelNode.SelectSingleNode("commentCount/commentBad").InnerText.Trim().ToInt32();
            hotel.commentGood = hotelNode.SelectSingleNode("commentCount/commentGood").InnerText.Trim().ToInt32();
            hotel.commentMid = hotelNode.SelectSingleNode("commentCount/commentMid").InnerText.Trim().ToInt32();
            hotel.commentTotal = hotelNode.SelectSingleNode("commentCount/commentTotal").InnerText.Trim().ToInt32();

            hotel.introPhoto = hotelNode.GetChildNodeInnerText("introPhoto");
            hotel.oneWord = hotelNode.GetChildNodeInnerText("oneWord");

            XmlNode sectionNode = hotelNode.SelectNodes("sectionId")[0];
            hotel.sectionId = sectionNode.GetChildNodeInnerText("sectionId").ToInt32();
            hotel.sectionName = sectionNode.GetChildNodeInnerText("sectionName");


            repEntity.HotelDetailInfo = hotel;
            return repEntity;
        }

        /// <summary>
        /// 酒店房型信息查询
        /// </summary>
        /// <param name="callEntity"></param>
        /// <returns></returns>
        public GetHotelRoomsReturnEntity GetHotelRooms(GetHotelRoomsCallEntity callEntity)
        {
            GetHotelRoomsReturnEntity repEntity = new GetHotelRoomsReturnEntity();
            StringBuilder reqBody = new StringBuilder();
            reqBody.AppendFormat("<hotelId>{0}</hotelId>",callEntity.hotelId);
            reqBody.AppendFormat("<comeDate>{0}</comeDate>",callEntity.comeDate.ToString("yyyy-MM-dd"));
            reqBody.AppendFormat("<leaveDate>{0}</leaveDate>",callEntity.leaveDate.ToString("yyyy-MM-dd"));

            var rep = HotelInfoQuery(reqBody.ToString(), "GetHotelRooms");
            XmlDocument xmlDoc = rep.RepXmlContent;
            XmlNode hotelInfoNode = xmlDoc.SelectSingleNode("rep/hotelInfo");
            repEntity.hotelChainId = hotelInfoNode.GetChildNodeInnerText("hotelChainId");
            repEntity.hotelCode = hotelInfoNode.GetChildNodeInnerText("hotelCode");
            repEntity.hotelId = hotelInfoNode.GetChildNodeInnerText("hotelId").ToInt32();
            repEntity.hotelName = hotelInfoNode.GetChildNodeInnerText("hotelName");
            repEntity.hotelType = hotelInfoNode.GetChildNodeInnerText("hotelType");

            repEntity.imageBaseUrl = xmlDoc.SelectSingleNode("rep/hotelRoomList").ToXmlElement().GetAttribute("imageBaseUrl").Trim();

            XmlNodeList roomNodes = xmlDoc.SelectNodes("rep/hotelRoomList/hotelRoomInfo");

            List<TCHotelRoomInfo> Rooms = new List<TCHotelRoomInfo>();
            List<TCHotelRoomPricePolicyInfo> policyinfos;
            TCHotelRoomPricePolicyInfo policyinfo;
            TCHotelRoomInfo room;
            foreach(XmlNode n in roomNodes)
            {
                room = new TCHotelRoomInfo();
                room.adsl = n.GetChildNodeInnerText("adsl").ToInt32();
                room.adslRemark = n.GetChildNodeInnerText("adsl");
                room.adviceAmount = n.GetChildNodeInnerText("adviceAmount").ToInt32();
                room.allowAddBed = n.GetChildNodeInnerText("allowAddBed").ToInt32();
                room.allowAddBedRemark = n.GetChildNodeInnerText("allowAddBedRemark");
                room.area = n.GetChildNodeInnerText("area").ToInt32();
                room.bed = n.GetChildNodeInnerText("bed");
                room.bedWidth = n.GetChildNodeInnerText("bedWidth");
                room.breakfast = n.GetChildNodeInnerText("breakfast");
                room.certificateType = n.GetChildNodeInnerText("certificateType");
                room.floor = n.GetChildNodeInnerText("floor");
                room.noSmoking = n.GetChildNodeInnerText("noSmoking").ToInt32();
                room.ownBath = n.GetChildNodeInnerText("ownBath").ToInt32();
                room.photoUrl = n.GetChildNodeInnerText("photoUrl");
                room.roomCount = n.GetChildNodeInnerText("roomCount").ToInt32();
                room.roomName = n.GetChildNodeInnerText("roomName");
                room.roomTypeId = n.GetChildNodeInnerText("roomTypeId").ToInt32();
                room.roomTypeRemark = n.GetChildNodeInnerText("roomTypeRemark");
                policyinfos = new List<TCHotelRoomPricePolicyInfo>();

                XmlNodeList policyNodes = n.SelectNodes("pricePolicyList/pricePolicyInfo");
                foreach (XmlNode pn in policyNodes)
                {
                    policyinfo = new TCHotelRoomPricePolicyInfo();
                    policyinfo.advDays = pn.GetChildNodeInnerText("advDays").ToInt32();
                    policyinfo.avgAmount = pn.GetChildNodeInnerText("avgAmount").ToInt32();
                    policyinfo.bookingCode = pn.GetChildNodeInnerText("advDays");
                    policyinfo.bookingFlag = pn.GetChildNodeInnerText("bookingFlag").ToInt32();
                    policyinfo.continuousDays = pn.GetChildNode("continuous").GetChildNodeInnerText("continuousDays").ToInt32();
                    policyinfo.continuousFreeDays = pn.GetChildNode("continuous").GetChildNodeInnerText("continuousFreeDays").ToInt32();
                    policyinfo.continuousType = pn.GetChildNode("continuous").GetChildNodeInnerText("continuousType").ToInt32();
                    policyinfo.currency = pn.GetChildNodeInnerText("currency").ToInt32();
                    policyinfo.deductAmount = pn.GetChildNodeInnerText("deductAmount").ToInt32();
                    policyinfo.exchangeRate = pn.GetChildNodeInnerText("exchangeRate").ToInt32();
                    policyinfo.factorMark = pn.GetChildNodeInnerText("factorMark").ToInt32();
                    policyinfo.guaranteeFlag = pn.GetChildNodeInnerText("guaranteeFlag").ToInt32();
                    policyinfo.guaranteeInfo = pn.GetChildNodeInnerText("guaranteeInfo");
                    policyinfo.guaranteeType = pn.GetChildNodeInnerText("guaranteeType").ToInt32();
                    policyinfo.packageBrief = pn.GetChildNodeInnerText("packageBrief");
                    policyinfo.policyId = pn.GetChildNodeInnerText("policyId").ToInt32();
                    policyinfo.policyName = pn.GetChildNodeInnerText("policyName");
                    policyinfo.policyRemark = pn.GetChildNodeInnerText("policyRemark");
                    policyinfo.policyType = pn.GetChildNodeInnerText("policyType").ToInt32();
                    policyinfo.roomAdviceAmount = pn.GetChildNodeInnerText("roomAdviceAmount");
                    policyinfo.roomBreakfast = pn.GetChildNodeInnerText("roomBreakfast");
                    policyinfo.roomPrize = pn.GetChildNodeInnerText("roomPrize");
                    policyinfo.roomStatus = pn.GetChildNodeInnerText("roomStatus").ToInt32();
                    policyinfo.roomStatusTotal = pn.GetChildNodeInnerText("roomStatusTotal").ToInt32();
                    policyinfo.roomUndetermined = pn.GetChildNodeInnerText("roomUndetermined").ToInt32();
                    policyinfo.roomuUndeterminedTotal = pn.GetChildNodeInnerText("roomuUndeterminedTotal").ToInt32();
                    policyinfo.surplusRooms = pn.GetChildNodeInnerText("surplusRooms").ToInt32();
                    
                    XmlNode presentNode = pn.SelectSingleNode("present");
                    TCHotelPresent present = new TCHotelPresent() {
                        description = presentNode.GetChildNodeInnerText("description"),
                        presentFlag = presentNode.GetChildNodeInnerText("presentFlag").ToInt32(),
                        startTime = presentNode.GetChildNodeInnerText("startTime")
                    };
                    policyinfo.Present = present;
                    policyinfos.Add(policyinfo);

                }
                room.PolicyInfos = policyinfos;
                Rooms.Add(room);
            }
            repEntity.Rooms = Rooms;
            return repEntity;
        }

        /// <summary>
        /// 获取酒店图片信息
        /// </summary>
        /// <param name="callEntity"></param>
        /// <returns></returns>
        public GetHotelImageListReturnEntity GetHotelImageList(GetHotelImageListCallEntity callEntity)
        {
            GetHotelImageListReturnEntity repEntity = new GetHotelImageListReturnEntity();
            StringBuilder reqBody = new StringBuilder();
            reqBody.AppendFormat("<hotelId>{0}</hotelId>",callEntity.hotelId);
            var rep = HotelInfoQuery(reqBody.ToString(), "GetHotelImageList");
            XmlDocument xmlDoc = rep.RepXmlContent;
            XmlNodeList imgNodes = xmlDoc.SelectNodes("rep/hotelImageList/hotelImage");
            List<TCHotelImage> imgs = new List<TCHotelImage>();
            foreach(XmlNode n in imgNodes)
            {
                imgs.Add(new TCHotelImage() {
                    imageId = n.GetChildNodeInnerText("imageId").ToInt32(),
                    imageName = n.GetChildNodeInnerText("imageName"),
                    imageUrl = n.GetChildNodeInnerText("imageUrl")
                });
            }
            repEntity.Imgs = imgs;
            repEntity.imageBaseUrl = xmlDoc.SelectSingleNode("rep/extInfoOfImageList/imageBaseUrl").InnerText;
            XmlNodeList sizeCodeNodes = xmlDoc.SelectNodes("rep/extInfoOfImageList/sizeCodeList/sizeCode");
            List<string> sizeCodeList = new List<string>();
            foreach (XmlNode n in sizeCodeNodes)
            {
                sizeCodeList.Add(n.InnerText.Trim());
            }
            repEntity.sizeCodeList = sizeCodeList;
            XmlNodeList sizeCodeListWatermarkNodes = xmlDoc.SelectNodes("rep/extInfoOfImageList/sizeCodeListWatermark/sizeCode");
            List<string> sizeCodeListWatermarkList = new List<string>();
            foreach (XmlNode n in sizeCodeListWatermarkNodes)
            {
                sizeCodeListWatermarkList.Add(n.InnerText.Trim());
            }
            repEntity.sizeCodeListWatermark = sizeCodeListWatermarkList;
            return repEntity;
        }

        public GetHotelTrafficInfoReturnEntity GetHotelTrafficInfo(GetHotelTrafficInfoCallEntity callEntity)
        {
            GetHotelTrafficInfoReturnEntity repEntity = new GetHotelTrafficInfoReturnEntity();
            StringBuilder reqBody = new StringBuilder();
            reqBody.AppendFormat("<hotelId>{0}</hotelId>",callEntity.HotelId);
            var rep = HotelInfoQuery(reqBody.ToString(), "GetHotelTrafficInfo");
            XmlDocument xmlDoc = rep.RepXmlContent;
            XmlNodeList trafficInfoNodes = xmlDoc.SelectNodes("rep/trafficInfoList/trafficInfo");
            List<TCTrafficInfo> trafficInfoList = new List<TCTrafficInfo>();
            foreach (XmlNode n in trafficInfoNodes)
            {
                trafficInfoList.Add(new TCTrafficInfo() {
                    arrivalWay = n.GetChildNodeInnerText("arrivalWay"),
                    distance = n.GetChildNodeInnerText("distance"),
                    locationName = n.GetChildNodeInnerText("locationName"),
                    startLocation = n.GetChildNodeInnerText("startLocation")
                });
            }
            repEntity.trafficInfoList = trafficInfoList;
            return repEntity;
        }

        public GetHotelRoomsMultiReturnEntity GetHotelRoomsMulti(GetHotelRoomsMultiCallEntity callEntity)
        {
            StringBuilder reqBody = new StringBuilder();
            reqBody.AppendFormat("<hotelId>{0}</hotelId>", callEntity.HotelIdList.Join(","));
            reqBody.AppendFormat("<comeDate>{0}</comeDate>",callEntity.comeDate.ToString("yyyy-MM-dd"));
            reqBody.AppendFormat("<leaveDate>{0}</leaveDate>", callEntity.leaveDate.ToString("yyyy-MM-dd"));

            var rep = HotelInfoQuery(reqBody.ToString(), "GetHotelRoomsMulti");
            return null;
        }

        public GetHotelBookingPolicyReturnEntity GetHotelBookingPolicy(GetHotelBookingPolicyCallEntity callEntity)
        {
            return null;
        }

        public GetProvinceListReturnEntity GetProvinceList()
        {
            GetProvinceListReturnEntity repEntity = new GetProvinceListReturnEntity();
            string apiUrl = "http://Tcopenapi.17usoft.com/static/xml/hotel/hotel-goe-cn.xml";
            var repXml = HttpCaller.PostDataToServer(apiUrl,"","GET");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(repXml);
            var provinceNodes = xmlDoc.SelectNodes("provincelist/province");
            List<ProvinceInfo> provinces = new List<ProvinceInfo>();
            List<CityInfo> cityinfos;
            List<RegionInfo> regionInfos;
            List<SectionInfo> sectionInfos;
            ProvinceInfo province;
            CityInfo cityinfo;
            RegionInfo regionInfo;
            SectionInfo sectionInfo;
            foreach (XmlNode p in provinceNodes)
            {
                province = new ProvinceInfo();
                province.ID = p.GetChildNodeInnerText("id").ToInt32();
                province.Name = p.GetChildNodeInnerText("name");
                province.Pinyin = p.GetChildNodeInnerText("pinyin");
                province.Index = p.GetChildNodeInnerText("index");

                var cityinfoNodes = p.SelectNodes("cityList/city");
                cityinfos = new List<CityInfo>();
                foreach (XmlNode cn in cityinfoNodes)
                {
                    cityinfo = new CityInfo();
                    cityinfo.ID = cn.GetChildNodeInnerText("id").ToInt32();
                    cityinfo.Name = cn.GetChildNodeInnerText("name");
                    cityinfo.Pinyin = cn.GetChildNodeInnerText("pinyin");
                    cityinfo.Index = cn.GetChildNodeInnerText("index");

                    regionInfos = new List<RegionInfo>();
                    var regionNodes = cn.SelectNodes("regionList/region");
                    foreach (XmlNode rn in regionNodes)
                    {
                        regionInfo = new RegionInfo();
                        regionInfo.ID = rn.GetChildNodeInnerText("id").ToInt32();
                        regionInfo.Name = rn.GetChildNodeInnerText("name");
                        regionInfo.Pinyin = rn.GetChildNodeInnerText("pinyin");
                        regionInfos.Add(regionInfo);
                    }
                    cityinfo.Regions = regionInfos;

                    sectionInfos = new List<SectionInfo>();
                    var sectionNodes = cn.SelectNodes("sectionList/section");
                    foreach (XmlNode sn in sectionNodes)
                    {
                        sectionInfo = new SectionInfo();
                        sectionInfo.ID = sn.GetChildNodeInnerText("id").ToInt32();
                        sectionInfo.Name = sn.GetChildNodeInnerText("name");
                        sectionInfos.Add(sectionInfo);
                    }

                    cityinfo.Sections = sectionInfos;
                    cityinfos.Add(cityinfo);
                }

                province.CityList = cityinfos;

                provinces.Add(province);
            }
            repEntity.Provinces = provinces;
            return repEntity;
        }

        public GetCommentListReturnEntity GetCommentList(int hotelId)
        {
            GetCommentListReturnEntity rep = new GetCommentListReturnEntity();
            StringBuilder reqXml = new StringBuilder();
            reqXml.AppendFormat("<hotelId>{0}</hotelId>",hotelId);
            var repContent = HotelCommentQuery(reqXml.ToString(), "GetCommentList");
            List<HotelCommentInfo> comments = new List<HotelCommentInfo>();
            HotelCommentInfo comment;
            var commentNodes = repContent.RepXmlContent.SelectNodes("rep/commentList/comment");
            foreach (XmlNode m in commentNodes)
            {
                comment = new HotelCommentInfo();
                comment.content = m.GetChildNodeInnerText("content");
                comment.createDate = m.GetChildNodeInnerText("createDate");
                comment.overallRating = m.GetChildNodeInnerText("overallRating").ToInt32();
                comments.Add(comment);
            }
            rep.Comments = comments;
            return rep;
        }
    }
}
