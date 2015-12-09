using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Hotel
{
    public class HotelInfoDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 携程酒店ID
        /// </summary>
        public int HotelID
        {
            get;
            set;
        }
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName
        {
            get;
            set;
        }
        /// <summary>
        /// 联盟ID
        /// </summary>
        public int UnionId
        {
            get;
            set;
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get;
            set;
        }
        /// <summary>
        /// 城市ID
        /// </summary>
        public int CityId
        {
            get;
            set;
        }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName
        {
            get;
            set;
        }
        /// <summary>
        /// 周边
        /// </summary>
        public string RefPoint
        {
            get;
            set;
        }
        /// <summary>
        /// 行政区ID
        /// </summary>
        public int LocationId
        {
            get;
            set;
        }
        /// <summary>
        /// 行政区名称
        /// </summary>
        public string LocationName
        {
            get;
            set;
        }
        /// <summary>
        /// 酒店品牌ID
        /// </summary>
        public int BrandId
        {
            get;
            set;
        }
        /// <summary>
        /// 酒店品牌名称
        /// </summary>
        public string BrandName
        {
            get;
            set;
        }
        /// <summary>
        /// 最低价格
        /// </summary>
        public int Amount
        {
            get;
            set;
        }
        /// <summary>
        /// 酒店图片
        /// </summary>
        public string HotelImg
        {
            get;
            set;
        }

        /// <summary>
        /// 酒店描述信息
        /// </summary>
        public string Description
        {
            get;
            set;
        }
    }
}
