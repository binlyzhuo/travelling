using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain
{

    /// <summary>
    /// 景区门票价格
    /// </summary>
    [Serializable]
    public partial class T_SceneryTicketPrice
    {
        public T_SceneryTicketPrice()
        { }
        #region Model
        private int _id;
        private int? _sceneryid = 0;
        private int _policyid = 0;
        private string _policyname = "";
        private decimal _price = 0M;
        private decimal _tcprice = 0M;
        private int _ticketid;
        private string _ticketname;
        private DateTime _begindate = Convert.ToDateTime("1900-1-1");
        private DateTime _enddate = Convert.ToDateTime("1900-1-1");
        private DateTime _addtime = DateTime.Now;
        private string _remark = "";
        private int _paymode = 0;
        private string _getmode = "";
        private string _orderurl = "";
        private int _realname;
        private int _usecard = 0;
        private string _notes = "";
        private int _mintickets = 1;
        private int _maxtickets = 1;
        /// <summary>
        /// ?主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 景区ID
        /// </summary>
        public int? SceneryID
        {
            set { _sceneryid = value; }
            get { return _sceneryid; }
        }
        /// <summary>
        /// 价格策略ID
        /// </summary>
        public int PolicyID
        {
            set { _policyid = value; }
            get { return _policyid; }
        }
        /// <summary>
        /// 价格策略名称
        /// </summary>
        public string PolicyName
        {
            set { _policyname = value; }
            get { return _policyname; }
        }
        /// <summary>
        /// 门市价格
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 同程价格
        /// </summary>
        public decimal TCPrice
        {
            set { _tcprice = value; }
            get { return _tcprice; }
        }
        /// <summary>
        /// 门票类型Id
        /// </summary>
        public int TicketId
        {
            set { _ticketid = value; }
            get { return _ticketid; }
        }
        /// <summary>
        /// 门票类型名称
        /// </summary>
        public string TicketName
        {
            set { _ticketname = value; }
            get { return _ticketname; }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginDate
        {
            set { _begindate = value; }
            get { return _begindate; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 门票说明
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int PayMode
        {
            set { _paymode = value; }
            get { return _paymode; }
        }
        /// <summary>
        /// 取票方式
        /// </summary>
        public string GetMode
        {
            set { _getmode = value; }
            get { return _getmode; }
        }
        /// <summary>
        /// 预定跳转
        /// </summary>
        public string OrderUrl
        {
            set { _orderurl = value; }
            get { return _orderurl; }
        }
        /// <summary>
        /// 是否实名制
        /// </summary>
        public int RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 是否使用二代身份证
        /// </summary>
        public int UseCard
        {
            set { _usecard = value; }
            get { return _usecard; }
        }
        /// <summary>
        /// 注意事项
        /// </summary>
        public string Notes
        {
            set { _notes = value; }
            get { return _notes; }
        }
        /// <summary>
        /// 最小票数
        /// </summary>
        public int MinTickets
        {
            set { _mintickets = value; }
            get { return _mintickets; }
        }
        /// <summary>
        /// 最大票数
        /// </summary>
        public int MaxTickets
        {
            set { _maxtickets = value; }
            get { return _maxtickets; }
        }
        #endregion Model


    }
}
