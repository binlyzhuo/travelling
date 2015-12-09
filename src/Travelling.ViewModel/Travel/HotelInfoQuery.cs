using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Travel
{
    /// <summary>
    /// 酒店信息查询
    /// </summary>
    public class HotelInfoQuery : BasePageQuery
    {

        private int minPrice = 1;
        private int maxPrice = 99999;

        private int minStar = 0;
        private int maxStar = 5;// not include

        private int cityId = 0;
        private string keywords = "";
        private int areaId = 0;
        private string areaName = "";
        private DateTime startDate = DateTime.Now.Date;
        private DateTime endDate = DateTime.Now.AddDays(1).Date;
        private string hotelStar = "0-5";
        private string hotelPrice = "1-9999";
        private string brandId ="0";
        private int order = 0;
        private int locationId = 0;
        private string locationName = "";
        private string cityName = "";

        /// <summary>
        /// 城市ID
        /// </summary>
        public int CityId
        {
            set
            {
                this.cityId = value;

            }
            get
            {
                return this.cityId;
            }
        }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string KeyWords
        {
            set
            {
                this.keywords = value;
            }
            get
            {
                return this.keywords;
            }
        }

        /// <summary>
        /// 查询类型
        /// </summary>
        public int AreaId
        {
            set
            {
                this.areaId = value;
            }
            get
            {
                return this.areaId;
            }
        }

        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime StartDate
        {
            set
            {
                this.startDate = value;
            }
            get
            {
                return this.startDate;
            }
        }

        /// <summary>
        /// 离店时间
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
            }
        }

        /// <summary>
        /// 酒店星级
        /// </summary>
        public string HotelStar
        {
            get
            {
                return this.hotelStar;
            }
            set
            {
                this.hotelStar = value;
            }
        }

        /// <summary>
        /// 酒店价格
        /// </summary>
        public string HotelPrice
        {
            set
            {
                this.hotelPrice = value;
            }
            get
            {
                return this.hotelPrice;
            }
        }

        /// <summary>
        /// 酒店品牌ID
        /// </summary>
        public string HotelBrandID
        {
            set
            {
                this.brandId = value;
            }
            get
            {
                return this.brandId;
            }
        }

        /// <summary>
        /// 行政区域ID
        /// </summary>
        public int LocationID
        {
            set { this.locationId = value; }
            get { return this.locationId; }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int OrderType
        {
            get
            {
                return this.order;
            }
            set
            {
                this.order = value;
            }
        }

        /// <summary>
        /// 最低价格
        /// </summary>
        public int MinPrice
        {
            set
            {
                this.minPrice = value;
            }
            get
            {
                return this.minPrice;
            }
        }

        /// <summary>
        /// 最高价格
        /// </summary>
        public int MaxPrice
        {
            set
            {
                this.maxPrice = value;
            }
            get
            {
                return this.maxPrice;
            }
        }

        /// <summary>
        /// 酒店最小星级
        /// </summary>
        public int MinStar
        {
            set
            {
                this.minStar = value;
            }
            get
            {
                return this.minStar;
            }
        }

        /// <summary>
        /// 酒店最大星级
        /// </summary>
        public int MaxStar
        {
            set
            {
                this.maxStar = value;
            }
            get
            {
                return this.maxStar;
            }
        }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName
        {
            get
            {
                return this.cityName;
            }
            set
            {
                this.cityName = value;
            }
        }
    }
}
