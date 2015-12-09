using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Hotel
{
    /// <summary>
    /// 酒店价格计划主要信息
    /// </summary>
    public class HotelRoomRatePlanPrimaryInfo
    {
        /// <summary>
        /// 酒店ID
        /// </summary>
        public int HotelId { set; get; }

        /// <summary>
        /// 房型编码
        /// </summary>
        public int RoomTypeCode { set; get; }

        /// <summary>
        /// 预定日期
        /// </summary>
        public DateTime StartTime { set; get; }

        /// <summary>
        /// 房间价格
        /// </summary>
        public int AmountBeforeTax { set; get; }

        /// <summary>
        /// 价格计划类型代码
        /// </summary>
        public int RatePlanCategory { set; get; }

        /// <summary>
        /// 早餐份数
        /// </summary>
        public int NumberOfBreakfast { set; get; }
    }
}
