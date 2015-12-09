using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Ticket
{
    /// <summary>
    /// 景区详细信息
    /// </summary>
    public class SceneryInfoDetail:ISceneryInfo
    {
        /// <summary>
        /// 景区ID
        /// </summary>
        public int SceneryID
        {
            set;
            get;
        }
        /// <summary>
        /// 景区名称
        /// </summary>
        public string SceneryName
        {
            set;
            get;
        }
        /// <summary>
        /// 景点级别
        /// </summary>
        public string GradeId
        {
            set;
            get;
        }
        /// <summary>
        /// 景点级别
        /// </summary>
        public int GradeInt
        {
            set;
            get;
        }
        /// <summary>
        /// 景点地址
        /// </summary>
        public string Address
        {
            set;
            get;
        }
        /// <summary>
        /// 城市ID
        /// </summary>
        public int CityID
        {
            set;
            get;
        }
        /// <summary>
        /// 省份ID
        /// </summary>
        public int ProvinceID
        {
            set;
            get;
        }
        /// <summary>
        /// 景点简介
        /// </summary>
        public string Intro
        {
            set;
            get;
        }
        /// <summary>
        /// 购票需知
        /// </summary>
        public string BuyNotice
        {
            set;
            get;
        }
        /// <summary>
        /// 支付类型-例如:景区现付
        /// </summary>
        public string PayMode
        {
            set;
            get;
        }
        /// <summary>
        /// Mapbar经度/百度经度-Cs为1时为Mapbar;cs为2时为百度
        /// </summary>
        public string Lon
        {
            set;
            get;
        }
        /// <summary>
        /// Mapbar纬度/百度纬度,Cs为1时为Mapbar;cs为2时为百度
        /// </summary>
        public string Lat
        {
            set;
            get;
        }
        /// <summary>
        /// 景点别名,多个已“|”隔开
        /// </summary>
        public string SceneryAlias
        {
            set;
            get;
        }
        /// <summary>
        /// 同程价-该景点的最低价格，可能是儿童价
        /// </summary>
        public int AmountAdvice
        {
            set;
            get;
        }
        /// <summary>
        /// 是否使用身份证
        /// </summary>
        public int IfUseCard
        {
            set;
            get;
        }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName
        {
            set;
            get;
        }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName
        {
            set;
            get;
        }
        /// <summary>
        /// 景区简介
        /// </summary>
        public string ScenerySummary
        {
            set;
            get;
        }
        /// <summary>
        /// 可预订状态
        /// </summary>
        public int BookFlag
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Distance
        {
            set;
            get;
        }
        /// <summary>
        /// 景区主题
        /// </summary>
        public string Themes
        {
            set;
            get;
        }

        public string ThemeName { set; get; }

        /// <summary>
        /// 适合人群
        /// </summary>
        public string Suitherds
        {
            set;
            get;
        }
        /// <summary>
        /// 游客印象
        /// </summary>
        public string Impressions
        {
            set;
            get;
        }
        /// <summary>
        /// 景区图片
        /// </summary>
        public string Imgs
        {
            set;
            get;
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImgBaseUrl
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime
        {
            set;
            get;
        }
        /// <summary>
        /// 是否含有价格策络
        /// </summary>
        public int HasPricePolicy
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int CountryID
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string CountryName
        {
            set;
            get;
        }
    }
}
