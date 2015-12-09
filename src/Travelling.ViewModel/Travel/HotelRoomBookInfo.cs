using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Travel
{
    /// <summary>
    /// 酒店预定信息
    /// </summary>
    public class HotelRoomBookInfo
    {
        /// <summary>
        /// 酒店ID
        /// </summary>
        public int HotelCode { set; get; }

        /// <summary>
        /// 房型编码
        /// </summary>
        public int RoomTypeCode { set; get; }

        /// <summary>
        /// 入住日期
        /// </summary>
        public DateTime InRoomDate { set; get; }

        /// <summary>
        /// 离店日期
        /// </summary>
        public DateTime OffRoomDate { set; get; }

        /// <summary>
        /// 房间间数
        /// </summary>
        public int RoomCount { set; get; }

        /// <summary>
        /// 客户
        /// </summary>
        public List<string> Customers { set; get; }

        /// <summary>
        /// 最早达到时间
        /// </summary>
        public string BeforeCheckInTime { set; get; }

        /// <summary>
        /// 最晚到底时间
        /// </summary>
        public string LastCheckInTime { set; get; }

        /// <summary>
        /// 联系人名字
        /// </summary>
        public string ContactName { set; get; }

        /// <summary>
        /// 联系人手机
        /// </summary>
        public string MobilePhone { set; get; }

        /// <summary>
        /// 联系Email
        /// </summary>
        public string ContactEmail { set; get; }

        /// <summary>
        /// 税前价格
        /// </summary>
        public int AmountBeforeTax { set; get; }

        /// <summary>
        /// 是否安装人数安排房间
        /// </summary>
        public bool IsPerRoom { set; get; }

        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName { set; get; }

        /// <summary>
        /// 酒店地址
        /// </summary>
        public string HotelAddress { set; get; }

        /// <summary>
        /// 房型名称
        /// </summary>
        public string RoomTypeName { set; get; }

        public int RatePlanCategory { set; get; }

        public int CityId { set; get; }
    }
}
