using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Travelling.Domain;
using Travelling.ViewModel.Dto.Ticket;
using Travelling.ViewModel.Ticket;
using Travelling.ViewModel.Travel;
using HtmlAgilityPack;
using System.ComponentModel;
using Travelling.FrameWork;
using Travelling.OpenApiEntity.Scenery.Module;
using System.Configuration;


namespace Travelling.Web.Helpers
{
    /// <summary>
    /// 景区其他信息
    /// </summary>
    public class SceneryTicketHelper
    {
        

        /// <summary>
        /// 获取景区主题 
        /// </summary>
        /// <param name="themes"></param>
        /// <returns></returns>
        public static string GetSceneryTicketTheme(string themes)
        {
            if(string.IsNullOrEmpty(themes))
            {
                return "";
            }
            else
            {
                var themeList = themes.Split(',').Select(u => {
                    return Convert.ToInt32(u);
                }).ToList();

                
                
            }

            return ";";
        }

        /// <summary>
        /// 获取景区价格信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<SceneryTicketPrice> GetSceneryTicketPricesBySceneryId(int sceneryId,List<SceneryTicketPrice> source)
        {
            var queryResult = (from it in source 
                              where it.SceneryID == sceneryId
                                   select it
                                   ).ToList();
            

            return queryResult;              
        }

        /// <summary>
        /// 获取景区图片信息
        /// </summary>
        /// <returns></returns>
        public static List<ImgObject> GetSceneryImgList(List<SceneryImgInfo> imgs)
        {
            List<ImgObject> imgOjects = new List<ImgObject>();
            imgs.ForEach(u =>
            {
                imgOjects.Add(new ImgObject() { 
                  IsDefault = false, ImgUrl = u.ImgBaseUrl + u.ImgList[1].SizeValue+"\\"+u.ImgUrl
                });
            });

            return imgOjects;
            
        }

       
        /// <summary>
        /// 景区查询url
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static string GetSceneryQueryUrl(SceneryQueryInfo query)
        {
            StringBuilder queryUrl = new StringBuilder("/ticketsearch_");
            queryUrl.AppendFormat("{0}_",query.ProvinceId);
            queryUrl.AppendFormat("{0}_", query.CityID);
            queryUrl.AppendFormat("{0}_",query.ThemeId);
            queryUrl.AppendFormat("{0}_",query.Star);
            queryUrl.AppendFormat("{0}_",query.PageIndex);
            queryUrl.AppendFormat("{0}_", query.OrderBy);
            queryUrl.AppendFormat("{0}",query.KeyWord);
            queryUrl.Append(".html");
            return queryUrl.ToString();
        }

        public static string GetSceneryQueryUrl(int provinceId,int cityID)
        {
            SceneryQueryInfo query = new SceneryQueryInfo();
            query.ProvinceId = provinceId;
            query.CityID = cityID;
            return GetSceneryQueryUrl(query);
        }

        public static string GetSceneryQueryUrlByThemeId(int themeId)
        {
            SceneryQueryInfo query = new SceneryQueryInfo();
            query.ThemeId = themeId;
            
            return GetSceneryQueryUrl(query);
        }

        /// <summary>
        /// 景区查询url
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static string GetSceneryQueryUrl(SceneryQueryInfo query,int provinceId,int cityId,int themeId,int page,string key="",int orderby=0)
        {
            
            SceneryQueryInfo sceneryQuery = new SceneryQueryInfo();
            sceneryQuery.ThemeId = themeId;
            sceneryQuery.PageSize = query.PageSize;
            sceneryQuery.KeyWord = query.KeyWord;
            sceneryQuery.PageIndex = page;
            if(query.ProvinceId!=provinceId)
            {
                cityId = 0;
            }

            if (provinceId > 0)
            {
                sceneryQuery.KeyWord = key;
                sceneryQuery.ProvinceId = provinceId;
            }
            else
            {
                sceneryQuery.KeyWord = query.KeyWord;
            }
            if (cityId > 0)
            {
                sceneryQuery.KeyWord = key;
                sceneryQuery.CityID = cityId;
            }
            else
            {
                sceneryQuery.KeyWord = query.KeyWord;
            }

            if(themeId>0)
            {
                sceneryQuery.KeyWord = key;
                sceneryQuery.ThemeId = themeId;
            }
            else
            {
                sceneryQuery.KeyWord = query.KeyWord;
            }

            sceneryQuery.OrderBy = orderby;
            if(string.IsNullOrEmpty(key))
            {
                sceneryQuery.KeyWord = "search";
            }

            return GetSceneryQueryUrl(sceneryQuery);
        }

