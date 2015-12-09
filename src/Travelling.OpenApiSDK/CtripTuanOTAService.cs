using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Travelling.CommonLibrary;
using Travelling.FrameWork;
using Travelling.OpenApiEntity.Ctrip.Tuan;

namespace Travelling.OpenApiSDK
{
    public class CtripTuanOTAService : CtripBaseApiCall
    {
        [Obsolete("旧接口废弃")]
        public GroupProductListReturnEntity GroupProductList(GroupProductListCallEntity callEntity)
        {
            GroupProductListReturnEntity returnEntity = new GroupProductListReturnEntity();
            StringBuilder reqXml = new StringBuilder();
            reqXml.Append("<GroupProductListRequest>");
            //reqXml.AppendFormat("<BeginDate>{0}</BeginDate>", callEntity.BeginDate.ToString("yyyy-MM-dd"));
            //reqXml.AppendFormat("<EndDate>{0}</EndDate>", callEntity.EndDate.ToString("yyyy-MM-dd"));
            reqXml.AppendFormat("<CityID>{0}</CityID>",callEntity.CityId);

            reqXml.AppendFormat("<Topcount>{0}</Topcount>", callEntity.PageSize);
            reqXml.Append("</GroupProductListRequest>");
            List<GroupProductListEntity> groupDataList = new List<GroupProductListEntity>();
            GroupProductListEntity product;
            callEntity.RequestContent = reqXml.ToString();
            var repXml = TuanApiCall(callEntity);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(repXml);
            var productNodes = xmlDoc.SelectNodes("Response/GroupProductListResponse/GroupDataList/GroupProductListEntity");
            foreach (XmlNode p in productNodes)
            {
                product = new GroupProductListEntity();
                product.Desc = p.GetChildNodeInnerText("Desc");
                product.Guarantee = p.GetChildNodeInnerText("Guarantee").ToInt32();
                product.HotelCount = p.GetChildNodeInnerText("HotelCount").ToInt32();
                product.LocationId = p.GetChildNodeInnerText("LocationId").ToInt32();
                product.OrderDayLimit = p.GetChildNodeInnerText("OrderDayLimit").ToInt32();
                product.OUrl = p.GetChildNodeInnerText("OUrl");
                product.ProductItemType = p.GetChildNodeInnerText("ProductItemType");
                product.Rule = p.GetChildNodeInnerText("Rule");
                product.Status = p.GetChildNodeInnerText("Status").ToInt32();
                product.BookingPhone = p.GetChildNodeInnerText("BookingPhone");
                product.Description = p.GetChildNodeInnerText("Description");
                product.DicDescription = p.GetChildNodeInnerText("DicDescription");
                product.EndDate = p.GetChildNodeInnerText("EndDate");
                product.ExpirationStartTime = p.GetChildNodeInnerText("ExpirationStartTime");
                product.HotelID = p.GetChildNodeInnerText("HotelID").ToInt32();
                product.IsComment = p.GetChildNodeInnerText("IsComment").ToInt32();
                product.IsFree = p.GetChildNodeInnerText("IsFree").ToInt32();
                product.IsGroup = p.GetChildNodeInnerText("IsGroup");
                product.IsRefund = p.GetChildNodeInnerText("IsRefund").ToInt32();
                product.ItemType = p.GetChildNodeInnerText("ItemType").ToInt32();
                product.LabelValue = p.GetChildNodeInnerText("LabelValue");
                product.LocationId = p.GetChildNodeInnerText("LocationId").ToInt32();
                product.Name = p.GetChildNodeInnerText("Name");
                product.NowPrice = p.GetChildNodeInnerText("NowPrice").ToInt32();
                product.Pictures = p.GetChildNodeInnerText("Pictures");
                product.Price = p.GetChildNodeInnerText("Price").ToInt32();
                product.ProductId = p.GetChildNodeInnerText("ProductId").ToInt32();
                product.ProductItemType = p.GetChildNodeInnerText("ProductItemType");
                product.ProductPrice = p.GetChildNodeInnerText("ProductPrice").ToInt32();
                product.Rate = p.GetChildNodeInnerText("ProductPrice").ToDecimal();
                product.Rule = p.GetChildNodeInnerText("Rule");
                product.SaledItemCount = p.GetChildNodeInnerText("SaledItemCount").ToInt32();
                product.SoldOut = p.GetChildNodeInnerText("SoldOut");
                product.StartDate = p.GetChildNodeInnerText("StartDate");
                product.Url = p.GetChildNodeInnerText("Url");
                product.VendorID = p.GetChildNodeInnerText("VendorID").ToInt32();

                ProductsMarket productMarket = new ProductsMarket();
                productMarket.DetailTipStyle = p.GetChildNode("ProductsMarket").GetChildNodeInnerText("DetailTipStyle").ToInt32();
                productMarket.EndDate = p.GetChildNode("ProductsMarket").GetChildNodeInnerText("DetailTipStyle");
                productMarket.ListTipStyle = p.GetChildNode("ProductsMarket").GetChildNodeInnerText("ListTipStyle").ToInt32();
                productMarket.ListTipStyleLeft = p.GetChildNode("ProductsMarket").GetChildNodeInnerText("ListTipStyleLeft").ToInt32();
                productMarket.MarketType = p.GetChildNode("ProductsMarket").GetChildNodeInnerText("MarketType");
                productMarket.MarketType2 = p.GetChildNode("ProductsMarket").GetChildNodeInnerText("MarketType2");
                productMarket.Price = p.GetChildNode("ProductsMarket").GetChildNodeInnerText("Price").ToInt32();
                productMarket.ProductId = p.GetChildNode("ProductsMarket").GetChildNodeInnerText("ProductId").ToInt32();
                productMarket.StartDate = p.GetChildNode("ProductsMarket").GetChildNodeInnerText("StartDate");

                product.ProductsMarket = productMarket;

                List<GroupProductHotelEntity> productHotels = new List<GroupProductHotelEntity>();

                
                var hotelNodes = p.SelectNodes("HotelList/GroupProductHotelEntity");
                foreach(XmlNode hn in hotelNodes)
                {
                    GroupProductHotelEntity hotel = new GroupProductHotelEntity();
                    hotel.Address = hn.GetChildNodeInnerText("Address");
                    hotel.City = hn.GetChildNodeInnerText("City");
                    hotel.CityId = hn.GetChildNodeInnerText("CityId").ToInt32();
                    hotel.CityPY = hn.GetChildNodeInnerText("CityPY");
                    hotel.CommentValue = hn.GetChildNodeInnerText("CommentValue").ToDecimal();
                    hotel.Contact = hn.GetChildNodeInnerText("Contact");
                    hotel.CtripId = hn.GetChildNodeInnerText("CtripId").ToInt32();
                    hotel.CtripStar = hn.GetChildNodeInnerText("CtripStar").ToInt32();
                    hotel.Description = hn.GetChildNodeInnerText("Description");
                    hotel.GLAT = hn.GetChildNodeInnerText("GLAT");
                    hotel.GLON = hn.GetChildNodeInnerText("GLON");
                    hotel.HotelGroupId = hn.GetChildNodeInnerText("HotelGroupId");
                    hotel.Id = hn.GetChildNodeInnerText("Id").ToInt32();
                    hotel.IsContain = hn.GetChildNodeInnerText("IsContain");
                    hotel.IsStarRate = hn.GetChildNodeInnerText("IsStarRate").ToInt32();
                    hotel.ItemName = hn.GetChildNodeInnerText("ItemName");
                    hotel.ItemType = hn.GetChildNodeInnerText("ItemType").ToInt32();
                    hotel.LAT = hn.GetChildNodeInnerText("LAT");
                    hotel.LocationId = hn.GetChildNodeInnerText("LocationId").ToInt32();
                    hotel.LocationName = hn.GetChildNodeInnerText("LocationName");
                    hotel.LON = hn.GetChildNodeInnerText("LON");
                    hotel.Name = hn.GetChildNodeInnerText("Name");
                    hotel.ProvinceName = hn.GetChildNodeInnerText("ProvinceName");
                    hotel.StarRate = hn.GetChildNodeInnerText("StarRate").ToInt32();
                    hotel.Tel = hn.GetChildNodeInnerText("Tel");
                    hotel.VendorID = hn.GetChildNodeInnerText("VendorID").ToInt32();
                    //hotel.Zone = hn.GetChildNodeInnerText("Zone");
                    //hotel.ZoneId = hn.GetChildNodeInnerText("ZoneId").ToInt32();
                    productHotels.Add(hotel);
                }
                product.productHotels = productHotels;
                groupDataList.Add(product);

            }
            returnEntity.GroupDataList = groupDataList;
            return returnEntity;
        }

