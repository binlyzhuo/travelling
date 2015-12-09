using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.Scenery
{
    /// <summary>
    /// 景区订单信息
    /// </summary>
    [Serializable]
    public partial class T_SceneryTicketOrder
    {
        public T_SceneryTicketOrder()
        { }
        #region Model
        private int _id;
        private int _sceneryid = 0;
        private int _policyid = 0;
        private string _serialno = "";
        private int _state = 0;
        private string _linkman = "";
        private string _linktel = "";
        private int _ticketcount = 0;
        private int _totalamount = 0;
        private DateTime _adddate;
        private string _sceneryname = "";
        private DateTime _traveldate = Convert.ToDateTime("1900-1-1");
        private int _paymode = 0;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 景区ID
        /// </summary>
        public int SceneryID
        {
            set { _sceneryid = value; }
            get { return _sceneryid; }
        }
        /// <summary>
        /// 门票价格策络
        /// </summary>
        public int PolicyID
        {
            set { _policyid = value; }
            get { return _policyid; }
        }
        /// <summary>
        /// 订单流水号
        /// </summary>
        public string SerialNo
        {
            set { _serialno = value; }
            get { return _serialno; }
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string LinkTel
        {
            set { _linktel = value; }
            get { return _linktel; }
        }
        /// <summary>
        /// 门票张数
        /// </summary>
        public int TicketCount
        {
            set { _ticketcount = value; }
            get { return _ticketcount; }
        }
        /// <summary>
        /// 实付金额
        /// </summary>
        public int TotalAmount
        {
            set { _totalamount = value; }
            get { return _totalamount; }
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
        /// 景区名称
        /// </summary>
        public string SceneryName
        {
            set { _sceneryname = value; }
            get { return _sceneryname; }
        }

        /// <summary>
        /// 游玩日期
        /// </summary>
        public DateTime TravelDate
        {
            set { _traveldate = value; }
            get { return _traveldate; }
        }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int PayMode
        {
            set { _paymode = value; }
            get { return _paymode; }
        }
        #endregion Model

    }
}
