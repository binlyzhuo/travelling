using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Lucene
{
    /// <summary>
    /// 酒店Lucene信息
    /// </summary>
    public class HotelLuceneIndexInfo
    {
        /// <summary>
        /// 酒店ID
        /// </summary>
        public int HotelID { set; get; }

        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName { set; get; }

        /// <summary>
        /// 酒店城市ID
        /// </summary>
        public int HotelCityCode { set; get; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { set; get; }

        /// <summary>
        /// 酒店品牌
        /// </summary>
        public int HotelStarRate { set; get; }

        /// <summary>
        /// 酒店价格
        /// </summary>
        public int AmountBeforeTax { set; get; }

        /// <summary>
        /// 门市价格
        /// </summary>
        public int ListAmount { set; get; }

        /// <summary>
        /// 酒店品牌名称
        /// </summary>
        public string BrandName { set; get; }

        /// <summary>
        /// 酒店品牌ID
        /// </summary>
        public int BrandCode { set; get; }

        /// <summary>
        /// 酒店图片
        /// </summary>
        public string HotelImg { set; get; }

        /// <summary>
        /// 酒店价格
        /// </summary>
        public string AddressLine { set; get; }

        /// <summary>
        /// 酒店热点区域
        /// </summary>
        public string RefPoints { set; get; }

        /// <summary>
        /// 行政区域ID
        /// </summary>
        public int LocationId { set; get; }

        /// <summary>
        /// 行政区域名称
        /// </summary>
        public string LocationName { set; get; }

        /// <summary>
        /// 排序
        /// </summary>
        public int OrderType { set; get; }

        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude { set; get; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude { set; get; }

        ///// <summary>
        ///// 区域ID
        ///// </summary>
        //public int ZoneId { set; get; }

        ///// <summary>
        ///// 区域名称
        ///// </summary>
        //public string ZoneName { set; get; }

        /// <summary>
        /// 创建日期,eg:20140110
        /// </summary>
        public string CreateDate { set; get; }

        /// <summary>
        /// 携程酒店星级
        /// </summary>
        public float CtripStarRate { set; get; }

        /// <summary>
        /// 用户推荐级别
        /// </summary>
        public float CtripUserRate { set; get; }

        /// <summary>
        /// 酒店点评－综合评分
        /// </summary>
        public float CtripCommRate { set; get; }

        /// <summary>
        /// 酒店点评－酒店服务分类评分
        /// </summary>
        public float CommServiceRate { set; get; }

        /// <summary>
        /// 联盟
        /// 0-携程
        /// 1-住哪
        /// 2-同程
        /// </summary>
        public int UnionId { set; get; }

        /// <summary>
        /// 住哪酒店ID
        /// </summary>
        public int ZhunaHotelId { set; get; }

        /// <summary>
        /// 酒店总表主键
        /// </summary>
        public int ID { set; get; }

        /// <summary>
        /// 酒店描述信息
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string SearchKeyWords { set; get; }
        
    }
}
