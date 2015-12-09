using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using Travelling.FrameWork;
using Travelling.OpenApiEntity.Ctrip.Hotel.Module;
using Travelling.ViewModel.Travel;
using System.Configuration;
using Travelling.ViewModel.Dto.Zhuna;

namespace Travelling.Web.Helpers
{
    /// <summary>
    /// 酒店协助类
    /// </summary>
    public class HotelInfoHelper
    {
        public static List<HotelPrimaryInfo> GetHotelInfosByCityID(List<HotelPrimaryInfo> source, int cityID)
        {
            var items = (from it in source
                         where it.HotelCityCode == cityID
                         select it).ToList();
            return items;
        }

        /// <summary>
        /// 获取酒店房型早餐说明
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetBreakfastTypeName(int type)
        {
            string typeName = "";
            if (type == 0)
            {
                typeName = "无早";
            }
            else if (type == 1)
            {
                typeName = "单早";
            }
            else if (type == 2)
            {
                typeName = "双早";
            }
            return typeName;
        }

        public static List<Facility> RoomServices(string source)
        {
            List<Facility> items;
            items = JsonConvert.DeserializeObject<List<Facility>>(source);
            return items;
        }

        public static List<MultimediaTextDescription> GetHotelTextDescription(string source)
        {
            List<MultimediaTextDescription> textDescriptions;
            textDescriptions = JsonConvert.DeserializeObject<List<MultimediaTextDescription>>(source);
            return textDescriptions;
        }

        public static string GetHotelDescription(string textSource)
        {
            var textDescriptions = GetHotelTextDescription(textSource);
            var hotelDescInfo = textDescriptions.Where(u => { return u.Category == 5; }).SingleOrDefault();
            var hotelAddressInfo = textDescriptions.Where(u => { return u.Category == 8; }).SingleOrDefault();

            StringBuilder build = new StringBuilder();
            build.Append("<div id=\"htlDes\" class=\"htl_room_txt text_3l\">");
            build.Append("<p>");
            if (hotelDescInfo != null)
            {
                build.AppendFormat("<span itemprop=\"description\">{0}</span>", hotelDescInfo.Text);
            }
            if (hotelAddressInfo != null)
            {
                build.AppendFormat("<span itemprop=\"description\">{0}</span>", hotelAddressInfo.Text);
            }

            build.Append("</p>");
            build.Append("</div>");
            return build.ToString();
        }

        public static string GetRedirectUrl(string textSource)
        {
            var textDescriptions = GetHotelTextDescription(textSource);
            var urlDesc = textDescriptions.Where(u => { return u.Category == 501; }).SingleOrDefault();
            if (urlDesc != null)
            {
                return urlDesc.Text.Replace("&amp;", "&");
            }
            return "";
        }

        public static string HasBoardBand(string source)
        {
            var services = RoomServices(source);
            var free = services.Where(u => { return u.Code == 3; }).SingleOrDefault();
            if (free != null)
            {
                return "有线免费 ";
            }
            return "";
        }

