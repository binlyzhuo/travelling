using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Travel
{
    /// <summary>
    /// 酒店浏览记录
    /// </summary>
    public class HotelCookieView
    {
        /// <summary>
        /// 酒店ID
        /// </summary>
        [Key]
        public int HotelId { set; get; }

        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName { set; get; }

        /// <summary>
        /// 酒店图片
        /// </summary>
        public string HotelIcon { set; get; }

        /// <summary>
        /// 酒店星级
        /// </summary>
        public int HotelStar { set; get; }

        /// <summary>
        /// 酒店最低价格
        /// </summary>
        public int Amount { set; get; }

        /// <summary>
        /// 联盟Id
        /// </summary>
        public int UnionId { set; get; }
    }
}
