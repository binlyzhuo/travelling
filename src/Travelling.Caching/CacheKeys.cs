using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Travelling.Caching
{
    /// <summary>
    /// 缓存键
    /// </summary>
    public class CacheKeys
    {
        [Description("酒店最低价格")]
        public const string HotelPrices = "hotelallprices";

        [Description("推荐酒店城市")]
        public const string RecommandCities = "recommandcities";


        [Description("推荐热门酒店")]
        public const string HotHotelsRecommend = "HotHotelsRecommend";



        [Description("酒店热门城市")]
        public const string HotelHotCityInfos = "HotelHotCityInfos";

        [Description("景区热门省份")]
        public const string HotProvinceSceneryInfos = "HotProvinceSceneryInfos";

        [Description("景区热门省份获取星级景区")]
        public const string HotSceneryForProvincesByGrade = "HotSceneryForProvincesByGrade";

        [Description("景区主题信息")]
        public const string SceneryThemeInfos = "SceneryThemeInfos";

        [Description("酒店城市热门区域")]
        public const string CityAreaInfos = "CityAreaInfo";

        [Description("酒店城市热门区域汇总信息")]
        public const string CityAreaInfosSummary = "CityAreaInfosSummary";

        /*
         * 2014-11-04
         * 
         */
        [Description("景区详细信息缓存")]
        public const string SceneryInfoDetailsCache = "SceneryInfoDetailsCache";

        [Description("景区城市信息缓存")]
        public const string SceneryProvincesCache = "SceneryProvincesCache";

        /*2014-11-23*/
        [Description("酒店品牌信息缓存")]
        public const string HotelBrandDetailInfos = "HotelBrandDetailInfos";

        [Description("酒店详细信息缓存")]
        public const string HoteCitylDetailInfos = "HoteCitylDetailInfos";

        [Description("酒店静态信息缓存")]
        public const string HotelDescriptionInfoCache = "HotelDescriptionInfoCache";

        [Description("携程城市热门区域信息")]
        public const string XC_HotelCityAreas = "XC_HotelCityAreas";

        [Description("携程酒店行政区域信息")]
        public const string XC_HotelLocationInfos = "XC_HotelLocationInfos";

        /*2014-11-25*/

        /// <summary>
        /// 精选酒店以及城市信息
        /// </summary>
        [Description("精选酒店信息缓存")]
        public const string HotelChoiceCityInfos = "HotelChoiceCityInfos";

        [Description("酒店品牌统计信息")]
        public const string HotelBrandSummaryInfos = "HotelBrandSummaryInfos";

        [Description("酒店城市统计")]
        public const string HotelCitySummaryInfos = "HotelCitySummaryInfos";

        [Description("最优惠酒店信息")]
        public const string HotelMostPractical = "HotelMostPractical";

        [Description("HotelCheapMost")]
        public const string HotelCheapMost = "HotelCheapMost";

        /*
         * 2014-11-27
         */
        [Description("推荐酒店品牌信息缓存")]
        public const string HotelBrandSearchRecommends = "HotelBrandSearchRecommends";

        [Description("友情链接缓存")]
        public const string FriendLinks = "FriendLinks";

        [Description("国内热门景点城市")]
        public const string SceneryHotCityInfos = "SceneryHotCityInfos";

        [Description("菜单缓存")]
        public const string TopMenuSettingCache = "TopMenuSettingCache";

        [Description("国内酒店信息")]
        public const string HotelInfosCacheKey = "HotelInfosCacheKey";

        [Description("酒店品牌信息缓存HotelBrand")]
        public const string HotelBrandsInfoCacheKey = "HotelBrandInfoCacheKey";

        [Description("热门城市商圈缓存")]
        public const string HotCityTradeAreaGetCache = "HotCityTradeAreaGetCache";

        [Description("学校统计信息缓存")]
        public const string SchoolSummaryInfoCache = "SchoolSummaryInfoCache";

        [Description("住哪城市信息缓存")]
        public const string ZhunaCityInfoCache = "ZhunaCityInfoCache";

    }
}