        /// <summary>
        /// 创建酒店查询链接
        /// </summary>
        /// <param name="hotelQuery"></param>
        /// <param name="locationId"></param>
        /// <param name="areaid"></param>
        /// <param name="hotelStar"></param>
        /// <param name="hotelBrand"></param>
        /// <param name="hotelPrice"></param>
        /// <param name="key"></param>
        /// <param name="page"></param>
        /// <param name="isStarUnselected"></param>
        /// <param name="isHotelBrandSelect"></param>
        /// <returns></returns>
        public static string GetHotelQueryHref(HotelInfoQuery hotelQuery, int locationId = 0, int areaid = 0, string hotelStar = "0-5", string hotelBrand = "0", string hotelPrice = "0-9999", string key = "", int page = 1, bool isStarUnselected = false, bool isHotelBrandSelect = false)
        {
            StringBuilder href = new StringBuilder("/hotelsearch_");

            //if (hotelStar != "0-5")
            //{
            //    List<string> starlist = hotelQuery.HotelStar.Split('f').ToList();
            //    if (!starlist.Contains(hotelStar))
            //    {
            //        starlist.Add(hotelStar);
            //        starlist.Remove("0-5");
            //        hotelStar = starlist.Join("f");
            //    }
            //}

            

            //if(hotelBrand!="0")
            //{
            //    List<string> brandlist = hotelQuery.HotelBrandID.Split('f').ToList();
            //    if(!brandlist.Contains(hotelBrand))
            //    {
            //        brandlist.Add(hotelBrand);
            //        brandlist.Remove("0");
            //        hotelBrand = brandlist.Join("f");
            //    }
            //}

            href.AppendFormat("{0}_", hotelQuery.CityId);
            href.AppendFormat("{0}_", areaid);
            href.AppendFormat("{0}_", locationId);
            href.AppendFormat("{0}_", hotelBrand);
            href.AppendFormat("{0}_", hotelQuery.StartDate.ToString("yyyy-MM-dd"));
            href.AppendFormat("{0}_", hotelQuery.EndDate.ToString("yyyy-MM-dd"));
            href.AppendFormat("{0}_", hotelStar);
            href.AppendFormat("{0}_", hotelPrice);
            href.AppendFormat("{0}_", hotelQuery.PageIndex);
            href.AppendFormat("{0}_", hotelQuery.OrderType);
            href.AppendFormat("{0}", string.IsNullOrEmpty(key)?"search":key);
            href.Append(".html");
            return href.ToString();
        }

        /// <summary>
        /// 获取查询链接
        /// </summary>
        /// <param name="hotelQuery"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public static string GetHotelQueryLink(HotelInfoQuery hotelQuery, int orderType, int type = 0)
        {

            HotelInfoQuery query = new HotelInfoQuery()
            {
                AreaId = hotelQuery.AreaId,
                OrderType = hotelQuery.OrderType,
                CityId = hotelQuery.CityId,
                EndDate = hotelQuery.EndDate,
                HotelBrandID = hotelQuery.HotelBrandID,
                HotelPrice = hotelQuery.HotelPrice,
                HotelStar = hotelQuery.HotelStar,
                KeyWords = hotelQuery.KeyWords,
                LocationID = hotelQuery.LocationID,
                MaxPrice = hotelQuery.MaxPrice,
                MaxStar = hotelQuery.MaxStar,
                MinPrice = hotelQuery.MinPrice,
                MinStar = hotelQuery.MinStar,
                PageIndex = hotelQuery.PageIndex,
                PageSize = hotelQuery.PageSize,
                StartDate = hotelQuery.StartDate,
                TotalRecords = hotelQuery.TotalRecords
            };


            if (type == 1)
            {
                if (query.OrderType == 0)
                {
                    query.OrderType = (int)HotelQueryOrderType.PriceAsc;
                }
                else if (orderType == (int)HotelQueryOrderType.PriceAsc)
                {
                    query.OrderType = (int)HotelQueryOrderType.PriceDesc;
                }
                else if (orderType == (int)HotelQueryOrderType.PriceDesc)
                {
                    query.OrderType = (int)HotelQueryOrderType.PriceAsc;
                }
                else
                {
                    query.OrderType = (int)HotelQueryOrderType.PriceAsc;
                }
            }

            if (type == 2)
            {
                if (query.OrderType == 0)
                {
                    query.OrderType = (int)HotelQueryOrderType.UserRateDesc;
                }
                else if (orderType == (int)HotelQueryOrderType.UserRateAsc)
                {
                    query.OrderType = (int)HotelQueryOrderType.UserRateDesc;
                }
                else if (orderType == (int)HotelQueryOrderType.UserRateDesc)
                {
                    query.OrderType = (int)HotelQueryOrderType.UserRateAsc;
                }
                else
                {
                    query.OrderType = (int)HotelQueryOrderType.UserRateDesc;
                }
            }
            if (type == 3)
            {
                if (orderType == (int)HotelQueryOrderType.StarDesc)
                {
                    query.OrderType = (int)HotelQueryOrderType.StarAsc;
                }
                else if (orderType == (int)HotelQueryOrderType.StarAsc)
                {
                    query.OrderType = (int)HotelQueryOrderType.StarDesc;
                }
                else
                {
                    query.OrderType = (int)HotelQueryOrderType.StarDesc;
                }
            }

            return GetHotelQueryLink(query);
        }