        public Product_GetReturnEntity Product_Get(Product_GetCallEntity callEntity)
        {
            Product_GetReturnEntity repEntity = new Product_GetReturnEntity();
            StringBuilder reqBody = new StringBuilder();
            reqBody.Append("<SearchProductRQ>");
            reqBody.Append("<SearchCondition>");
            reqBody.Append("<CityInfo>");
            reqBody.AppendFormat("<CityID>{0}</CityID>", callEntity.CityID);
            
            reqBody.Append("</CityInfo>");
            reqBody.Append("<ItemTypeList>");
            reqBody.AppendFormat("<ItemType>{0}</ItemType>",callEntity.ItemType);
            reqBody.Append("</ItemTypeList>");
            reqBody.Append("</SearchCondition>");
            reqBody.Append("<DisplaySettings>");
            reqBody.Append("<PageSettings>");
            reqBody.AppendFormat("<PageSize>{0}</PageSize>",callEntity.PageSize);
            reqBody.AppendFormat("<CurrentPageIndex>{0}</CurrentPageIndex>", callEntity.CurrentPageIndex);
            reqBody.Append("</PageSettings>");
            reqBody.Append("</DisplaySettings>");
            reqBody.Append("</SearchProductRQ>");

            callEntity.RequestContent = reqBody.ToString();
            var rep = TuanApiCall(callEntity);
            

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(rep);
            GetHeaderResult(xmlDoc, repEntity);
            List<GroupProductInfo> productInfoList = new List<GroupProductInfo>();
            GroupProductInfo product;

            var productNodes = xmlDoc.SelectNodes("Response/SearchProductRS/GroupProductInfoList/GroupProductInfo");
            foreach(XmlNode p in productNodes)
            {
                product = new GroupProductInfo();
                product.AllowInvoice = p.ToXmlElement().GetAttribute("AllowInvoice").ToInt32();
                product.ProductID = p.ToXmlElement().GetAttribute("ProductID").ToInt32();
                product.Quantity = p.ToXmlElement().GetAttribute("Quantity").ToInt32();
                product.IsRobItem = p.ToXmlElement().GetAttribute("IsRobItem");
                product.SortIndex = p.ToXmlElement().GetAttribute("SortIndex").ToInt32();
                product.ProductStatus = p.ToXmlElement().GetAttribute("ProductStatus").ToInt32();
                product.SoldOut = p.ToXmlElement().GetAttribute("SoldOut");
                product.ProductItemType = p.ToXmlElement().GetAttribute("ProductItemType").ToInt32();
                product.ProductURL = p.ToXmlElement().GetAttribute("ProductURL");
                product.HotelName = p.ToXmlElement().GetAttribute("HotelName");
                product.CtripID = p.ToXmlElement().GetAttribute("CtripID").ToInt32();
                product.SalePrice = p.GetChildNode("ProductPrice").GetChildNode("SalePrice").ToXmlElement().GetAttribute("Price").ToInt32();
                product.ShowPrice = p.GetChildNode("ProductPrice").GetChildNode("ShowPrice").ToXmlElement().GetAttribute("Price").ToInt32();
                product.ListingPrice = p.GetChildNode("ProductPrice").GetChildNode("ListingPrice").ToXmlElement().GetAttribute("Price").ToInt32();
                product.NowPrice = p.GetChildNode("ProductPrice").GetChildNode("ListingPrice").ToXmlElement().GetAttribute("NowPrice").ToInt32();
                product.StartDate = p.GetChildNode("SaleDateRange").GetChildNodeInnerText("StartDate");
                product.EndDate = p.GetChildNode("SaleDateRange").GetChildNodeInnerText("EndDate");
                product.DisplayEndDate = p.GetChildNode("SaleDateRange").GetChildNodeInnerText("DisplayEndDate");

                TicketEffectiveRange ticketEffectiveRange = new TicketEffectiveRange();
                ticketEffectiveRange.StartDate = p.GetChildNode("TicketEffectiveRange").GetChildNodeInnerText("StartDate");
                ticketEffectiveRange.EndDate = p.GetChildNode("TicketEffectiveRange").GetChildNodeInnerText("EndDate");
                product.TicketEffectiveRange = ticketEffectiveRange;

                List<GroupProductDescription> descriptions = new List<GroupProductDescription>();
                GroupProductDescription productDescription;
                var descriptionNodes = p.SelectNodes("Descriptions/Description");
                foreach (XmlNode d in descriptionNodes)
                {
                    productDescription = new GroupProductDescription();
                    productDescription.Category = d.ToXmlElement().GetAttribute("Category").ToInt32();
                    productDescription.Title = d.ToXmlElement().GetAttribute("Title");
                    productDescription.Text = d.GetChildNode("Content").GetChildNodeInnerText("Text");
                    descriptions.Add(productDescription);
                }
                product.ProductDescriptions = descriptions;

                product.SaledItemCount = p.GetChildNode("SalesStatistics").GetChildNodeInnerText("SaledItemCount").ToInt32();
                product.PaymentItemCount = p.GetChildNode("SalesStatistics").GetChildNodeInnerText("PaymentItemCount").ToInt32();
                product.CompletedItemCount = p.GetChildNode("SalesStatistics").GetChildNodeInnerText("CompletedItemCount").ToInt32();

                ProductScores productScore = new ProductScores();
                if (p.GetChildNode("ProductScores") != null)
                {
                    productScore.CommentScore = p.GetChildNode("ProductScores").GetChildNodeInnerText("CommentScore").ToDecimal();
                    productScore.CtripStar = p.GetChildNode("ProductScores").ToXmlElement().GetAttribute("CtripStar").ToInt32();
                    productScore.IsStarRate = p.GetChildNode("ProductScores").ToXmlElement().GetAttribute("IsStarRate");
                    productScore.StarRate = p.GetChildNode("ProductScores").ToXmlElement().GetAttribute("StarRate").ToInt32();
                    
                }
                product.ProductScores = productScore;
                

                List<VendorInfo> vendorInfos = new List<VendorInfo>();
                VendorInfo vendorInfo;
                var vendorInfoNodes = p.SelectNodes("VendorInfos/VendorInfoType");
                foreach (XmlNode vn in vendorInfoNodes)
                {
                    vendorInfo = new VendorInfo();
                    vendorInfo.City = vn.ToXmlElement().GetAttribute("City");
                    vendorInfo.PayType = vn.ToXmlElement().GetAttribute("PayType").ToInt32();
                    vendorInfo.VendorType = vn.ToXmlElement().GetAttribute("VendorType").ToInt32();
                    vendorInfo.SendTicketsType = vn.ToXmlElement().GetAttribute("SendTicketsType").ToInt32();
                    vendorInfo.VendorId = vn.GetChildNodeInnerText("VendorId").ToInt32();
                    vendorInfo.VendorName = vn.GetChildNodeInnerText("VendorName");
                    vendorInfo.Tel = vn.GetChildNodeInnerText("Tel");
                    vendorInfos.Add(vendorInfo);
                }
                product.VendorInfos = vendorInfos;

                List<GuaranteeInfo> guaranteeInfos = new List<GuaranteeInfo>();
                GuaranteeInfo guaranteeInfo;
                var guaranteeInfoNodes = p.SelectNodes("ProductGuarantee/GuaranteeInfo");
                if (guaranteeInfoNodes != null && guaranteeInfoNodes.Count>0)
                {
                    foreach (XmlNode gn in guaranteeInfoNodes)
                    {
                        guaranteeInfo = new GuaranteeInfo();
                        guaranteeInfo.GuaranteeDesc = gn.ToXmlElement().GetAttribute("GuaranteeDesc");
                        guaranteeInfo.GuaranteeID = gn.ToXmlElement().GetAttribute("GuaranteeID").ToInt32();
                        guaranteeInfos.Add(guaranteeInfo);
                    }
                    product.GuaranteeInfos = guaranteeInfos;
                }

                List<GroupProductPicture> productPictures = new List<GroupProductPicture>();
                GroupProductPicture productPicture;

                var productPictureNodes = p.SelectNodes("ProductPictures/ProductPicture");
                foreach (XmlNode pn in productPictureNodes)
                {
                    productPicture = new GroupProductPicture();
                    productPicture.Category = pn.ToXmlElement().GetAttribute("Category").ToInt32();
                    productPicture.Title = pn.ToXmlElement().GetAttribute("Title");

                    List<GroupProductPictureContent> contents = new List<GroupProductPictureContent>();
                    GroupProductPictureContent picutureContent;
                    var pictureContentNodes = pn.SelectNodes("Content");
                    foreach (XmlNode cn in pictureContentNodes)
                    {
                        picutureContent = new GroupProductPictureContent();
                        picutureContent.Description = cn.GetChildNodeInnerText("Description");
                        picutureContent.URL = cn.GetChildNodeInnerText("URL");
                        picutureContent.Title = cn.ToXmlElement().GetAttribute("Title");
                        picutureContent.Position = cn.ToXmlElement().GetAttribute("Position");
                        contents.Add(picutureContent);
                    }
                    productPicture.contents = contents;
                    productPictures.Add(productPicture);
                }

                product.ProductPictures = productPictures;
                productInfoList.Add(product);
            }
            repEntity.GroupProductInfoList = productInfoList;
            return repEntity;
        }

