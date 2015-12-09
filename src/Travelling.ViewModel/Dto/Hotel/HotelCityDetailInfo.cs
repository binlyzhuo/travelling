using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Hotel
{
    /// <summary>
    /// 酒店城市详细信息
    /// </summary>
    public class HotelCityDetailInfo
    {
        /// <summary>
        /// 城市id
        /// </summary>
        public int CityID
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string CityName
        {
            set;
            get;
        }
        /// <summary>
        /// 城市英文名称
        /// </summary>
        public string CityEName
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
        /// 省份名称
        /// </summary>
        public string ProvinceName
        {
            set;
            get;
        }
        /// <summary>
        /// 是否是推荐城市
        ///   首页推荐
        /// </summary>
        public int IsRecommendCity
        {
            set;
            get;
        }
        /// <summary>
        /// 推荐排序,从低到高
        /// </summary>
        public int RecommentIndex
        {
            set;
            get;
        }
        /// <summary>
        /// 是否是热门城市，网页底部显示
        /// </summary>
        public int IsHotCity
        {
            set;
            get;
        }
        /// <summary>
        /// 热门城市推荐索引，从低到高
        /// </summary>
        public int HotCityIndex
        {
            set;
            get;
        }
        /// <summary>
        /// 城市包含城市个数
        /// </summary>
        public int HotelCount
        {
            set;
            get;
        }
        /// <summary>
        /// 上次同步时间
        /// </summary>
        public DateTime LastSyncHotelInfoDate
        {
            set;
            get;
        }
        /// <summary>
        /// 精选酒店城市
        /// </summary>
        public int IsChoiceCity
        {
            set;
            get;
        }
        /// <summary>
        /// 精选酒店城市排名
        /// </summary>
        public int ChoiceCityIndex
        {
            set;
            get;
        }
        /// <summary>
        /// 是否查询推荐,hotelcount>0
        /// </summary>
        public int IsSearch
        {
            set;
            get;
        }

        public string CityCode { set; get; }
    }
}