        public static string GetHotelQueryHrefForHotelBrand(HotelInfoQuery hotelQuery, int hotelBrand)
        {
            string hotelbrands = hotelQuery.HotelBrandID;
            
            if (hotelBrand > 0)
            {
                List<string> brandlist = hotelQuery.HotelBrandID.Split('f').ToList();
                if (!brandlist.Contains(hotelBrand.ToString()))
                {
                    brandlist.Add(hotelBrand.ToString());
                    brandlist.Remove("0");
                    hotelbrands = brandlist.Join("f");
                }
            }
            else if (hotelBrand < 0)
            {
                List<string> brandlist = hotelQuery.HotelBrandID.Split('f').ToList();
                if (brandlist.Contains(Math.Abs(hotelBrand).ToString()))
                {
                    brandlist.Remove(Math.Abs(hotelBrand).ToString());
                    brandlist.Remove("0");
                    hotelbrands = brandlist.Join("f");
                }
            }
            else
            {
                hotelbrands = "0";
            }
            if(string.IsNullOrEmpty(hotelbrands))
            {
                hotelbrands = "0";
            }
            HotelInfoQuery query = new HotelInfoQuery()
            {
                AreaId = hotelQuery.AreaId,
                OrderType = hotelQuery.OrderType,
                CityId = hotelQuery.CityId,
                EndDate = hotelQuery.EndDate,
                HotelBrandID = hotelbrands,
                HotelPrice = hotelQuery.HotelPrice,
                HotelStar = hotelQuery.HotelStar,
                KeyWords = hotelQuery.KeyWords,
                LocationID = hotelQuery.LocationID,
                MaxPrice = hotelQuery.MaxPrice,
                MaxStar = hotelQuery.MaxStar,
                MinPrice = hotelQuery.MinPrice,
                MinStar = hotelQuery.MinStar,
                PageIndex = hotelQuery.PageIndex,
                PageSize = hotelQuery.PageSize,
                StartDate = hotelQuery.StartDate,
                TotalRecords = hotelQuery.TotalRecords
            };

            return GetHotelQueryLink(query);
        }

        public static string GetHotelQueryHrefForHotelStars(HotelInfoQuery hotelQuery,string hotelStar,int type=1)
        {
            string hotelStars = hotelQuery.HotelStar;
            if(type>0)
            {
                List<string> brandlist = hotelQuery.HotelStar.Split('f').ToList();
                if (!brandlist.Contains(hotelStar))
                {
                    brandlist.Add(hotelStar);
                    brandlist.Remove("0-5");
                    hotelStars = brandlist.Join("f");
                }
            }
            else if(type<0)
            {
                List<string> brandlist = hotelQuery.HotelStar.Split('f').ToList();
                if (brandlist.Contains(hotelStar))
                {
                    brandlist.Remove(hotelStar);
                    brandlist.Remove("0-5");
                    hotelStars = brandlist.Join("f");
                }
            }
            if(string.IsNullOrEmpty(hotelStars))
            {
                hotelStars = "0-5";
            }

            HotelInfoQuery query = new HotelInfoQuery()
            {
                AreaId = hotelQuery.AreaId,
                OrderType = hotelQuery.OrderType,
                CityId = hotelQuery.CityId,
                EndDate = hotelQuery.EndDate,
                HotelBrandID = hotelQuery.HotelBrandID,
                HotelPrice = hotelQuery.HotelPrice,
                HotelStar = hotelStars,
                KeyWords = hotelQuery.KeyWords,
                LocationID = hotelQuery.LocationID,
                MaxPrice = hotelQuery.MaxPrice,
                MaxStar = hotelQuery.MaxStar,
                MinPrice = hotelQuery.MinPrice,
                MinStar = hotelQuery.MinStar,
                PageIndex = hotelQuery.PageIndex,
                PageSize = hotelQuery.PageSize,
                StartDate = hotelQuery.StartDate,
                TotalRecords = hotelQuery.TotalRecords
            };

            return GetHotelQueryLink(query);
        }

