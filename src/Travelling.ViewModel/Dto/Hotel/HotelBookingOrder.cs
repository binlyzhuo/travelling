using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Hotel
{
    /// <summary>
    /// 酒店订单信息
    /// </summary>
    public class HotelBookingOrder
    {
        /// <summary>
        /// 酒店ID
        /// </summary>
        public int HotelID
        {
            get;
            set;
        }
        /// <summary>
        /// 房型编码
        /// </summary>
        public int RoomTypeCode
        {
            get;
            set;
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string SerialNo
        {
            get;
            set;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            get;
            set;
        }
        /// <summary>
        /// 渠道0-携程
        /// </summary>
        public int Channel
        {
            get;
            set;
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int Flag
        {
            get;
            set;
        }
        /// <summary>
        /// 订单金额
        /// </summary>
        public int Amount
        {
            get;
            set;
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            get;
            set;
        }
        /// <summary>
        /// 联系人名称
        /// </summary>
        public string ContactPerson
        {
            get;
            set;
        }
        /// <summary>
        /// 联系手机号码
        /// </summary>
        public string ContactPhone
        {
            get;
            set;
        }
        /// <summary>
        /// 联系email
        /// </summary>
        public string ContactEmail
        {
            get;
            set;
        }
        /// <summary>
        /// 最晚到店时间
        /// </summary>
        public DateTime LateArrivalTime
        {
            get;
            set;
        }
        /// <summary>
        /// 房型名称
        /// </summary>
        public string RoomTypeName
        {
            get;
            set;
        }
        /// <summary>
        /// 入住日期
        /// </summary>
        public DateTime CheckInDate
        {
            get;
            set;
        }
        /// <summary>
        /// 离店日期
        /// </summary>
        public DateTime CheckOffDate
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
        /// 酒店地址
        /// </summary>
        public string HotelAddress
        {
            get;
            set;
        }
        /// <summary>
        /// 价格计划编码
        /// </summary>
        public int RatePlanCategory
        {
            get;
            set;
        }

        /// <summary>
        /// 房间间数
        /// </summary>
        public int RoomCount
        {
            get;
            set;
        }
        /// <summary>
        /// 客户
        /// </summary>
        public string Customers
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int UnionID
        {
            set;
            get;
        }
    }
}
