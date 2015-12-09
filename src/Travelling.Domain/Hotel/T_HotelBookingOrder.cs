using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain
{
    /// <summary>
    /// 酒店预定记录
    /// </summary>
    [Serializable]
    public partial class T_HotelBookingOrder
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public T_HotelBookingOrder()
        { }
        #region Model
        private int _id;
        private int _hotelid = 0;
        private int _roomtypecode = 0;
        private string _serialno = "";
        private DateTime _adddate = DateTime.Now;
        private int _channel = 0;
        private int _flag = 0;
        private decimal _amount = 0M;
        private int _userid = 0;
        private string _contactperson = "";
        private string _contactphone = "";
        private string _contactemail = "";
        private DateTime _latearrivaltime = DateTime.Now;
        private string _roomtypename = "";
        private DateTime _checkindate = DateTime.Now;
        private DateTime _checkoffdate = DateTime.Now;
        private string _hotelname = "";
        private string _hoteladdress = "";
        private int _rateplancategory = 16;
        private int _roomcount = 1;
        private string _customers = "";
        private int _unionid = 0;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 酒店ID
        /// </summary>
        public int HotelID
        {
            set { _hotelid = value; }
            get { return _hotelid; }
        }
        /// <summary>
        /// 房型编码
        /// </summary>
        public int RoomTypeCode
        {
            set { _roomtypecode = value; }
            get { return _roomtypecode; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string SerialNo
        {
            set { _serialno = value; }
            get { return _serialno; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 渠道0-携程
        /// </summary>
        public int Channel
        {
            set { _channel = value; }
            get { return _channel; }
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int Flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 联系人名称
        /// </summary>
        public string ContactPerson
        {
            set { _contactperson = value; }
            get { return _contactperson; }
        }
        /// <summary>
        /// 联系手机号码
        /// </summary>
        public string ContactPhone
        {
            set { _contactphone = value; }
            get { return _contactphone; }
        }
        /// <summary>
        /// 联系email
        /// </summary>
        public string ContactEmail
        {
            set { _contactemail = value; }
            get { return _contactemail; }
        }
        /// <summary>
        /// 最晚到店时间
        /// </summary>
        public DateTime LateArrivalTime
        {
            set { _latearrivaltime = value; }
            get { return _latearrivaltime; }
        }
        /// <summary>
        /// 房型名称
        /// </summary>
        public string RoomTypeName
        {
            set { _roomtypename = value; }
            get { return _roomtypename; }
        }
        /// <summary>
        /// 入住日期
        /// </summary>
        public DateTime CheckInDate
        {
            set { _checkindate = value; }
            get { return _checkindate; }
        }
        /// <summary>
        /// 离店日期
        /// </summary>
        public DateTime CheckOffDate
        {
            set { _checkoffdate = value; }
            get { return _checkoffdate; }
        }
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName
        {
            set { _hotelname = value; }
            get { return _hotelname; }
        }
        /// <summary>
        /// 酒店地址
        /// </summary>
        public string HotelAddress
        {
            set { _hoteladdress = value; }
            get { return _hoteladdress; }
        }
        /// <summary>
        /// 价格计划编码
        /// </summary>
        public int RatePlanCategory
        {
            set { _rateplancategory = value; }
            get { return _rateplancategory; }
        }

        /// <summary>
        /// 房间间数
        /// </summary>
        public int RoomCount
        {
            set { _roomcount = value; }
            get { return _roomcount; }
        }
        /// <summary>
        /// 客户
        /// </summary>
        public string Customers
        {
            set { _customers = value; }
            get { return _customers; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int UnionID
        {
            set { _unionid = value; }
            get { return _unionid; }
        }
        #endregion Model

    }
}