        /// <summary>
        /// 获取查询链接
        /// </summary>
        /// <param name="hotelQuery"></param>
        /// <returns></returns>
        private static string GetHotelQueryLink(HotelInfoQuery hotelQuery)
        {
            StringBuilder href = new StringBuilder("/hotelsearch_");
            href.AppendFormat("{0}_", hotelQuery.CityId);
            href.AppendFormat("{0}_", hotelQuery.AreaId);
            href.AppendFormat("{0}_", hotelQuery.LocationID);
            href.AppendFormat("{0}_", hotelQuery.HotelBrandID);
            href.AppendFormat("{0}_", hotelQuery.StartDate.ToString("yyyy-MM-dd"));
            href.AppendFormat("{0}_", hotelQuery.EndDate.ToString("yyyy-MM-dd"));
            href.AppendFormat("{0}_", hotelQuery.HotelStar);
            href.AppendFormat("{0}_", hotelQuery.HotelPrice);
            href.AppendFormat("{0}_", hotelQuery.PageIndex);
            href.AppendFormat("{0}_", hotelQuery.OrderType);
            href.AppendFormat("{0}", hotelQuery.KeyWords);
            href.Append(".html");
            return href.ToString();
        }

        public static string GetHotelQueryLinkForArea(HotelInfoQuery hotelQuery)
        {
            HotelInfoQuery query = new HotelInfoQuery()
            {
                AreaId = 0,
                OrderType = hotelQuery.OrderType,
                CityId = hotelQuery.CityId,
                EndDate = hotelQuery.EndDate,
                HotelBrandID = hotelQuery.HotelBrandID,
                HotelPrice = hotelQuery.HotelPrice,
                HotelStar = hotelQuery.HotelStar,
                KeyWords = hotelQuery.KeyWords,
                LocationID = 0,
                MaxPrice = hotelQuery.MaxPrice,
                MaxStar = hotelQuery.MaxStar,
                MinPrice = hotelQuery.MinPrice,
                MinStar = hotelQuery.MinStar,
                PageIndex = hotelQuery.PageIndex,
                PageSize = hotelQuery.PageSize,
                StartDate = hotelQuery.StartDate,
                TotalRecords = hotelQuery.TotalRecords
            };
            return GetHotelQueryLink(query);
        }

        /// <summary>
        /// 酒店选择价格
        /// </summary>
        /// <param name="hotelQuery"></param>
        /// <returns></returns>
        public static MvcHtmlString GetHotelPriceCheckBox(HotelInfoQuery hotelQuery)
        {
            StringBuilder build = new StringBuilder();

            Type hotelPriceType = typeof(HotelPriceLevel);
            var priceTypes = Enum.GetValues(hotelPriceType);

            FieldInfo field;
            DescriptionAttribute descatt;
            NumberRangeAttribute numatt;

            string queryHref = "";
            string priceRange = "";
            bool isSelect = false;
            foreach (int val in priceTypes)
            {
                field = hotelPriceType.GetField(Enum.GetName(hotelPriceType, val));
                descatt = (DescriptionAttribute)field.GetCustomAttributes(typeof(DescriptionAttribute), false).SingleOrDefault();
                numatt = (NumberRangeAttribute)field.GetCustomAttributes(typeof(NumberRangeAttribute), false).SingleOrDefault();

                priceRange = string.Format("{0}-{1}", numatt.Min, numatt.Max);

                queryHref = GetHotelQueryHref(hotelQuery, hotelQuery.LocationID, hotelQuery.AreaId, hotelQuery.HotelStar, hotelQuery.HotelBrandID, priceRange, "search", hotelQuery.PageIndex);
                if (val == (int)HotelPriceLevel.All)
                {
                    build.AppendFormat("<a class=\"notto on\" data='{1}' name='HotelPriceLevelCheckBox' rel=\"nofollow\">{0}</a>", descatt.Description,val);
                }
                else
                {
                    if (priceRange == hotelQuery.HotelPrice)
                    {
                        isSelect = true;
                    }
                    else
                    {
                        isSelect = false;
                    }
                    build.AppendFormat("<a rel=\"nofollow\"><input type=\"radio\" id='price{0}' data='{3}' name=\"HotelPriceLevelCheckBox\" class=\"radio\" {2}><label for=\"price{0}\">{1}</label></a>", val, descatt.Description, isSelect ? "checked" : "", priceRange);
                }
            }
            return new MvcHtmlString(build.ToString());
        }

