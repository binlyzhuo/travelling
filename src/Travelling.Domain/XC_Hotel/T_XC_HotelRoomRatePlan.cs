using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.HotelSyncRecord
{
    /// <summary>
    /// 酒店房间价格
    /// </summary>
    [Serializable]
    public partial class T_XC_HotelRoomRatePlan
    {
        public T_XC_HotelRoomRatePlan()
        { }
        #region Model
        private int _id;
        private int _hotelid;
        private int _roomtypecode;
        private decimal _amountbeforetax = 0M;
        private decimal _listprice = 0M;
        private decimal _backamount = 0M;
        private string _backcode = "0";
        private string _backcurrencycode = "";
        private string _backdescription = "";
        private int _breakfast = 0;
        private int _numberofbreakfast = 0;
        private decimal _cancelamount = 0M;
        private string _cancelcurrencycode = "";
        private DateTime _cancelpenaltyendtime = Convert.ToDateTime("1900-1-1");
        private DateTime _cancelpenaltystarttime = Convert.ToDateTime("1900-1-1");
        private string _currencycode = "";
        private DateTime _endperiod = Convert.ToDateTime("1900-1-1");
        private DateTime _endtime = Convert.ToDateTime("1900-1-1");
        private string _guaranteecode = "";
        private DateTime _holdtime = Convert.ToDateTime("1900-1-1");
        private int _numberofguests = 0;
        private string _programname;
        private DateTime _startperiod = Convert.ToDateTime("1900-1-1");
        private DateTime _starttime = Convert.ToDateTime("1900-1-1");
        private string _status = "";
        private DateTime _adddate = DateTime.Now;
        private DateTime _updatetime = Convert.ToDateTime("1900-1-1");
        private int _rateplancategory = 0;
        private int _marketcode = 0;
        private int _isinstantconfirm = 1;
        private string _pertain = "";
        private int _syncstate = 0;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int HotelId
        {
            set { _hotelid = value; }
            get { return _hotelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RoomTypeCode
        {
            set { _roomtypecode = value; }
            get { return _roomtypecode; }
        }
        /// <summary>
        /// 价格不含税价
        /// </summary>
        public decimal AmountBeforeTax
        {
            set { _amountbeforetax = value; }
            get { return _amountbeforetax; }
        }
        /// <summary>
        /// 门市价格
        /// </summary>
        public decimal ListPrice
        {
            set { _listprice = value; }
            get { return _listprice; }
        }
        /// <summary>
        /// 返券/返利金额
        /// </summary>
        public decimal BackAmount
        {
            set { _backamount = value; }
            get { return _backamount; }
        }
        /// <summary>
        /// 活动代码，比如返利/反现等(RBP)
        /// </summary>
        public string BackCode
        {
            set { _backcode = value; }
            get { return _backcode; }
        }
        /// <summary>
        /// 返券/返利币种
        /// </summary>
        public string BackCurrencyCode
        {
            set { _backcurrencycode = value; }
            get { return _backcurrencycode; }
        }
        /// <summary>
        /// 活动描述
        /// </summary>
        public string BackDescription
        {
            set { _backdescription = value; }
            get { return _backdescription; }
        }
        /// <summary>
        /// 是否含早餐
        /// </summary>
        public int Breakfast
        {
            set { _breakfast = value; }
            get { return _breakfast; }
        }
        /// <summary>
        /// 早餐份数
        /// </summary>
        public int NumberOfBreakfast
        {
            set { _numberofbreakfast = value; }
            get { return _numberofbreakfast; }
        }
        /// <summary>
        /// 取消金额
        /// </summary>
        public decimal CancelAmount
        {
            set { _cancelamount = value; }
            get { return _cancelamount; }
        }
        /// <summary>
        /// 取消金额币种
        /// </summary>
        public string CancelCurrencyCode
        {
            set { _cancelcurrencycode = value; }
            get { return _cancelcurrencycode; }
        }
        /// <summary>
        /// 取消截止时间
        /// </summary>
        public DateTime CancelPenaltyEndTime
        {
            set { _cancelpenaltyendtime = value; }
            get { return _cancelpenaltyendtime; }
        }
        /// <summary>
        /// 取消开始时间
        /// </summary>
        public DateTime CancelPenaltyStartTime
        {
            set { _cancelpenaltystarttime = value; }
            get { return _cancelpenaltystarttime; }
        }
        /// <summary>
        /// 币种
        /// </summary>
        public string CurrencyCode
        {
            set { _currencycode = value; }
            get { return _currencycode; }
        }
        /// <summary>
        /// 返现活动结束时间
        /// </summary>
        public DateTime EndPeriod
        {
            set { _endperiod = value; }
            get { return _endperiod; }
        }
        /// <summary>
        /// 截至时间
        /// </summary>
        public DateTime EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 担保类型代码，参考CodeList(RGC)
        /// </summary>
        public string GuaranteeCode
        {
            set { _guaranteecode = value; }
            get { return _guaranteecode; }
        }
        /// <summary>
        /// 在此时间之前不需要担保
        /// </summary>
        public DateTime HoldTime
        {
            set { _holdtime = value; }
            get { return _holdtime; }
        }
        /// <summary>
        /// 此价格使用与几个客人/房间
        /// </summary>
        public int NumberOfGuests
        {
            set { _numberofguests = value; }
            get { return _numberofguests; }
        }
        /// <summary>
        /// 返现活动名称
        /// </summary>
        public string ProgramName
        {
            set { _programname = value; }
            get { return _programname; }
        }
        /// <summary>
        /// 返现活动开始时间
        /// </summary>
        public DateTime StartPeriod
        {
            set { _startperiod = value; }
            get { return _startperiod; }
        }
        /// <summary>
        /// 价格开始时间
        /// </summary>
        public DateTime StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// open可售状态，onrequest 房源紧张,close表示不可售
        /// </summary>
        public string Status
        {
            set { _status = value; }
            get { return _status; }
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
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 价格计划类型代码
        /// </summary>
        public int RatePlanCategory
        {
            set { _rateplancategory = value; }
            get { return _rateplancategory; }
        }
        /// <summary>
        /// 市场代码
        /// </summary>
        public int MarketCode
        {
            set { _marketcode = value; }
            get { return _marketcode; }
        }
        /// <summary>
        /// 是否立刻确认
        /// </summary>
        public int IsInstantConfirm
        {
            set { _isinstantconfirm = value; }
            get { return _isinstantconfirm; }
        }
        /// <summary>
        /// 房间附属信息
        /// </summary>
        public string Pertain
        {
            set { _pertain = value; }
            get { return _pertain; }
        }
        /// <summary>
        /// 同步状态
        /// </summary>
        public int SyncState
        {
            set { _syncstate = value; }
            get { return _syncstate; }
        }
        #endregion Model

    }
}