        /// <summary>
        /// 景区查询url
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static string GetSceneryQueryUrl(SceneryQueryInfo query,SceneryQueryType queryType)
        {
            int provinceId = query.ProvinceId;
            int star = query.Star;
            int theme = query.ThemeId;
            int cityId = query.CityID;

            switch(queryType)
            {
                case SceneryQueryType.Province:
                    provinceId = 0;
                    break;
                case SceneryQueryType.Star:
                    star = 0;
                    break;
                case SceneryQueryType.Theme:
                    theme = 0;
                    break;
                case SceneryQueryType.City:
                    cityId = 0;
                    break;
            }
            return GetSceneryQueryUrl(query, provinceId, cityId, theme, query.PageIndex);
        }

        

        /// <summary>
        /// 获取景区星级链接
        /// </summary>
        /// <returns></returns>
        public static MvcHtmlString GetSceneryStarHref(SceneryQueryInfo query)
        {
            Type type = typeof(SceneryStarLevel);
            var starValues = (from int val in Enum.GetValues(type)
                              let field = type.GetField(Enum.GetName(type, val))
                              let descAtt = (DescriptionAttribute)field.GetCustomAttributes(typeof(DescriptionAttribute), false).SingleOrDefault()
                              let numAtt = (NumberRangeAttribute)field.GetCustomAttributes(typeof(NumberRangeAttribute), false).SingleOrDefault()
                              let orderAtt = (OrderNumberAttribute)field.GetCustomAttributes(typeof(OrderNumberAttribute), false).SingleOrDefault()
                              select new { LinkName = descAtt.Description, Value = val,Order = orderAtt.OrderNumber }).ToList().OrderBy(u=>u.Order).ToList();

            StringBuilder href = new StringBuilder();
            int selectStar = query.Star;
            foreach (var star in starValues)
            {
                query.Star = star.Value;
                href.AppendFormat("<a {2} data='{3}' href='{0}'>{1}</a>", "#", star.LinkName, star.Value == selectStar ? "class='on starinfo'" : "class='starinfo'", star.Value);
            }
            return new MvcHtmlString(href.ToString());
        }

        /// <summary>
        /// 获取景区详细页面链接
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        public static string GetSceneryInfoLink(int sceneryId)
        {
            return string.Format("/SceneryInfo_{0}.html",sceneryId);
        }

        public static string GetTicketPayTypeName(int type)
        {
            string typeName = EnumHelper.GetDescriptionFromEnumValue((SceneryTicketPayType)type);
            return typeName;
        }

        public static string GetSceneryTicketHomeUrl()
        {
            SceneryQueryInfo query = new SceneryQueryInfo() { };
            return GetSceneryQueryUrl(query);
        }

        public static string GetSceneryTicketByProvinceID(int provinceId,int cityId)
        {
            return string.Format("/ticketsearch_{0}_{1}_0_0_1_0_search.html",provinceId,cityId);
        }

        public static string GetSceneryInfoUrl(int sceneryId)
        {
            return string.Format("/SceneryInfo_{0}.html",sceneryId);
        }

        public static string GetTCSceneryOrderUrl(int sceneryId,int policyId)
        {
            return string.Format("{0}?sceneryId={1}&ticketId={2}&refid={3}", ConfigurationManager.AppSettings["TC_SceneryTicketOrderUrl"], sceneryId, policyId, ConfigurationManager.AppSettings["TC_AllianceID"]);
        }
    }
}