        /// <summary>
        /// 酒店星级选择
        /// </summary>
        /// <param name="hotelQuery"></param>
        /// <returns></returns>
        public static MvcHtmlString GetHotelStarCheckBox(HotelInfoQuery hotelQuery)
        {
            StringBuilder build = new StringBuilder();

            Type hotelPriceType = typeof(HotelStarLevel);
            var priceTypes = Enum.GetValues(hotelPriceType);

            FieldInfo field;
            DescriptionAttribute descatt;
            NumberRangeAttribute numatt;

            string selectedQueryHref = "";
            string unselectQueryHref = "";
            string starRange = "";
            bool isSelcted = false;

            foreach (int val in priceTypes)
            {
                field = hotelPriceType.GetField(Enum.GetName(hotelPriceType, val));
                descatt = (DescriptionAttribute)field.GetCustomAttributes(typeof(DescriptionAttribute), false).SingleOrDefault();
                numatt = (NumberRangeAttribute)field.GetCustomAttributes(typeof(NumberRangeAttribute), false).SingleOrDefault();

                starRange = string.Format("{0}-{1}", numatt.Min, numatt.Max);
                unselectQueryHref = GetHotelQueryHrefForHotelStars(hotelQuery, starRange,-1);
                selectedQueryHref = GetHotelQueryHrefForHotelStars(hotelQuery, starRange, 1);
                if (val == (int)HotelPriceLevel.All)
                {
                    selectedQueryHref = GetHotelQueryHref(hotelQuery, hotelQuery.LocationID, hotelQuery.AreaId, starRange, hotelQuery.HotelBrandID, hotelQuery.HotelPrice, "search", hotelQuery.PageIndex);
                    build.AppendFormat("<a class=\"notto on\" rel=\"nofollow\">{0}</a>", descatt.Description);
                }
                else
                {
                    var stars = hotelQuery.HotelStar.Split('f').ToList().Where(u => u == starRange).ToList();
                    if (stars != null && stars.Count > 0)
                    {
                        isSelcted = true;
                    }
                    else
                    {
                        isSelcted = false;
                    }

                    build.AppendFormat("<a rel=\"nofollow\"><input type=\"checkbox\" data='{0}' id='price{0}' name=\"HotelStarLevel\" class=\"checkbox\" {2}><label for=\"price{0}\">{1}</label></a>", val, descatt.Description, isSelcted ? "checked" : "");
                }
            }
            return new MvcHtmlString(build.ToString());
        }

        /// <summary>
        /// 获取酒店详细链接
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public static string GetHotelInfoLink(int hotelId)
        {
            return string.Format("/HotelInfo_{0}.html", hotelId);
        }