        public Product_DetailReturnEntity Product_Detail(Product_DetailCallEntity callEntity)
        {
            Product_DetailReturnEntity repEntity = new Product_DetailReturnEntity();
            StringBuilder reqBody = new StringBuilder();
            reqBody.Append("<ProductDetailRQ>");
            reqBody.Append("<SearchCondition IsShowRoomStatus=\"true\" IsShowHotel=\"true\">");
            reqBody.Append("<ProductIDList>");
            callEntity.Products.ForEach(u => {
                reqBody.AppendFormat("<ProductID>{0}</ProductID>",u);
            });
            reqBody.Append("</ProductIDList>");
            reqBody.Append("</SearchCondition>");
            reqBody.Append("</ProductDetailRQ>");

            callEntity.RequestContent = reqBody.ToString();
            var rep = TuanApiCall(callEntity);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(rep);

            var productDetailInfoNodes = xmlDoc.SelectNodes("Response/ProductDetailRS/ProductDetailInfoList/ProductDetailInfo");
            List<ProductDetailInfo> productDetailInfos = new List<ProductDetailInfo>();
            ProductDetailInfo productDetailInfo;
            foreach (XmlNode n in productDetailInfoNodes)
            {
                productDetailInfo = new ProductDetailInfo();
                productDetailInfo.AllowInvoice = n.ToXmlElement().GetAttribute("AllowInvoice").ToInt32();
                productDetailInfo.Creator = n.ToXmlElement().GetAttribute("Creator");
                productDetailInfo.IsSupportAppoint = n.ToXmlElement().GetAttribute("IsSupportAppoint");
                productDetailInfo.IsShowCalendar = n.ToXmlElement().GetAttribute("IsShowCalendar");
                productDetailInfo.ProductURL = n.ToXmlElement().GetAttribute("ProductURL");
                productDetailInfo.NoteUrl = n.ToXmlElement().GetAttribute("NoteUrl");
                productDetailInfo.NotApplicableDate = n.ToXmlElement().GetAttribute("NotApplicableDate");
                productDetailInfo.IsDirect = n.ToXmlElement().GetAttribute("IsDirect");
                productDetailInfo.ProductName = n.ToXmlElement().GetAttribute("ProductName");
                productDetailInfo.ProductItemType = n.ToXmlElement().GetAttribute("ProductItemType").ToInt32();
                productDetailInfo.Quantity = n.ToXmlElement().GetAttribute("Quantity").ToInt32();
                productDetailInfo.IsRobItem = n.ToXmlElement().GetAttribute("IsRobItem");
                productDetailInfo.ProductID = n.ToXmlElement().GetAttribute("ProductID").ToInt32();
                productDetailInfo.Name = n.ToXmlElement().GetAttribute("Name");
                productDetailInfo.SoldOut = n.ToXmlElement().GetAttribute("SoldOut");
                productDetailInfo.AllowInvoice = n.ToXmlElement().GetAttribute("AllowInvoice").ToInt32();
                productDetailInfo.SortIndex = n.ToXmlElement().GetAttribute("SortIndex").ToInt32();
                productDetailInfo.ProductStatus = n.ToXmlElement().GetAttribute("ProductStatus").ToInt32();
                productDetailInfo.SalePrice = n.GetChildNode("ProductPrice").GetChildNode("SalePrice").ToXmlElement().GetAttribute("Price").ToInt32();
                productDetailInfo.ShowPrice = n.GetChildNode("ProductPrice").GetChildNode("ShowPrice").ToXmlElement().GetAttribute("Price").ToInt32();
                productDetailInfo.ListingPrice = n.GetChildNode("ProductPrice").GetChildNode("ListingPrice").ToXmlElement().GetAttribute("Price").ToInt32();
                productDetailInfo.NowPrice = n.GetChildNode("ProductPrice").GetChildNode("NowPrice").ToXmlElement().GetAttribute("Price").ToInt32();

                productDetailInfo.StartDate = n.GetChildNode("SaleDateRange").GetChildNodeInnerText("StartDate");
                productDetailInfo.EndDate = n.GetChildNode("SaleDateRange").GetChildNodeInnerText("EndDate");
                productDetailInfo.DisplayEndDate = n.GetChildNode("SaleDateRange").GetChildNodeInnerText("DisplayEndDate");

                productDetailInfo.BookingPhone = n.GetChildNode("BookingPhones").GetChildNode("BookingPhone").ToXmlElement().GetAttribute("PhoneNumber");
                productDetailInfo.BookingPhoneDescription = n.GetChildNode("BookingPhones").GetChildNode("BookingPhone").GetChildNodeInnerText("Description");

                List<GroupProductDescription> descriptions = new List<GroupProductDescription>();
                GroupProductDescription productDescription;
                var descriptionNodes = n.SelectNodes("Descriptions/Description");
                foreach(XmlNode d in descriptionNodes)
                {
                    productDescription = new GroupProductDescription();
                    productDescription.Category = d.ToXmlElement().GetAttribute("Category").ToInt32();
                    productDescription.Title = d.ToXmlElement().GetAttribute("Title");
                    productDescription.Text = d.GetChildNode("Content").GetChildNodeInnerText("Text");
                    descriptions.Add(productDescription);
                }
                productDetailInfo.ProductDescriptions = descriptions;

                List<GroupProductPicture> productPictures = new List<GroupProductPicture>();
                GroupProductPicture productPicture;

                var productPictureNodes = n.SelectNodes("ProductPictures/ProductPicture");
                foreach(XmlNode pn in productPictureNodes)
                {
                    productPicture = new GroupProductPicture();
                    productPicture.Category = pn.ToXmlElement().GetAttribute("Category").ToInt32();
                    productPicture.Title = pn.ToXmlElement().GetAttribute("Title");

                    List<GroupProductPictureContent> contents = new List<GroupProductPictureContent>();
                    GroupProductPictureContent picutureContent;
                    var pictureContentNodes = pn.SelectNodes("Content");
                    foreach(XmlNode cn in pictureContentNodes)
                    {
                        picutureContent = new GroupProductPictureContent();
                        picutureContent.Description = cn.GetChildNodeInnerText("Description");
                        picutureContent.URL = cn.GetChildNodeInnerText("URL");
                        picutureContent.Title = cn.ToXmlElement().GetAttribute("Title");
                        picutureContent.Position = cn.ToXmlElement().GetAttribute("Position");
                        contents.Add(picutureContent);
                    }
                    productPicture.contents = contents;
                    productPictures.Add(productPicture);
                }

                productDetailInfo.ProductPictures = productPictures;

                GroupProductRule productRule = new GroupProductRule();
                productRule.RuleDescription = n.GetChildNode("ProductRule").GetChildNodeInnerText("RuleDescription");
                productRule.DayLimit = n.GetChildNode("ProductRule").GetChildNodeInnerText("DayLimit").ToInt32();
                productRule.InvoiceText = n.GetChildNode("ProductRule").GetChildNodeInnerText("InvoiceText");
                productRule.MinSale = n.GetChildNode("ProductRule").GetChildNode("QuantityRule").GetChildNodeInnerText("MinSale").ToInt32();
                productRule.MinSaleUnit = n.GetChildNode("ProductRule").GetChildNode("QuantityRule").GetChildNodeInnerText("MinSaleUnit").ToInt32();
                productRule.MaxSaleUnit = n.GetChildNode("ProductRule").GetChildNode("QuantityRule").GetChildNodeInnerText("MaxSaleUnit").ToInt32();
                productRule.MaxSale = n.GetChildNode("ProductRule").GetChildNode("QuantityRule").GetChildNodeInnerText("MaxSale").ToInt32();
                
                productDetailInfo.ProductRule = productRule;

                productDetailInfo.SaledItemCount = n.GetChildNode("SalesStatistics").GetChildNodeInnerText("SaledItemCount").ToInt32();
                productDetailInfo.PaymentItemCount = n.GetChildNode("SalesStatistics").GetChildNodeInnerText("PaymentItemCount").ToInt32();
                productDetailInfo.CompletedItemCount = n.GetChildNode("SalesStatistics").GetChildNodeInnerText("CompletedItemCount").ToInt32();

                TicketEffectiveRange ticketEffectiveRange = new TicketEffectiveRange();
                ticketEffectiveRange.StartDate = n.GetChildNode("TicketEffectiveRange").GetChildNodeInnerText("StartDate");
                ticketEffectiveRange.EndDate = n.GetChildNode("TicketEffectiveRange").GetChildNodeInnerText("EndDate");
                productDetailInfo.TicketEffectiveRange = ticketEffectiveRange;

                List<GroupHotelInfo> hotelinfos = new List<GroupHotelInfo>();
                GroupHotelInfo hotelinfo;
                var hotelInfoNodes = n.SelectNodes("ProductItem/HotelItemList/HotelInfo");
                foreach (XmlNode hn in hotelInfoNodes)
                {
                    hotelinfo = new GroupHotelInfo();
                    hotelinfo.Name = hn.ToXmlElement().GetAttribute("Name");
                    hotelinfo.ID = hn.ToXmlElement().GetAttribute("ID").ToInt32();
                    hotelinfo.StarRate = hn.ToXmlElement().GetAttribute("StarRate").ToInt32();
                    hotelinfo.IsStarRate = hn.ToXmlElement().GetAttribute("IsStarRate");
                    hotelinfo.CtripStar = hn.ToXmlElement().GetAttribute("CtripStar").ToInt32();
                    hotelinfo.CommentValue = hn.ToXmlElement().GetAttribute("CommentValue").ToDecimal();
                    hotelinfo.HotelID = hn.ToXmlElement().GetAttribute("HotelID").ToInt32();
                    hotelinfo.ProvinceID = hn.GetChildNode("Province").ToXmlElement().GetAttribute("ProvinceID").ToInt32();
                    hotelinfo.ProvinceName = hn.GetChildNode("Province").ToXmlElement().GetAttribute("ProvinceName");
                    hotelinfo.CityID = hn.GetChildNode("City").ToXmlElement().GetAttribute("CityID").ToInt32();
                    hotelinfo.CityName = hn.GetChildNode("City").ToXmlElement().GetAttribute("CityName");
                    hotelinfo.Pinyin = hn.GetChildNode("City").ToXmlElement().GetAttribute("Pinyin");
                    hotelinfo.LocationID = hn.GetChildNode("Location").ToXmlElement().GetAttribute("LocationID").ToInt32();
                    hotelinfo.LocationName = hn.GetChildNode("Location").ToXmlElement().GetAttribute("LocationName");
                    hotelinfo.ZoneID = hn.GetChildNode("Zone").ToXmlElement().GetAttribute("ZoneID").ToInt32();
                    hotelinfo.ZoneName = hn.GetChildNode("Zone").ToXmlElement().GetAttribute("ZoneName");
                    hotelinfo.Address = hn.GetChildNode("AddressInfo").ToXmlElement().GetAttribute("Address");

                    ContactInfo contact = new ContactInfo();
                    contact.Contact = hn.GetChildNode("ContactInfo").GetChildNodeInnerText("Contact");
                    contact.Phone = hn.GetChildNode("ContactInfo").GetChildNodeInnerText("Phone");
                    hotelinfo.Contact = contact;

                    List<PositionInfo> postions = new List<PositionInfo>();
                    PositionInfo positionInfo;
                    var positionInfoNodes = hn.SelectNodes("PositionList/PositionInfo");
                    foreach (XmlNode pn in positionInfoNodes)
                    {
                        positionInfo = new PositionInfo();
                        positionInfo.Type = pn.ToXmlElement().GetAttribute("Type").ToInt32();
                        positionInfo.LAT = pn.GetChildNodeInnerText("LAT");
                        positionInfo.LON = pn.GetChildNodeInnerText("LON");
                        postions.Add(positionInfo);
                    }

                    hotelinfo.Postions = postions;


                    List<RoomInfo> roominfos = new List<RoomInfo>();
                    RoomInfo roominfo;
                    XmlNodeList roominfoNodes = hn.SelectNodes("RoomInfos/RoomInfo");
                    foreach (XmlNode rn in roominfoNodes)
                    {
                        roominfo = new RoomInfo();
                        roominfo.RoomID = rn.ToXmlElement().GetAttribute("RoomID").ToInt32();

                        List<RoomStatusItem> roomstatusItems = new List<RoomStatusItem>();
                        RoomStatusItem roomStatusItem;
                        var roomstatusItemNodes = rn.SelectNodes("RoomStatus/RoomStatusItem");
                        foreach (XmlNode sn in roomstatusItemNodes)
                        {
                            roomStatusItem = new RoomStatusItem();
                            roomStatusItem.BookingDate = sn.ToXmlElement().GetAttribute("BookingDate");
                            roomStatusItem.Status = sn.ToXmlElement().GetAttribute("Status").ToInt32();
                            roomstatusItems.Add(roomStatusItem);
                        }
                        roominfo.roomstatusItems = roomstatusItems;
                        roominfos.Add(roominfo);
                    }

                    hotelinfo.RoomInfos = roominfos;
                    hotelinfos.Add(hotelinfo);
                }

                productDetailInfo.hotelinfos = hotelinfos;

                List<GuaranteeInfo> guaranteeInfos = new List<GuaranteeInfo>();
                GuaranteeInfo guaranteeInfo;
                var guaranteeInfoNodes = n.SelectNodes("ProductGuarantee/GuaranteeInfo");
                foreach (XmlNode gn in guaranteeInfoNodes)
                {
                    guaranteeInfo = new GuaranteeInfo();
                    guaranteeInfo.GuaranteeDesc = gn.ToXmlElement().GetAttribute("GuaranteeDesc");
                    guaranteeInfo.GuaranteeID = gn.ToXmlElement().GetAttribute("GuaranteeID").ToInt32();
                    guaranteeInfos.Add(guaranteeInfo);
                }
                productDetailInfo.GuaranteeInfos = guaranteeInfos;

                CategoryInfo categoryInfo = new CategoryInfo();
                categoryInfo.ID = n.SelectSingleNode("CategoryInfo").ToXmlElement().GetAttribute("ID").ToInt32();
                categoryInfo.Name = n.SelectSingleNode("CategoryInfo").ToXmlElement().GetAttribute("Name");

                var CategoryAttrNodes = n.SelectNodes("CategoryInfo/CategoryAttr");
                List<CategoryAttr> CategoryAttrs = new List<CategoryAttr>();
                CategoryAttr categoryAttr;
                foreach (XmlNode cn in CategoryAttrNodes)
                {
                    categoryAttr = new CategoryAttr();
                    categoryAttr.CategoryID = cn.ToXmlElement().GetAttribute("CategoryID").ToInt32();
                    categoryAttr.ID = cn.ToXmlElement().GetAttribute("ID").ToInt32();
                    categoryAttr.Name = cn.ToXmlElement().GetAttribute("Name");
                    CategoryAttrs.Add(categoryAttr);
                }
                categoryInfo.CategoryAttrs = CategoryAttrs;
                productDetailInfo.CategoryInfo = categoryInfo;

                //VendorInfo VendorInfo = new VendorInfo();
                List<VendorInfo> vendorInfos = new List<VendorInfo>();
                VendorInfo vendorInfo;
                var vendorInfoNodes = n.SelectNodes("VendorInfos/VendorInfoType");
                foreach (XmlNode vn in vendorInfoNodes)
                {
                    vendorInfo = new VendorInfo();
                    vendorInfo.City = vn.ToXmlElement().GetAttribute("City");
                    vendorInfo.PayType = vn.ToXmlElement().GetAttribute("PayType").ToInt32();
                    vendorInfo.VendorType = vn.ToXmlElement().GetAttribute("VendorType").ToInt32();
                    vendorInfo.SendTicketsType = vn.ToXmlElement().GetAttribute("SendTicketsType").ToInt32();
                    vendorInfo.VendorId = vn.GetChildNodeInnerText("VendorId").ToInt32();
                    vendorInfo.VendorName = vn.GetChildNodeInnerText("VendorName");
                    vendorInfo.Tel = vn.GetChildNodeInnerText("Tel");
                    vendorInfos.Add(vendorInfo);
                }
                productDetailInfo.VendorInfos = vendorInfos; 
                productDetailInfos.Add(productDetailInfo);
            }
            repEntity.ProductDetailInfos = productDetailInfos;
            return repEntity;
        }

        public GroupProductChangeReturnEntity GroupProductChange(GroupProductChangeCallEntity callEntity)
        {
            StringBuilder reqBody = new StringBuilder();
            reqBody.Append("<GroupProductChangeRequest>");
            reqBody.AppendFormat("<ChangeTime>{0}</ChangeTime>",callEntity.ChangeTime.ToCtripDateFormat());

            reqBody.Append("</GroupProductChangeRequest>");
            callEntity.RequestContent = reqBody.ToString();
            var repXml = TuanApiCall(callEntity);
            return null;
        }
    }
}