        /// <summary>
        /// 获取酒店详细信息链接
        /// </summary>
        /// <param name="hotelId">酒店ID</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">介绍日期</param>
        /// <returns></returns>
        public static string GetHotelInfoLink(int hotelId, DateTime startDate, DateTime endDate)
        {
            return string.Format("/HotelInfo_{0}.html#{1}_{2}", hotelId, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
        }

        public static string GetHotelInfoQueryByCityId(int cityId)
        {
            HotelInfoQuery hotelInfoQuery = new HotelInfoQuery();
            hotelInfoQuery.CityId = cityId;
            return GetHotelQueryLink(hotelInfoQuery);
        }

        public static string GetHotelInfoQueryByHotelBrandID(int brandId)
        {
            HotelInfoQuery hotelQuery = new HotelInfoQuery();
            hotelQuery.HotelBrandID = brandId.ToString();
            return GetHotelQueryLink(hotelQuery);
        }

        public static string GetHotelInfoQueryHomePage()
        {
            HotelInfoQuery hotelQuery = new HotelInfoQuery();
            hotelQuery.CityId = 1;
            return GetHotelQueryLink(hotelQuery);
        }

        public static string GetHotelInfoQueryUrl(int cityId,int brandId)
        {
            HotelInfoQuery query = new HotelInfoQuery();
            query.CityId = cityId;
            query.HotelBrandID = brandId.ToString();
            
            return GetHotelQueryLink(query);
        }

        public static string GetHotelInfoQueryUrlByLocationID(int cityId,int locationId)
        {
            HotelInfoQuery query = new HotelInfoQuery();
            query.CityId = cityId;
            query.LocationID = locationId;
            return GetHotelQueryLink(query);
        }

        public static string GetHotelInfoQueryUrlByAreaInfo(int cityId,int areaId,string areaName)
        {
            HotelInfoQuery query = new HotelInfoQuery();
            query.CityId = cityId;
            query.AreaId = areaId;
            query.KeyWords = areaName;
            return GetHotelQueryLink(query);
        }

        /// <summary>
        /// 同程酒店下单页面
        /// </summary>
        /// <param name="hotelid"></param>
        /// <param name="roomTypeId"></param>
        /// <param name="comeDate"></param>
        /// <param name="leaveData"></param>
        /// <param name="hotelType"></param>
        /// <param name="bookingCode"></param>
        /// <param name="policyId"></param>
        /// <returns></returns>
        public static string TCHotelBookPage(int hotelid,int roomTypeId,DateTime comeDate,DateTime leaveData,string hotelType,string bookingCode,int policyId)
        {
            string refId = ConfigurationManager.AppSettings["TC_AllianceID"];
            string bookUrl = string.Format("http://www.ly.com/Yuding1.aspx?HotelId={0}&RoomTypeId={1}&ComeDate={2}&LeaveDate={3}&HotelType={4}&YudingCode={5}&PolicyId={6}&RefId={7}", hotelid, roomTypeId, comeDate.ToString("yyyy-MM-dd"), leaveData.ToString("yyyy-MM-dd"), hotelType, bookingCode, policyId, refId);
            return bookUrl;
        }

        /// <summary>
        /// 携程酒店下单页面
        /// </summary>
        /// <param name="hotelid"></param>
        /// <param name="roomTypeCode"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static string CtripHotelBookPage(int hotelid,int roomTypeCode,DateTime startDate,DateTime endDate)
        {
            string allianceid = ConfigurationManager.AppSettings["C_ALLIANCEID"];
            string siteId = ConfigurationManager.AppSettings["C_SID"];
            string paymentTerm = "FG";
            string bookUrl = string.Format("http://u.ctrip.com/union/CtripRedirect.aspx?TypeID=11&AllianceID={0}&SID={1}&Ouid=&SSOh=790dcdb4156db43f5b29c9afc2ea9347&SSOt=20130419161230&HotelID={2}&RoomID={3}&Paymentterm={4}&StartDate={5}&depDate={6}", allianceid, siteId, hotelid, roomTypeCode,paymentTerm,startDate.ToString("yyyy-MM-dd"),endDate.ToString("yyyy-MM-dd"));
            return bookUrl;
        }

        public static List<TradeAreaInfo> GetCityCBD(int cityid, List<TradeAreaInfo> source)
        {
            var items = source.Where(u => u.CityId == cityid).ToList();
            if(items==null)
            {
                items = new List<TradeAreaInfo>();
            }
            return items;
        }

        public static List<SchoolSummaryInfo> GetCitySchools(int cityid,List<SchoolSummaryInfo> source,int count=1000)
        {
            var items = source.Where(u=>u.CityId==cityid).ToList();
            if(items!=null)
            {
                items = items.Range(count);
            }
            else
            {
                items = new List<SchoolSummaryInfo>();
            }
            return items;
        }
    }
}
